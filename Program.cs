using Serilog;
using Serilog.Formatting.Display;
using Serilog.Sinks.WinForms;

namespace YoutubeSegmentDownloader;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
                        .WriteToSimpleAndRichTextBox(new MessageTemplateTextFormatter("{Message} {Exception}\n"))
                        .CreateLogger();

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
