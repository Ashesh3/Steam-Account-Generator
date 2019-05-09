using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Gecko;
using SteamAccCreator.Gui;

namespace SteamAccCreator
{
    static class Program
    {
        public const string DEFAULT_URL_MAILBOX = "https://newemailsrv.now.sh/index.php";
        public const string DEFAULT_URL_UPDATE = "https://earskilla.github.io/SteamAccountGenerator-memes/update.json";

        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        /// 
        private static Mutex mutex = null;
        public static bool UseRuCaptchaDomain = false;
        public static readonly Web.Updater.UpdaterHandler UpdaterHandler = new Web.Updater.UpdaterHandler();
        public static bool GeckoInitialized = false;

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

            Logger.SuppressErrorDialogs = Utility.HasStartOption("-suppressErrors");
            Logger.SuppressAllErrorDialogs = Utility.HasStartOption("-suppressAllErrors");

            Logger.Warn(@"Coded by:
https://github.com/Ashesh3
https://github.com/EarsKilla

Latest versions will be here: https://github.com/EarsKilla/Steam-Account-Generator/releases");
#if PRE_RELEASE
            Logger.Warn($"Version: {Web.Updater.UpdaterHandler.CurrentVersion}-pre{Web.Updater.UpdaterHandler.PreRelease}");
#else
            Logger.Warn($"Version: {Web.Updater.UpdaterHandler.CurrentVersion}");
#endif

            Logger.Trace("Starting...");

            mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                Logger.Trace("Another instance is running. Shutting down...");
                return;
            }

            try
            {
                Logger.Debug("Initializing gecko/xpcom...");
                Xpcom.Initialize(Pathes.DIR_GECKO);
                GeckoInitialized = true;
                Logger.Debug("Initializing gecko/xpcom: done!");
            }
            catch (Exception ex)
            {
                Logger.Error($"Initializing gecko/xpcom: error!", ex);
            }

            UpdaterHandler.Refresh();

            UseRuCaptchaDomain = Utility.HasStartOption("-rucaptcha");
            if (UseRuCaptchaDomain)
                Logger.Info("Option '-rucaptcha' detected. Switched from 2captcha.com to rucaptcha.com");

            Web.HttpHandler.TwoCaptchaDomain = Utility.GetStartOption(@"-(two|ru)captchaDomain[:=](.*)",
                (m) => Utility.MakeUri(m.Groups[2].Value),
                new Uri((UseRuCaptchaDomain) ? "http://rucaptcha.com" : "http://2captcha.com"));

            Web.HttpHandler.CaptchasolutionsDomain = Utility.GetStartOption(@"-captchasolutionsDomain[:=](.*)",
                (m) => Utility.MakeUri(m.Groups[1].Value),
                new Uri("http://api.captchasolutions.com/"));

            Web.MailHandler.MailboxUri = Utility.GetStartOption(@"-mailBox[:=](.*)",
                (m) =>
                {
                    Web.MailHandler.IsMailBoxCustom = true;
                    return Utility.MakeUri(m.Groups[1].Value);
                },
                Web.MailHandler.MailboxUri);

            Web.MailHandler.CheckUserMailVerifyCount = Utility.GetStartOption(@"-mailUserChecks[:=](\d+)",
                (m) =>
                {
                    if (!int.TryParse(m.Groups[1].Value, out int val))
                        return Web.MailHandler.CheckUserMailVerifyCount;

                    return val;
                }, Web.MailHandler.CheckUserMailVerifyCount);
            Web.MailHandler.CheckRandomMailVerifyCount = Utility.GetStartOption(@"-mailBoxChecks[:=](\d+)",
                (m) =>
                {
                    if (!int.TryParse(m.Groups[1].Value, out int val))
                        return Web.MailHandler.CheckRandomMailVerifyCount;

                    return val;
                }, Web.MailHandler.CheckRandomMailVerifyCount);

            if (!Utility.HasStartOption("-nostyles"))
            {
                Logger.Trace("Enabling visual styles...");
                Application.EnableVisualStyles();
            }
            if (!Utility.HasStartOption("-defaultTextRendering"))
            {
                Logger.Trace($"{nameof(Application.SetCompatibleTextRenderingDefault)}(false)...");
                Application.SetCompatibleTextRenderingDefault(false);
            }
            Logger.Trace($"Starting app with {nameof(MainForm)}...");
            Application.Run(new MainForm());
        }


    }

}

