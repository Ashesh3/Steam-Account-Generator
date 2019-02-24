using System;
using System.IO;
using System.Threading.Tasks;
using SteamAccCreator.Gui;

namespace SteamAccCreator.File
{
    public class FileManager
    {
        private static readonly Random Random = new Random();

        public enum FileWriteType
        {
            Original,
            Detailed,
            KeePassCSV
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (Random) // synchronize
            {
                return Random.Next(min, max);
            }
        }
        public void WriteIntoFile(string mail, bool writeMail, string alias, string pass, long steamId, string path, FileWriteType fwType)
        {
            try
            {
                Task.Delay(GetRandomNumber(100, 5000)).Wait();

                using (var writer = new StreamWriter(path, true))
                {
                    switch (fwType)
                    {
                        case FileWriteType.Detailed:
                            {
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
                        case FileWriteType.Original:
                            {
                                if (writeMail == false)
                                    writer.WriteLine(alias + ":" + pass);
                                else
                                    writer.WriteLine(alias + ":" + pass + ":" + mail);
                            }
                            break;
                        case FileWriteType.KeePassCSV:
                            {
                                writer.WriteLine($"{alias},{alias},{pass},https://steamcommunity.com/profiles/{steamId}/,{((writeMail) ? mail : "")}");
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
