using System.Globalization;
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
        PrepareYtdlpAndFFmpeg();
        Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
    }

    private void PrepareYtdlpAndFFmpeg()
    {
        (string? ytdlpPath, string? ffmpegPath) = WhereIs();

#if false
            // Force download again
            ytdlpPath = ffmpegPath = null;
            Ytdlp_Status = FFmpeg_Status = DependencyStatus.NotExist;
#endif

        // Start Download
        if (string.IsNullOrEmpty(ffmpegPath)) 
            DownloadFFmpeg().ConfigureAwait(false);

        if (string.IsNullOrEmpty(ytdlpPath))
            DownloadYtdlp().ConfigureAwait(false);

        // Update UI
         while (FFmpeg_Status != DependencyStatus.Exist
                 || Ytdlp_Status != DependencyStatus.Exist)
        {
            panel_download.Visible = true;

            Task.Delay(TimeSpan.FromSeconds(1)).Wait();
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
}
