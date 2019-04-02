using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SteamAccCreator.Gui;

namespace SteamAccCreator
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 
        private static Mutex mutex = null;
        public static bool UseRuCaptchaDomain = false;
        [STAThread]
        static void Main()
        {
            const string appName = "StmAccGen";
            bool createdNew;

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.IsTerminating)
                    Logger.Fatal("FATAL_UNHANDLED_EXCEPTION", e.ExceptionObject as Exception);
                else
                    Logger.Error("UNHANDLED_EXCEPTION", e.ExceptionObject as Exception);
            };
            AppDomain.CurrentDomain.FirstChanceException += (s, e)
                => Logger.Warn("FIRST_CHANCE_EXCEPTION", e.Exception);
#endif

            Logger.SuppressErrorDialogs = HasStartOption("-suppressErrors");
            Logger.SuppressAllErrorDialogs = HasStartOption("-suppressAllErrors");

            Logger.Warn(@"Coded by:
https://github.com/Ashesh3
https://github.com/EarsKilla

Latest versions will be here: https://github.com/EarsKilla/Steam-Account-Generator/releases");

            Logger.Trace("Starting...");

            mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                Logger.Trace("Another instance is running. Shutting down...");
                return;
            }

            UseRuCaptchaDomain = HasStartOption("-rucaptcha");
            if (UseRuCaptchaDomain)
                Logger.Info("Option '-rucaptcha' detected. Switched from 2captcha.com to rucaptcha.com");

            if (!HasStartOption("-nostyles"))
            {
                Logger.Trace("Enabling visual styles...");
                Application.EnableVisualStyles();
            }
            if (!HasStartOption("-defaultTextRendering"))
            {
                Logger.Trace($"{nameof(Application.SetCompatibleTextRenderingDefault)}(false)...");
                Application.SetCompatibleTextRenderingDefault(false);
            }
            Logger.Trace($"Starting app with {nameof(MainForm)}...");
            Application.Run(new MainForm());
        }

        private static bool HasStartOption(string option)
            => Environment.GetCommandLineArgs().Any(x => x?.ToLower() == option.ToLower());
    }

}

