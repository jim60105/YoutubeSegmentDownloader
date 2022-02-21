using Microsoft.Win32;
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

        Task.Run(SetAddRemoveProgramsIcon);

        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }

#pragma warning disable CS8602 // 可能 null 參考的取值 (dereference)。
    private static void SetAddRemoveProgramsIcon()
    {
        //if (ApplicationDeployment.IsNetworkDeployed && ApplicationDeployment.CurrentDeployment.IsFirstRun)
        {
            try
            {
                var iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, @"YoutubeSegmentDownloader.ico");

                if (!File.Exists(iconSourcePath)) return;

                var uninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                if (uninstallKey == null) return;

                var subKeyNames = uninstallKey.GetSubKeyNames();
                foreach (var subkeyName in subKeyNames)
                {
                    var myKey = uninstallKey.OpenSubKey(subkeyName, true);
                    var myValue = myKey.GetValue("DisplayName");
                    if (myValue != null 
                        && myValue.ToString() == "Youtube Segment Downloader")
                    {
                        myKey.SetValue("DisplayIcon", iconSourcePath);
                        break;
                    }
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

