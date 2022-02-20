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
    public string log = "";
    public string? outputFilePath = null;
    public string? error = null;

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
        string tempFilePath1 = Path.ChangeExtension(Path.GetTempFileName(), ".mp4");
        string tempFilePath2 = Path.ChangeExtension(Path.GetTempFileName(), ".mp4");
        OptionSet optionSet = new()
        {
            NoCheckCertificate = true,
            ExternalDownloader = "ffmpeg",
            ExternalDownloaderArgs = $"ffmpeg_i:-ss {start} -to {end}"
        };

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
            if (null == videoData)
            {
                error = $"Faild to fetch video information!\nVideoId: {id}";
                return;
            }
            outputFilePath = CalculatePath(videoData?.Title, videoData?.UploadDate);

            await DownloadVideo(ytdl, optionSet);

            await CutWithFFmpeg(tempFilePath1, tempFilePath2).Unwrap();

            File.Move(tempFilePath2, outputFilePath, true);
        }
        finally
        {
            File.Delete(tempFilePath1);
            File.Delete(tempFilePath2);
        }
    }

    private async Task<bool> DownloadVideo(YoutubeDL ytdl, OptionSet optionSet)
    {
        var result_string = await ytdl.RunVideoDownload(
            url: @$"https://youtu.be/{id}",
            mergeFormat: DownloadMergeFormat.Mp4,
            output: new Progress<string>(s => log = s),
            overrideOptions: optionSet);

        if (!result_string.Success)
        {
            error = "Failded to download video!\n" + string.Join('\n', result_string.ErrorOutput);
            return false;
        }
        return true;
    }

    private async Task<VideoData?> FetchVideoInfoAsync(YoutubeDL ytdl)
    {
        RunResult<VideoData> result_VideoData = await ytdl.RunVideoDataFetch(@$"https://youtu.be/{id}");

        return result_VideoData.Success ? result_VideoData.Data : null;
    }

    private async Task<Task<IConversionResult>> CutWithFFmpeg(string tempFilePath1, string tempFilePath2)
    {
        float duration = end - start;

        IConversion conversion = await FFmpeg.Conversions.FromSnippet.Split(
            inputPath: tempFilePath1,
            outputPath: tempFilePath2,
            startTime: TimeSpan.FromSeconds((await FFmpeg.GetMediaInfo(tempFilePath1)).Duration.TotalSeconds - duration),
            duration: TimeSpan.FromSeconds(duration));
        return conversion.Start();
    }

    /// <summary>
    /// 路徑做檢查和轉換
    /// </summary>
    /// <param name="oldPath"></param>
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
            title = title[..80];
        }

        date ??= DateTime.Now;

        string newPath = Path.Combine(outputDirectory.FullName, $"{date:yyyyMMdd} {title} ({id}).mp4");

        //logger.Debug("Rename file: {oldPath} => {newPath}", oldPath, newPath);
        return newPath;
    }
}
