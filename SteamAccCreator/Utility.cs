using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SteamAccCreator
{
    public static class Utility
    {
        private static readonly Random _Random = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (_Random) // synchronize
            {
                return _Random.Next(min, max);
            }
        }

        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = "";
            for (int i = 0; i < length; i++)
            {
                result += chars.RandomElement();
            }
            return result;
        }

        public static string CutFilePath(string path, int maxLength)
        {
            if (string.IsNullOrEmpty(path))
                return "/null";

            if (maxLength < 10)
                return path;

            var fileName = Path.GetFileNameWithoutExtension(path);
            var fileExt = Path.GetExtension(path);
            var fileDir = Path.GetDirectoryName(path);

            var _maxLen = maxLength - fileExt.Count() - 6;
            var _maxDirLen = (fileDir.Length > 4) ? (int)Math.Ceiling(_maxLen - (_maxLen * 0.35)) : fileDir.Length;
            var _maxFileLen = (fileName.Length > 3) ? _maxLen - _maxDirLen : fileName.Length;

            var _isDirOk = _maxDirLen + 3 < fileDir.Length;
            var _isFileOk = _maxFileLen + 3 < fileName.Length;

            var _dirPart1 = (_isDirOk) ? new string(fileDir.Take((int)Math.Ceiling(_maxDirLen / 2m)).ToArray()) : fileDir;
            var _dirPart2 = (_isDirOk) ? new string(fileDir.Reverse().Take((int)Math.Ceiling(_maxDirLen / 2m)).Reverse().ToArray()) : "";

            var _filePart1 = (_isFileOk) ? new string(fileName.Take((int)Math.Ceiling(_maxFileLen / 2m)).ToArray()) : fileName;
            var _filePart2 = (_isFileOk) ? new string(fileName.Reverse().Take((int)Math.Ceiling(_maxFileLen / 2m)).Reverse().ToArray()) : "";

            var _dir = (_isDirOk) ? $"{_dirPart1}...{_dirPart2}" : _dirPart1;
            var _file = $"{((_isFileOk) ? $"{_filePart1}...{_filePart2}" : _filePart1)}{fileExt}";

            return Path.Combine(_dir, _file);
        }

        public static bool HasStartOption(string option)
            => Environment.GetCommandLineArgs().Any(x => x?.ToLower() == option.ToLower());

        public static T GetStartOption<T>(string pattern, Func<Match, T> formatFunc, T defaultValue = default(T))
        {
            if (formatFunc == null)
                return defaultValue;

            var args = Environment.GetCommandLineArgs();
            foreach (var arg in args)
            {
                var regex = Regex.Match(arg, pattern, RegexOptions.IgnoreCase);
                if (!regex.Success)
                    continue;

                return formatFunc.Invoke(regex);
            }

            return defaultValue;
        }

        public static Uri MakeUri(string url)
        {
            if (Regex.IsMatch(url, @"https?\:\/\/(.*)", RegexOptions.IgnoreCase))
                return new Uri(url);
            else
                return new Uri($"http://{url}");
        }

        public static T RandomElement<T>(this IEnumerable<T> collection)
        {
            if ((collection?.Count() ?? 0) < 1)
                return default(T);
            else if (collection.Count() == 1)
                return collection.First();

            return collection.ElementAt(GetRandomNumber(0, collection.Count() - 1));
        }

        public static string ToTitleCase(this string text)
            => new CultureInfo("en-US").TextInfo.ToTitleCase(text);

        public static void UpdateItems<T>(this System.Windows.Forms.ListBox listBox, IEnumerable<T> collection)
        {
            listBox.Items.Clear();
            listBox.Items.AddRange(collection);
        }
        public static void AddRange<T>(this System.Windows.Forms.ListBox.ObjectCollection objectCollection, IEnumerable<T> collection)
            => objectCollection.AddRange(collection.Select(x => x as object).ToArray());

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        public static string GetVisualPath(this Models.OutputConfig config)
            => CutFilePath(config?.Path, 64);

        public static bool ValidateDirectory(string path)
        {
            var invalidSymbols = Path.GetInvalidPathChars();
            return !(path?.Any(x => invalidSymbols.Any(s => x == s)) ?? true);
        }

        public static void MkDirs(params string[] dirPathes)
        {
            foreach (var dirPath in dirPathes ?? new string[0])
            {
                if (!ValidateDirectory(dirPath))
                {
                    Logger.Warn($"Directory path \"{dirPath ?? "NULL"}\" contains invalid chars...");
                    continue;
                }

                try
                {
                    if (!Directory.Exists(dirPath))
                        Directory.CreateDirectory(dirPath);
                }
                catch (Exception ex)
                {
                    Logger.Error($"Directory \"{dirPath ?? "NULL"}\" check/creating error!", ex);
                }
            }
        }
    }
}
