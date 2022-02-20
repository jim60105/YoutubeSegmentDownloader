using Serilog;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
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
        Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
        _ = PrepareYtdlpAndFFmpegAsync().ConfigureAwait(true);  // Use same thread
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
        tableLayoutPanel1.Enabled = tableLayoutPanel_segment.Enabled = button_start.Enabled = false;

        try
        {
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
                MessageBox.Show("Youtube Link invalid!");
                return;
            }
            Log.Information("Get VideoID: {VideoId}", id);

            float start = ConvertTimeStringToSecond(textBox_start.Text);
            float end = ConvertTimeStringToSecond(textBox_end.Text);

            if (start >= end
                || end <= 0
                || start < 0)
            {
                Log.Error("Segment time invalid!");
                MessageBox.Show("Segment time invalid!");
                return;
            }
            Log.Information("Input segment: {start} ~ {end}", start, end);

            DirectoryInfo directory;
            try
            {
                directory = new(textBox_outputDirectory.Text);
                directory.Create();
            }
            catch (Exception)
            {
                Log.Error("Output Directory invalid!");
                MessageBox.Show("Output Directory invalid!");
                return;
            }
            Log.Information("Output directory: {Output Directory}", directory.FullName);

            _ = DownloadAsync(id, start, end, directory).ConfigureAwait(true);
        }
        finally
        {
            panel1.Enabled = tableLayoutPanel_segment.Enabled = button_start.Enabled = true;
        }
    }

    private static async Task DownloadAsync(string id, float start, float end, DirectoryInfo directory)
    {
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

        MessageBox.Show($"Finish!\n{download.outputFilePath}");
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

    private void richTextBoxLogControl1_TextChanged(object sender, EventArgs e)
    {
        // set the current caret position to the end
        richTextBoxLogControl1.SelectionStart = richTextBoxLogControl1.Text.Length;
        // scroll it automatically
        richTextBoxLogControl1.ScrollToCaret();
    }

    #region Link
    private static void VisitLink(LinkLabel linkLabel, string url)
    {
        // Change the color of the link text by setting LinkVisited
        // to true.
        linkLabel.LinkVisited = true;
        //Call the Process.Start method to open the default browser
        //with a URL:
        //System.Diagnostics.Process.Start(url);
        Process myProcess = new();
        myProcess.StartInfo.UseShellExecute = true;
        myProcess.StartInfo.FileName = url;
        myProcess.Start();
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            VisitLink(linkLabel1,"https://github.com/GyanD/codexffmpeg/releases/tag/5.0");
        }
        catch (Exception )
        {
            MessageBox.Show("Unable to open link that was clicked.");
        }
    }

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            VisitLink(linkLabel2, "https://github.com/FFmpeg/FFmpeg/commit/390d6853d0");
        }
        catch (Exception )
        {
            MessageBox.Show("Unable to open link that was clicked.");
        }
    }

    private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            VisitLink(linkLabel3, "https://github.com/yt-dlp/yt-dlp/releases/latest");
        }
        catch (Exception )
        {
            MessageBox.Show("Unable to open link that was clicked.");
        }
    }

    private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            VisitLink(linkLabel5, "https://github.com/jim60105/YoutubeSegmentDownloader");
        }
        catch (Exception )
        {
            MessageBox.Show("Unable to open link that was clicked.");
        }
    }
    #endregion
}
