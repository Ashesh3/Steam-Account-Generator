using System;

namespace SteamAccCreator.Models
{
    public class OutputConfig
    {
        public bool Enabled { get; set; }
        public bool WriteEmails { get; set; }
        public File.SaveType SaveType { get; set; }
        public string Path { get; set; } = System.IO.Path.Combine(Environment.CurrentDirectory, "accounts.txt");
    }
}
