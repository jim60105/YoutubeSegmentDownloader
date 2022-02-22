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
        checkBox_logVerbose_CheckedChanged(new(), new());
        _ = PrepareYtdlpAndFFmpegAsync().ConfigureAwait(true);  // Use same thread
        Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
    }

    private async Task PrepareYtdlpAndFFmpegAsync()
    {
        _ = WhereIs();

        // Start Download
        if (string.IsNullOrEmpty(FFmpegPath))
            _ = DownloadFFmpeg().ConfigureAwait(false);

        if (string.IsNullOrEmpty(YtdlpPath))
            _ = DownloadYtdlp().ConfigureAwait(false);

        // Update UI
        while (FFmpeg_Status != DependencyStatus.Exist
                || Ytdlp_Status != DependencyStatus.Exist)
        {
            panel_download.Visible = true;

            await Task.Delay(TimeSpan.FromSeconds(1));
            label_checking_ytdlp.Text =
                Ytdlp_Status switch
                {
                    DependencyStatus.NotExist => "❌",
                    DependencyStatus.Downloading => "⌛",
                    DependencyStatus.Exist => "✔️",
                    _ => throw new NotImplementedException()
                };
            label_checking_ffmpeg.Text =
                FFmpeg_Status switch
                {
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
        Settings.Default.Save();

        string id = textBox_youtube.Text.Contains('/')
            // Regex for strip youtube video id from url c# and returl default thumbnail
            // https://gist.github.com/Flatlineato/f4cc3f3937272646d4b0
            ? Regex.Match(textBox_youtube.Text,
                          "https?:\\/\\/(?:[0-9A-Z-]+\\.)?(?:youtu\\.be\\/|youtube(?:-nocookie)?\\.com\\S*[^\\w\\s-])([\\w-]{11})(?=[^\\w-]|$)(?![?=&+%\\w.-]*(?:['\"][^<>]*>|<\\/a>))[?=&+%\\w.-]*",
                          RegexOptions.IgnoreCase).Groups[1].Value
            : textBox_youtube.Text;

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

        _ = DownloadAsync(id, start, end, directory).ConfigureAwait(true);
    }

    private async Task DownloadAsync(string id, float start, float end, DirectoryInfo directory)
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
                                    outputDirectory: directory);
            _ = download.Start().ConfigureAwait(false);

            // Update UI
            while (!download.finished)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                Application.DoEvents();
            }

            // Open save directory
            Process process = new();
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.FileName = directory.FullName;
            process.Start();

            MessageBox.Show($"Video segments are stored in:\n\n{download.outputFilePath}", "Finish");
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
                    result += t * (i * 60);
                }
                else
                {
                    // Parse failed
                    result = 0;
                    break;
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
}
