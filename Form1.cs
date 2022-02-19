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
    }

    private void PrepareYtdlpAndFFmpeg()
    {
        panel_download.Visible = true;

        (string? ytdlpPath, string? ffmpegPath) = WhereIs();

#if false
            // Force download again
            ytdlpPath = ffmpegPath = null;
            Ytdlp_Status = FFmpeg_Status = DependencyStatus.NotExist;
#endif

        if (string.IsNullOrEmpty(ffmpegPath)) DownloadFFmpeg().ConfigureAwait(false);

        if (string.IsNullOrEmpty(ytdlpPath)) DownloadYtdlp().ConfigureAwait(false);

        // Update UI
        do
        {
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
        } while (FFmpeg_Status != DependencyStatus.Exist
                 || Ytdlp_Status != DependencyStatus.Exist);

        //panel_download.Visible = false;
    }

}
