using Microsoft.Win32;
using Serilog;
using Serilog.Core;
using Serilog.Formatting.Display;
using Serilog.Sinks.WinForms.Base;

namespace YoutubeSegmentDownloader;

internal static class Program
{
    public static LoggingLevelSwitch LevelSwitch = new();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.ControlledBy(LevelSwitch)
                        .WriteTo.File(path: Path.Combine(Path.GetTempPath(), $"{Application.ProductName?.Replace(" ", "")}.log"),
                                      rollingInterval: RollingInterval.Day,
                                      outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj} {NewLine}{Exception}")
                        .WriteToSimpleAndRichTextBox(new MessageTemplateTextFormatter("{Message} {Exception}\n"))
                        .CreateLogger();

        Task.Run(SetAddRemoveProgramsIcon);

        try
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Program terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
    private static void SetAddRemoveProgramsIcon()
    {
        //if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
        {
            try
            {
                var iconSourcePath = Path.Combine(Application.StartupPath, @"YoutubeSegmentDownloader.ico");

                if (!File.Exists(iconSourcePath)) return;

                var uninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                if (uninstallKey == null) return;

                var subKeyNames = uninstallKey.GetSubKeyNames();
                foreach (var subKeyName in subKeyNames)
                {
                    var myKey = uninstallKey.OpenSubKey(subKeyName, true);
                    var myValue = myKey.GetValue("DisplayName");
                    if (myValue == null || myValue.ToString() != "Youtube Segment Downloader") continue;

                    myKey.SetValue("DisplayIcon", iconSourcePath);
                    break;
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
            }
        }
    }
#pragma warning restore CS8602 // 可能 null 參考的取值 (dereference)。
}
