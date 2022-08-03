using Serilog;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;
using SharpCompress.Common;

namespace YoutubeSegmentDownloader;

public static class ExternalProgram
{
    public enum DependencyStatus
    {
        Unknown,
        NotExist,
        Downloading,
        Exist
    }

    public static DependencyStatus Ytdlp_Status { get; private set; } = DependencyStatus.Unknown;
    public static DependencyStatus FFmpeg_Status { get; private set; } = DependencyStatus.Unknown;

    private static readonly DirectoryInfo TempDirectory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), nameof(YoutubeSegmentDownloader)));

    public static string? YtdlpPath { get; private set; }
    public static string? FFmpegPath { get; private set; }

    // https://github.com/yt-dlp/FFmpeg-Builds/releases/latest
    private const string FFmpegFileName = "ffmpeg-n5.1-latest-win64-gpl-shared-5.1.zip";

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
        File.Delete(filePath);

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
        string ffmpegUrl = @$"https://github.com/yt-dlp/FFmpeg-Builds/releases/download/latest/{FFmpegFileName}";
        var response = await client.GetAsync(ffmpegUrl, HttpCompletionOption.ResponseHeadersRead);
        Log.Debug("Get response from {FFmpegUrl}", ffmpegUrl);

        string archivePath = Path.Combine(FFmpegPath, FFmpegFileName);
        File.Delete(archivePath);

        using (FileStream fs = new(archivePath, FileMode.Create))
        {
            //response.EnsureSuccessStatusCode();
            await response.Content.CopyToAsync(fs);
        }
        Log.Information("Finish downloading FFmpeg at {filePath}", archivePath);

        try
        {
            using ZipArchive archive = ZipArchive.Open(archivePath);
            Log.Information("Start unpacking {FFmpegFileName}", FFmpegFileName);

            foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory
                                                                 && (entry.Key.EndsWith("exe")
                                                                     || entry.Key.EndsWith("dll")
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

        // ffmpeg not selected as downloader when not in PATH
        // In short: --ffmpeg-location doesn't work. Force download everything to my tmp folder.
        // https://github.com/yt-dlp/yt-dlp/issues/2191

        //string? _YtdlpPath = (from p in new[] { Environment.CurrentDirectory, TempDirectory.FullName }.Concat(paths)
        string? _YtdlpPath = (from p in new[] { TempDirectory.FullName }
                              from e in extensions
                              let path = Path.Combine(p.Trim(), "yt-dlp" + e.ToLower())
                              where File.Exists(path)
                              select Path.GetDirectoryName(path))?.FirstOrDefault();
        //string? _FFmpegPath = (from p in new[] { Environment.CurrentDirectory, TempDirectory.FullName }.Concat(paths)
        string? _FFmpegPath = (from p in new[] { TempDirectory.FullName }
                               from e in extensions
                               let path = Path.Combine(p.Trim(), "ffmpeg" + e.ToLower())
                               where File.Exists(path)
                               select Path.GetDirectoryName(path))?.FirstOrDefault();

        //Ytdlp_Status = string.IsNullOrEmpty(_YtdlpPath)
        //                ? DependencyStatus.NotExist
        //                : DependencyStatus.Exist;
        //FFmpeg_Status = string.IsNullOrEmpty(_FFmpegPath)
        //                ? DependencyStatus.NotExist
        //                : DependencyStatus.Exist;

        YtdlpPath = _YtdlpPath;
        FFmpegPath = _FFmpegPath;
        Log.Debug("Found yt-dlp.exe at {YtdlpPath}", YtdlpPath);
        Log.Debug("Found ffmpeg.exe at {FFmpegPath}", FFmpegPath);

#if false
#warning Disable this "Force download again" debug section!
        Log.Debug("Force download again!");
        YtdlpPath = FFmpegPath = null;
        foreach (var file in TempDirectory.GetFiles())
        {
            file.Delete();
        }
#endif

        return (_YtdlpPath, _FFmpegPath);
    }

    /// <summary>
    /// 更新依賴
    /// </summary>
    /// <param name="_YtdlpPath"></param>
    /// <param name="_FFmpegPath"></param>
    /// <param name="force">強制更新所有依賴</param>
    /// <returns></returns>
    public static Task UpdateDependenciesAsync(string? _YtdlpPath = null, string? _FFmpegPath = null, bool force = false)
    {
        List<Task> tasks = new();
        if (string.IsNullOrEmpty(_YtdlpPath)
            || !File.Exists(Path.Combine(_YtdlpPath, "yt-dlp.exe"))
            || force)
        {
            Ytdlp_Status = DependencyStatus.NotExist;
            tasks.Add(DownloadYtdlp());
        }
        else
        {
            Ytdlp_Status = DependencyStatus.Exist;
        }

        //string version = await GetFFmpegVersionAsync(_FFmpegPath);
        //if (!version.Contains("5.0") || force)
        if (string.IsNullOrEmpty(_FFmpegPath)
            || !File.Exists(Path.Combine(_FFmpegPath, "ffmpeg.exe"))
            || !File.Exists(Path.Combine(_FFmpegPath, "ffprobe.exe"))
            || force)
        {
            FFmpeg_Status = DependencyStatus.NotExist;
            //Log.Information("No matching version of FFmpeg was detected.");
            tasks.Add(DownloadFFmpeg());
        }
        else
        {
            FFmpeg_Status = DependencyStatus.Exist;
            //Log.Information("Detected that your FFmpeg version matches.");
        }

        return Task.WhenAll(tasks);
    }

    //public static async Task<string> GetFFmpegVersionAsync(string? _FFmpegPath)
    //{
    //    string FFmpegVersion = "";

    //    if (string.IsNullOrEmpty(_FFmpegPath)) return "";
    //    FFmpeg.SetExecutablesPath(_FFmpegPath);

    //    Log.Information("Start to check FFmpeg version.");
    //    IConversion conversion = FFmpeg.Conversions.New();
    //    conversion.OnDataReceived += (_, e) =>
    //    {
    //        if (string.IsNullOrEmpty(FFmpegVersion))
    //        {
    //            // Take the first line
    //            FFmpegVersion = e.Data ?? "";
    //        }
    //        Log.Verbose(e.Data);
    //    };
    //    //Log.Debug("FFmpeg arguments: {arguments}", conversion.Build());

    //    try
    //    {
    //        await conversion.Start();
    //    }
    //    // Must Exception
    //    catch (ConversionException) { }

    //    Log.Information(FFmpegVersion);
    //    return FFmpegVersion;
    //}

}
