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
        public void WriteIntoFile(string mail, bool writeMail, string alias, string pass, string path, bool original)
        {

        try
        { 

            Task.Delay(GetRandomNumber(100, 5000)).Wait();

            using (var writer = new StreamWriter(path, true))
            {
                if (original == true)
                {
                    if (writeMail == false)
                    {
                        writer.WriteLine(alias + ":" + pass);
                    }
                    else
                    {
                        writer.WriteLine(alias + ":" + pass + ":" + mail);
                    }
                }
                else if (original == false)
                {
                    if (writeMail == false)
                    {
                        writer.WriteLine("Alias: \t\t" + alias);
                        writer.WriteLine("Pass: \t\t" + pass);
                        writer.WriteLine("Creation: \t" + DateTime.Now);
                        writer.WriteLine("###########################");
                    }
                    else
                    {
                        writer.WriteLine("Mail: \t\t" + mail);
                        writer.WriteLine("Alias: \t\t" + alias);
                        writer.WriteLine("Pass: \t\t" + pass);
                        writer.WriteLine("Creation: \t" + DateTime.Now);
                        writer.WriteLine("###########################");
                    }
                }
            }
        }catch(Exception)
            {

            }
     }
    }
}
