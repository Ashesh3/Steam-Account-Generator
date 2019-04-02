using System;
using System.IO;
using System.Threading.Tasks;
using SteamAccCreator.Gui;

namespace SteamAccCreator.File
{
    public class FileManager
    {
        private static readonly Random Random = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (Random) // synchronize
            {
                return Random.Next(min, max);
            }
        }
        public void WriteIntoFile(string mail, bool writeMail, string alias, string pass, long steamId, string path, SaveType fwType)
        {
            Logger.Trace("Creating account: Writing to file...");
            try
            {
                Task.Delay(GetRandomNumber(100, 5000)).Wait();

                using (var writer = new StreamWriter(path, true))
                {
                    switch (fwType)
                    {
                        case SaveType.FormattedTxt:
                            {
                                Logger.Trace("Writing to file: formatted text");
                                if (writeMail)
                                    writer.WriteLine("Mail: \t\t" + mail);

                                writer.WriteLine("Alias: \t\t" + alias);
                                writer.WriteLine("Pass: \t\t" + pass);
                                writer.WriteLine("Creation: \t" + DateTime.Now);

                                if (steamId != 0)
                                    writer.WriteLine($"URL: \t\thttps://steamcommunity.com/profiles/{steamId}");

                                writer.WriteLine("###########################");
                            }
                            break;
                        case SaveType.PlainTxt:
                            {
                                Logger.Trace("Writing to file: plain text");
                                if (writeMail == false)
                                    writer.WriteLine(alias + ":" + pass);
                                else
                                    writer.WriteLine(alias + ":" + pass + ":" + mail);
                            }
                            break;
                        case SaveType.KeepassCsv:
                            {
                                Logger.Trace("Writing to file: CSV data");
                                writer.WriteLine($"{alias},{alias},{pass},https://steamcommunity.com/profiles/{steamId}/,{((writeMail) ? mail : "")}");
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Creating account: Writing to file error", ex);
            }
            Logger.Trace("Creating account: Writing to file done!");
        }
    }
}
