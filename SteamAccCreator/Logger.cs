using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SteamAccCreator
{
    public static class Logger
    {
        private static readonly Type FILE_TARGET_TYPE = typeof(NLog.Targets.FileTarget);

#if IS_GUI_APP
        public static bool SuppressErrorDialogs = false;
        public static bool SuppressAllErrorDialogs = false;
#else // IS_GUI_APP
        public static bool SuppressErrorConsole = false;
        public static bool SuppressAllErrorConsole = false;
#endif // IS_GUI_APP

        public static string GetCurrentStackMethod()
        {
            try
            {
                var tracePlain = Environment.StackTrace;
                var trace = tracePlain.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                var traceAt = trace.FirstOrDefault(x => Regex.IsMatch(x, $@"{Regex.Escape(nameof(SteamAccCreator))}\.(?!{Regex.Escape(nameof(Logger))}\.)\w+"));
                var at = "";
                var atRegex = Regex.Match(traceAt ?? "", @"at\s([^)]+\))", RegexOptions.IgnoreCase);
                if (atRegex.Success)
                    at = atRegex.Groups[1].Value;
                else
                    at = traceAt ?? "UNKNOWN";
                return at;
            }
            catch { return "UNKNOWN:ERR"; }
        }

        private static NLog.Logger GetLogger(string loggerName)
        {
            var logger = NLog.LogManager.GetLogger(loggerName);

            // idk why, but even if createDirs="true", it won't create directories so...
            foreach (var logTarget in logger.Factory.Configuration.AllTargets)
            {
                if (!Equals(logTarget.GetType(), FILE_TARGET_TYPE))
                    continue;

                var target = logTarget as NLog.Targets.FileTarget;
                if (target == null)
                    continue; // lol

                var file = target.FileName.Render(new NLog.LogEventInfo());
                var dir = new System.IO.FileInfo(file).Directory;
                if (!dir.Exists)
                    dir.Create();
            }

            return logger;
        }

        public static void Trace(string message)
            => Trace(GetCurrentStackMethod(), message);
        public static void Trace(string loggerName, string message)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Trace(message);
            }
#if LOGGER_TRACE
            catch (Exception ex)
            {
                var msg = $"{message}:\nError in trace:\n{ex}";
#if IS_GUI_APP
                if (SuppressErrorDialogs || SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Trace",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else // IS_GUI_APP
                if (SuppressErrorConsole || SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif // IS_GUI_APP
            }
#else // LOGGER_TRACE
            catch {}
#endif // LOGGER_TRACE
        }

        public static void Debug(string message)
            => Debug(GetCurrentStackMethod(), message);
        public static void Debug(string loggerName, string message)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Debug(message);
            }
#if LOGGER_TRACE
            catch (Exception ex)
            {
                var msg = $"{message}:\nError in debug:\n{ex}";
#if IS_GUI_APP
                if (SuppressErrorDialogs || SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Debug",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else // IS_GUI_APP
                if (SuppressErrorConsole || SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif // IS_GUI_APP
            }
#else // LOGGER_TRACE
            catch {}
#endif // LOGGER_TRACE
        }

        public static void Info(string message)
            => Info(GetCurrentStackMethod(), message);
        public static void Info(string loggerName, string message)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Info(message);
            }
#if LOGGER_TRACE
            catch (Exception ex)
            {
                var msg = $"{message}:\nError in info:\n{ex}";
#if IS_GUI_APP
                if (SuppressErrorDialogs || SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Info",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else // IS_GUI_APP
                if (SuppressErrorConsole || SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif // IS_GUI_APP
            }
#else // LOGGER_TRACE
            catch {}
#endif // LOGGER_TRACE
        }

        public static void Warn(string message)
            => Warn(GetCurrentStackMethod(), message);
        public static void Warn(string loggerName, string message)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Warn(message);
            }
#if LOGGER_TRACE
            catch (Exception ex)
            {
                var msg = $"{message}:\nError in warning:\n{ex}";
#if IS_GUI_APP
                if (SuppressErrorDialogs || SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Warn",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else // IS_GUI_APP
                if (SuppressErrorConsole || SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif // IS_GUI_APP
            }
#else // LOGGER_TRACE
            catch {}
#endif // LOGGER_TRACE
        }
        public static void Warn(string message, Exception exception)
            => Warn(GetCurrentStackMethod(), message, exception);
        public static void Warn(string loggerName, string message, Exception exception)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Warn(exception, message);
            }
            catch (Exception ex)
            {
                var msg = $"{message}:\n{exception}\n\nError in warning (lol):\n{ex}";
#if IS_GUI_APP
                if (SuppressErrorDialogs || SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Warn",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else
                if (SuppressErrorConsole || SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif
            }
        }

        public static void Error(string message, Exception exception)
            => Error(GetCurrentStackMethod(), message, exception);
        public static void Error(string loggerName, string message, Exception exception)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Error(exception, message);
            }
            catch (Exception ex)
            {
                var msg = $"{message}:\n{exception}\n\nError in error (lol):\n{ex}";
#if IS_GUI_APP
                if (SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Error",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else
                if (SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif
            }
        }

        public static void Fatal(string message, Exception exception)
            => Fatal(GetCurrentStackMethod(), message, exception);
        public static void Fatal(string loggerName, string message, Exception exception)
        {
            try
            {
                var logger = GetLogger(loggerName);
                logger?.Fatal(exception, message);
            }
            catch (Exception ex)
            {
                var msg = $"{message}:\n{exception}\n\nError in fatal (lol):\n{ex}";
#if IS_GUI_APP
                if (SuppressAllErrorDialogs)
                    return;

                System.Windows.Forms.MessageBox.Show(msg, "Fatal",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
#else
                if (SuppressAllErrorConsole)
                    return;

                Console.WriteLine(msg);
#endif
            }
        }
    }
}
