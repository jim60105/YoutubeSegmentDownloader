using Serilog;
using SharpCompress.Archives;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Common;

namespace YoutubeSegmentDownloader;

public static class ExternalProgram
{
    public enum DependencyStatus
    {
        NotExist,
        Downloading,
        Exist
    }

    public static DependencyStatus Ytdlp_Status { get; private set; } = DependencyStatus.NotExist;
    public static DependencyStatus FFmpeg_Status { get; private set; } = DependencyStatus.NotExist;

    private static readonly DirectoryInfo TempDirectory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), nameof(YoutubeSegmentDownloader)));

    public static string? YtdlpPath { get; private set; }
    public static string? FFmpegPath { get; private set; }

    internal static async Task DownloadYtdlp()
    {
        Log.Information("Start downloading yt-dlp...");
        Ytdlp_Status = DependencyStatus.Downloading;

        YtdlpPath = TempDirectory.FullName;
        HttpClient client = new();
        string ytdlpUrl = @"https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        HttpResponseMessage response = await client.GetAsync(ytdlpUrl, HttpCompletionOption.ResponseHeadersRead);
        Log.Debug("Get response from {YtdlpUrl}", ytdlpUrl);

        string filePath = Path.Combine(YtdlpPath, "yt-dlp.exe");
        using FileStream fs = new(filePath, FileMode.Create);
        //response.EnsureSuccessStatusCode();
        await response.Content.CopyToAsync(fs);

        if (File.Exists(filePath))
        {
            Log.Information("Finish downloading yt-dlp at {filePath}", filePath);
            Ytdlp_Status = DependencyStatus.Exist;
            return;
        }
        else
        {
            Log.Fatal("Finished downloading yt-dlp but file not found in {filePath}!", filePath);
            Ytdlp_Status = DependencyStatus.NotExist;
        }
    }

    internal static async Task DownloadFFmpeg()
    {
        Log.Information("Start downloading FFmpeg...");
        FFmpeg_Status = DependencyStatus.Downloading;

        FFmpegPath = TempDirectory.FullName;
        HttpClient client = new();
        string ffmpegUrl = @"https://github.com/GyanD/codexffmpeg/releases/download/5.0/ffmpeg-5.0-essentials_build.7z";
        var response = await client.GetAsync(ffmpegUrl, HttpCompletionOption.ResponseHeadersRead);
        Log.Debug("Get response from {FFmpegUrl}", ffmpegUrl);

        string archivePath = Path.Combine(FFmpegPath, "ffmpeg-5.0-essentials_build.7z");
        using (FileStream fs = new(archivePath, FileMode.Create))
        {
            //response.EnsureSuccessStatusCode();
            await response.Content.CopyToAsync(fs);
        }
        Log.Information("Finish downloading FFmpeg at {filePath}", archivePath);

        try
        {
            using SevenZipArchive archive = SevenZipArchive.Open(archivePath);
            Log.Information("Start unpacking ffmpeg-5.0-essentials_build.7z");

            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory
                                                                 && (entry.Key.EndsWith("exe")
                                                                     || entry.Key.Contains("LICENSE"))))
            {
                Log.Information("{FilePath}", Path.Combine(FFmpegPath, Path.GetFileName(entry.Key)));
                entry.WriteToDirectory(FFmpegPath, new ExtractionOptions()
                {
                    ExtractFullPath = false,
                    Overwrite = true
                });
            }

            if (File.Exists(Path.Combine(FFmpegPath, "ffmpeg.exe")))
            {
                Log.Information("Complete FFmpeg unpacking to {filePath}", FFmpegPath);
                FFmpeg_Status = DependencyStatus.Exist;
            }
            else
            {
                Log.Fatal("Finished unpacking FFmpeg under {filePath} but couldn't find ffmpeg.exe!", FFmpegPath);
                FFmpeg_Status = DependencyStatus.NotExist;
            }
        }
        finally
        {
            File.Delete(archivePath);
        }
    }

    /// <summary>
    /// 尋找程式路徑
    /// </summary>
    /// <returns>Full path of yt-dlp and FFmpeg</returns>
    public static (string?, string?) WhereIs()
    {
        // https://stackoverflow.com/a/63021455
        string[] paths = Environment.GetEnvironmentVariable("PATH")?.Split(';') ?? Array.Empty<string>();
        string[] extensions = Environment.GetEnvironmentVariable("PATHEXT")?.Split(';') ?? Array.Empty<string>();
        string? _YtdlpPath = (from p in new[] { Environment.CurrentDirectory, TempDirectory.FullName }.Concat(paths)
                              from e in extensions
                              let path = Path.Combine(p.Trim(), "yt-dlp" + e.ToLower())
                              where File.Exists(path)
                              select Path.GetDirectoryName(path))?.FirstOrDefault();
        string? _FFmpegPath = (from p in new[] { Environment.CurrentDirectory, TempDirectory.FullName }.Concat(paths)
                               from e in extensions
                               let path = Path.Combine(p.Trim(), "ffmpeg" + e.ToLower())
                               where File.Exists(path)
                               select Path.GetDirectoryName(path))?.FirstOrDefault();

        Ytdlp_Status = string.IsNullOrEmpty(_YtdlpPath)
                        ? DependencyStatus.NotExist
                        : DependencyStatus.Exist;
        FFmpeg_Status = string.IsNullOrEmpty(_FFmpegPath)
                        ? DependencyStatus.NotExist
                        : DependencyStatus.Exist;

        YtdlpPath = _YtdlpPath;
        FFmpegPath = _FFmpegPath;
        Log.Information("Found yt-dlp.exe at {YtdlpPath}", YtdlpPath);
        Log.Information("Found ffmpeg.exe at {FFmpegPath}", FFmpegPath);

#if false
#warning Disable this "Force download again" debug section!
        Log.Debug("Force download again!");
        YtdlpPath = FFmpegPath = null;
        Ytdlp_Status = FFmpeg_Status = DependencyStatus.NotExist;
        foreach (var file in TempDirectory.GetFiles())
        {
            file.Delete();
        }
#endif

        return (_YtdlpPath, _FFmpegPath);
    }
}
