using Serilog;
using Serilog.Core;
using Serilog.Formatting.Display;
using Serilog.Sinks.WinForms;

namespace YoutubeSegmentDownloader;

internal static class Program
{
    public static LoggingLevelSwitch levelSwitch = new();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.ControlledBy(levelSwitch)
                        .WriteToSimpleAndRichTextBox(new MessageTemplateTextFormatter("{Message} {Exception}\n"))
                        .CreateLogger();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
