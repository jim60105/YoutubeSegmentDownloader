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
                MessageBox.Show("Youtube Link invalid!");
                return;
            }

            float start = ConvertTimeStringToSecond(textBox_start.Text);
            float end = ConvertTimeStringToSecond(textBox_end.Text);

            if (start >= end
                || end <= 0
                || start < 0)
            {
                MessageBox.Show("Segment time invalid!");
                return;
            }

            DirectoryInfo directory;
            try
            {
                directory = new(textBox_outputDirectory.Text);
                directory.Create();
            }
            catch (Exception)
            {
                MessageBox.Show("Output Directory invalid!");
                return;
            }

            _ = DownloadAsync(id, start, end, directory).ConfigureAwait(true);
        }
        finally
        {
            panel1.Enabled = tableLayoutPanel_segment.Enabled = button_start.Enabled = true;
        }
    }

    private async Task DownloadAsync(string id, float start, float end, DirectoryInfo directory)
    {
        Download download = new(id: id,
                                start: start,
                                end: end,
                                outputDirectory: directory);
        _ = download.Start().ConfigureAwait(false);

        string lastLog = "";

        // Update UI
        while (!download.finished)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            if (null != download.error)
            {
                MessageBox.Show(download.error);
                return;
            }
            if (download.log != lastLog)
            {
                richTextBox_log.Text += download.log + '\n';
                lastLog = download.log;
                Application.DoEvents();
            }
        }

        MessageBox.Show($"Finish!\n{download.outputFilePath}");
    }

    private static float ConvertTimeStringToSecond(string text)
    {
        if (float.TryParse(text, out float result))
        {
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

        return result;
    }

    private void richTextBox_log_TextChanged(object sender, EventArgs e)
    {
        // set the current caret position to the end
        richTextBox_log.SelectionStart = richTextBox_log.Text.Length;
        // scroll it automatically
        richTextBox_log.ScrollToCaret();
    }
}
