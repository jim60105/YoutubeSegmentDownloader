using System.Reflection;
using System.Text.RegularExpressions;
using YoutubeDLSharp;
using YoutubeDLSharp.Helpers;
using YoutubeDLSharp.Options;
using YtdlpVideoData = YoutubeSegmentDownloader.Models.YtdlpVideoData.ytdlpVideoData;

namespace YoutubeSegmentDownloader.Extension;

internal static partial class YoutubeDLExtension
{
#nullable disable
    /// <summary>
    /// Modified from YoutubeDL.RunVideoDataFetch()
    /// </summary>
    /// <param name="ytdl"></param>
    /// <param name="url"></param>
    /// <param name="ct"></param>
    /// <param name="flat"></param>
    /// <param name="fetchComments"></param>
    /// <param name="overrideOptions"></param>
    /// <returns></returns>
#pragma warning disable CA1068 // CancellationToken 參數必須位於最後
    public static async Task<RunResult<YtdlpVideoData>> RunVideoDataFetch_Alt(this YoutubeDL ytdl,
            string url,
            CancellationToken ct = default,
            bool flat = true,
            bool fetchComments = false,
            OptionSet overrideOptions = null)
#pragma warning restore CA1068 // CancellationToken 參數必須位於最後
    {
        OptionSet opts = new()
        {
            IgnoreErrors = ytdl.IgnoreDownloadErrors,
            IgnoreConfig = true,
            NoPlaylist = true,
            Downloader = "m3u8:native",
            DownloaderArgs = "ffmpeg:-nostats -loglevel 0",
            Output = Path.Combine(ytdl.OutputFolder, ytdl.OutputFileTemplate),
            RestrictFilenames = ytdl.RestrictFilenames,
            ForceOverwrites = ytdl.OverwriteFiles,
            NoOverwrites = !ytdl.OverwriteFiles,
            NoPart = true,
            FfmpegLocation = Utils.GetFullPath(ytdl.FFmpegPath),
            Exec = "echo outfile: {}",
            DumpSingleJson = true,
            FlatPlaylist = flat,
            WriteComments = fetchComments
        };
        if (overrideOptions != null)
        {
            opts = opts.OverrideOptions(overrideOptions);
        }
        YtdlpVideoData videoData = null;
        YoutubeDLProcess youtubeDLProcess = new(ytdl.YoutubeDLPath);
        youtubeDLProcess.OutputReceived += (o, e) =>
        {
            if (e.Data == null) return;

            // Workaround: Fix invalid json directly
            var data = e.Data.Replace("\"[{", "[{")
                                   .Replace("}]\"", "}]")
                                   .Replace("False", "false")
                                   .Replace("True", "true");
            // Change json string from 'sth' to "sth"
            data = ChangeJsonStringSingleQuotesToDoubleQuotes().Replace(data, """
                                                                              "$1"
                                                                              """);
            videoData = Newtonsoft.Json.JsonConvert.DeserializeObject<YtdlpVideoData>(data);
        };
        var fieldInfo = typeof(YoutubeDL).GetField("runner", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField);
        var (code, errors) = await (fieldInfo!.GetValue(ytdl) as ProcessRunner)!.RunThrottled(youtubeDLProcess, [url], opts, ct);
        return new RunResult<YtdlpVideoData>(code == 0, errors, videoData);
    }
#nullable enable 

    [GeneratedRegex("(?:[\\s:\\[\\{\\(])'([^'\\r\\n\\s]*)'(?:\\s,]}\\))")]
    private static partial Regex ChangeJsonStringSingleQuotesToDoubleQuotes();
}
