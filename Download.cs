using Serilog;
using System.Diagnostics;
using Xabe.FFmpeg;
using YoutubeDLSharp;
using YoutubeDLSharp.Metadata;
using YoutubeDLSharp.Options;

namespace YoutubeSegmentDownloader;

internal class Download
{
    private readonly string id;
    private readonly float start;
    private readonly float end;
    private readonly DirectoryInfo outputDirectory;
    public bool finished = false;
    public string? outputFilePath = null;

    public Download(string id,
                    float start,
                    float end,
                    DirectoryInfo outputDirectory)
    {
        this.id = id;
        this.start = start;
        this.end = end;
        this.outputDirectory = outputDirectory;
    }

    public async Task Start()
    {
        Log.Information("Start the download process...");

        string tempFilePath1 = Path.ChangeExtension(Path.GetTempFileName(), ".mp4");
        string tempFilePath2 = Path.ChangeExtension(Path.GetTempFileName(), ".mp4");
        Log.Debug("Create temporary files:");
        Log.Debug("{TempFilePath}", tempFilePath1);
        Log.Debug("{TempFilePath}", tempFilePath2);

        OptionSet optionSet = new()
        {
            NoCheckCertificate = true,
            // Workaround for FFmpeg sometimes uses 251 as bestvideo
            CustomOptions = new IOption[] {
                new Option<string>(true, "-S")
                {
                    Value = "+codec:h264"
                }
            }
        };

        if (end != 0)
        {
            optionSet.ExternalDownloader = "ffmpeg";
            optionSet.ExternalDownloaderArgs = $"ffmpeg_i:-ss {start} -to {end}";
        }

        YoutubeDL? ytdl = new()
        {
            YoutubeDLPath = Path.Combine(ExternalProgram.YtdlpPath ?? "./", "yt-dlp.exe"),
            FFmpegPath = Path.Combine(ExternalProgram.FFmpegPath ?? "./", "ffmpeg.exe"),
            //OutputFolder = outputDirectory.FullName,
            OutputFileTemplate = tempFilePath1,
            OverwriteFiles = true,
            IgnoreDownloadErrors = true
        };

        try
        {
            VideoData? videoData = await FetchVideoInfoAsync(ytdl);
            if (null == videoData) return;

            outputFilePath = CalculatePath(videoData?.Title, videoData?.UploadDate);

            if (!await DownloadVideoAsync(ytdl, optionSet)) return;

            if (end != 0)
            {
                await CutWithFFmpegAsync(tempFilePath1, tempFilePath2);
                Log.Information("Move file to {filePath}", outputFilePath);
                File.Move(tempFilePath2, outputFilePath, true);
            }
            else
            {
                Log.Information("Move file to {filePath}", outputFilePath);
                File.Move(tempFilePath1, outputFilePath, true);
            }
            Log.Information("Download completed:");
            Log.Information(outputFilePath);
            finished = true;
        }
        finally
        {
            File.Delete(tempFilePath1);
            File.Delete(tempFilePath2);
            Log.Information("Clean up temporary files.");
        }
    }

    /// <summary>
    /// 取得影片資訊
    /// </summary>
    /// <param name="ytdl"></param>
    /// <returns></returns>
    private async Task<VideoData?> FetchVideoInfoAsync(YoutubeDL ytdl)
    {
        Log.Information("Start getting video information...");
        RunResult<VideoData> result_VideoData = await ytdl.RunVideoDataFetch(@$"https://youtu.be/{id}");

        if (!result_VideoData.Success)
        {
            Log.Error("Failed to get video information! VideoId: {id}", id);
            return null;
        }

        float duration = result_VideoData.Data.Duration ?? 0;

        Log.Information("{title}", result_VideoData.Data.Title);
        Log.Information("{duration}", duration);

        if (result_VideoData.Data.Duration < start)
        {
            Log.Error("Segment input invalid!");
            Log.Error("Start, End time should be smaller then video duration.");
            return null;
        }

        return result_VideoData.Data;
    }

    /// <summary>
    /// 下載影片
    /// </summary>
    /// <param name="ytdl"></param>
    /// <param name="optionSet"></param>
    /// <returns></returns>
    private async Task<bool> DownloadVideoAsync(YoutubeDL ytdl, OptionSet optionSet)
    {
        Log.Information("Start downloading video...");
        var result_string = await ytdl.RunVideoDownload(
            url: @$"https://youtu.be/{id}",
            mergeFormat: DownloadMergeFormat.Mp4,
            output: new Progress<string>(s => Log.Verbose(s)),
            overrideOptions: optionSet);

        if (!result_string.Success)
        {
            Log.Error("Failed to download video!");
            foreach (var str in result_string.ErrorOutput)
            {
                Log.Information(str);
            }
            return false;
        }
        Log.Information("Video downloaded.");
        return true;
    }

    /// <summary>
    /// 剪切影片
    /// </summary>
    /// <param name="inputPath"></param>
    /// <param name="outputPath"></param>
    /// <returns></returns>
    private async Task<IConversionResult> CutWithFFmpegAsync(string inputPath, string outputPath)
    {
        Log.Information("Start cutting video with FFmpeg...");

        float duration = end - start;

        FFmpeg.SetExecutablesPath(ExternalProgram.FFmpegPath);
        IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(inputPath);
        IConversion conversion = FFmpeg.Conversions.New()
                                   .AddStream(mediaInfo.Streams)
                                   .AddParameter($"-ss {mediaInfo.Duration - TimeSpan.FromSeconds(duration)}")
                                   .SetOutput(outputPath)
                                   .SetOverwriteOutput(true);
        conversion.OnDataReceived += (_, e) => Log.Verbose(e.Data);
        Log.Debug("FFmpeg arguments: {arguments}", conversion.Build());
        return await conversion.Start();
    }

    /// <summary>
    /// 路徑做檢查和轉換
    /// </summary>
    /// <param name="title">影片標題，用做檔名</param>
    /// <param name="date">影片日期，用做檔名</param>
    /// <returns></returns>
    private string CalculatePath(string? title, DateTime? date)
    {
        title ??= "";
        // 取代掉檔名中的非法字元
        title = string.Join(string.Empty, title.Split(Path.GetInvalidFileNameChars()))
                      .Replace(".", string.Empty);
        // 截短
        if (title.Length > 80)
        {
            Log.Warning("The title is too long! Limit it to 80 characters.");
            title = title[..80];
        }

        date ??= DateTime.Now;

        string newPath = Path.Combine(outputDirectory.FullName, $"{date:yyyyMMdd} {title} ({id}).mp4");

        Log.Debug("Calculate output file path as {newPath}", newPath);
        return newPath;
    }
}
