using Serilog;
using Serilog.Events;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using YoutubeSegmentDownloader.Properties;
using static YoutubeSegmentDownloader.ExternalProgram;

namespace YoutubeSegmentDownloader;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Shown += Form1_Shown;
    }

    private void Form1_Shown(object? sender, EventArgs e)
    {
        textBox_outputDirectory.Text = Settings.Default.Directory;
        checkBox_logVerbose.Checked = Settings.Default.LogVerbose;
        comboBox_browser.SelectedIndex = comboBox_browser.FindString(Settings.Default.Browser);
        textBox_format.Text = Settings.Default.Format;
        checkBox_logVerbose_CheckedChanged(new(), new());
        _ = PrepareYtdlpAndFFmpegAsync(false).ConfigureAwait(true);  // Use same thread
        Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
    }

    private async Task PrepareYtdlpAndFFmpegAsync(bool forceUpdate = false)
    {
        (string? ytdlpPath, string? ffmpegPath) = WhereIs();
        _ = UpdateDependenciesAsync(ytdlpPath, ffmpegPath, forceUpdate).ConfigureAwait(false);

        // Update UI
        while (FFmpeg_Status != DependencyStatus.Exist
                || Ytdlp_Status != DependencyStatus.Exist)
        {
            panel_download.Visible = true;

            await Task.Delay(TimeSpan.FromSeconds(1));
            label_checking_ytdlp.Text =
                Ytdlp_Status switch
                {
                    DependencyStatus.Unknown => "❓",
                    DependencyStatus.NotExist => "❌",
                    DependencyStatus.Downloading => "⌛",
                    DependencyStatus.Exist => "✔️",
                    _ => throw new NotImplementedException()
                };
            label_checking_ffmpeg.Text =
                FFmpeg_Status switch
                {
                    DependencyStatus.Unknown => "❓",
                    DependencyStatus.NotExist => "❌",
                    DependencyStatus.Downloading => "⌛",
                    DependencyStatus.Exist => "✔️",
                    _ => throw new NotImplementedException()
                };

            Application.DoEvents();
        }

        Log.Information("Finish downloading all dependencies.");
        panel_download.Visible = false;
    }

    private void checkBox_segment_CheckedChanged(object sender, EventArgs e)
    {
        tableLayoutPanel_segment.Enabled = checkBox_segment.Checked;
    }

    private void button_start_Click(object sender, EventArgs e)
    {
        Settings.Default.Directory = textBox_outputDirectory.Text;

        string id = "";
        if (!textBox_youtube.Text.Contains('/'))
        {
            id = textBox_youtube.Text;
        }

        if (string.IsNullOrEmpty(id))
        {
            // Regex for strip youtube video id from url c# and returl default thumbnail
            // https://gist.github.com/Flatlineato/f4cc3f3937272646d4b0
            Regex idRegex = new("https?:\\/\\/(?:[0-9A-Z-]+\\.)?(?:youtu\\.be\\/|youtube(?:-nocookie)?\\.com\\S*[^\\w\\s-])([\\w-]{11})(?=[^\\w-]|$)(?![?=&+%\\w.-]*(?:['\"][^<>]*>|<\\/a>))[?=&+%\\w.-]*");
            Match idMatch = idRegex.Match(textBox_youtube.Text);
            if (idMatch.Success)
            {
                id = idMatch.Groups[1].Value;
            }
        }

        if (string.IsNullOrEmpty(id))
        {
            Log.Error("Youtube Link invalid!");
            MessageBox.Show("Youtube Link invalid!", "Error!");
            return;
        }
        Log.Information("Get VideoID: {VideoId}", id);

        float start = ConvertTimeStringToSecond(textBox_start.Text);
        float end = ConvertTimeStringToSecond(textBox_end.Text);
        if (checkBox_segment.Checked)
        {
            if (start >= end
                || end <= 0
                || start < 0)
            {
                Log.Error("Segment time invalid!");
                MessageBox.Show("Segment time invalid!", "Error!");
                return;
            }
            Log.Information("Input segment: {start} ~ {end}", start, end);
        }
        else
        {
            start = end = 0;
            Log.Information("Segment input is disabled.");
        }

        DirectoryInfo directory;
        try
        {
            string path = textBox_outputDirectory.Text.Contains('%')
                ? Environment.ExpandEnvironmentVariables(textBox_outputDirectory.Text)
                : textBox_outputDirectory.Text;
            directory = new(path);
            directory.Create();
        }
        catch (Exception)
        {
            Log.Error("Output Directory invalid!");
            MessageBox.Show("Output Directory invalid!", "Error!");
            return;
        }
        Log.Information("Output directory:");
        Log.Information(directory.FullName);


        string format = textBox_format.Text;
        Settings.Default.Format = format;

        string browser = comboBox_browser.Text;
        if (string.IsNullOrEmpty(browser) || browser == "( Disabled )")
        {
            browser = "";
        }
        Settings.Default.Browser = browser;
        Settings.Default.Save();

        _ = DownloadAsync(id, start, end, directory, format, browser).ConfigureAwait(true);
    }

    private async Task DownloadAsync(string id, float start, float end, DirectoryInfo directory, string format, string browser)
    {
        try
        {
            tableLayoutPanel_main.Enabled
                = tableLayoutPanel_segment.Enabled
                = button_start.Enabled
                = false;
            Application.DoEvents();

            Download download = new(id: id,
                                    start: start,
                                    end: end,
                                    outputDirectory: directory,
                                    format: format,
                                    browser: browser);
            _ = download.Start().ConfigureAwait(false);

            // Update UI
            while (!download.finished)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Application.DoEvents();
            }

            MessageBox.Show($"Video segments are stored in:\n\n{download.outputFilePath}", "Finish");

            // Open save directory
            Process process = new();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = directory.FullName;
            process.Start();
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
        }
        finally
        {
            tableLayoutPanel_main.Enabled
                = button_start.Enabled
                = true;
            tableLayoutPanel_segment.Enabled = checkBox_segment.Checked;
            Application.DoEvents();
        }
    }

    private static float ConvertTimeStringToSecond(string text)
    {
        Log.Debug("Convert time string from {OriginalTimeString}", text);
        if (float.TryParse(text, out float result))
        {
            Log.Debug("Time string is pure float!");
            return result;
        }

        if (text.Contains(':'))
        {
            List<string> timeList = text.Split(':').ToList();
            timeList.Reverse();

            result = 0;
            for (int i = 0; i < timeList.Count && i < 3; i++)
            {
                string time = timeList[i].Trim();
                if (float.TryParse(time, out var t))
                {
                    result += (float)(t * Math.Pow(60, i));
                }
                else
                {
                    // Parse failed
                    Log.Logger.Error("Cannot parse {time} to float number!", time);
                    return -1;
                }
            }
        }

        Log.Debug("Convert time string to {Seconds}", result);
        return result;
    }

    private void enter_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            button_start_Click(new(), new());
        }
    }

    private void checkBox_logVerbose_CheckedChanged(object sender, EventArgs e)
    {
        Program.levelSwitch.MinimumLevel = checkBox_logVerbose.Checked
            ? LogEventLevel.Verbose
            : LogEventLevel.Information;

        Settings.Default.LogVerbose = checkBox_logVerbose.Checked;
        Settings.Default.Save();
    }

    private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
        try
        {
            //Call the Process.Start method to open the default browser
            //with a URL:
            Process process = new();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = e.LinkText;
            process.Start();
        }
        catch (Exception)
        {
            MessageBox.Show("Unable to open link that was clicked.", "Error!");
        }
    }

    private void button_folder_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            textBox_outputDirectory.Text = folderBrowserDialog1.SelectedPath;
        }
    }

    private void button_redownloadDependencies_Click(object sender, EventArgs e)
    {
        _ = PrepareYtdlpAndFFmpegAsync(true).ConfigureAwait(true);  // Use same thread
    }

    private void textBox_youtube_TextChanged(object sender, EventArgs e)
    {
        button_start.Enabled = false;
        try
        {
            if (FetchYoutubeClipInformation(textBox_youtube.Text, out string id, out var start, out var end))
            {
                textBox_youtube.Text = id;
                checkBox_segment.Checked = true;
                textBox_start.Text = start.ToString();
                textBox_end.Text = end.ToString();
            }
        }
        finally
        {
            button_start.Enabled = true;
        }
    }

    private static bool FetchYoutubeClipInformation(string url, out string id, out float start, out float end)
    {
        id = "";
        start = end = 0;

        Regex clipReg = new(@"https?:\/\/(?:[\w-]+\.)?(?:youtu\.be\/|youtube(?:-nocookie)?\.com\/)clip\/[?=&+%\w.-]*");

        if (string.IsNullOrEmpty(url) || !clipReg.IsMatch(url)) return false;

        using HttpClient client = new();
        var response = client.GetAsync(url).Result;
        if (!response.IsSuccessStatusCode)
        {
            Log.Error("Couldn't get the clip. Status {code}.", response.StatusCode);
            Log.Error(url);
            return false;
        }
        string body = response.Content.ReadAsStringAsync().Result;

        // "clipConfig":{"postId":"UgkxVQpxshiN76QUwblPu-ggj6fl594-ORiU","startTimeMs":"1891037","endTimeMs":"1906037"}
        Regex reg1 = new(@"clipConfig"":{""postId"":""(?:[\w-]+)"",""startTimeMs"":""(\d+)"",""endTimeMs"":""(\d+)""}");
        Match match1 = reg1.Match(body);
        if (match1.Success)
        {
            if (float.TryParse(match1.Groups[1].Value, out float _start)
                && float.TryParse(match1.Groups[2].Value, out float _end))
            {
                start = _start / 1000;
                end = _end / 1000;
            }
        }

        // {"videoId":"Gs7QYATahy4"}
        Regex reg2 = new(@"{""videoId"":""([\w-]+)""");
        Match match2 = reg2.Match(body);
        if (match2.Success)
        {
            id = match2.Groups[1].Value;
        }
        Log.Information("Get info from clip: {videoId}, {start}, {end}", id, start, end);
        return match1.Success && match2.Success;
    }
}
