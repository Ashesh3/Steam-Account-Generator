using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace SACModuleBase.Models
{
    public class ConfigManager<T>
    {
        private object Sync;

        private T _Running = default(T);
        public T Running
        {
            get
            {
                lock (Sync)
                    return _Running;
            }
            set
            {
                lock (Sync)
                    _Running = value;
            }
        }

        public T Default { get; private set; }
        public string DirectoryPath { get; private set; }
        public string FileName { get; private set; }
        public string FullPath => Path.Combine(DirectoryPath, FileName);

        public ConfigManager(string directory, string fileName) : this(directory, fileName, default(T), null) { }
        public ConfigManager(string directory, string fileName, T defaultConfig) : this(directory, fileName, defaultConfig, null) { }
        public ConfigManager(string directory, string fileName, T defaultConfig, object syncObject)
        {
            DirectoryPath = directory;
            FileName = fileName;
            Default = _Running = defaultConfig;
            Sync = syncObject ?? new object();
        }

        public bool Load()
        {
            lock (Sync)
            {
                try
                {
                    if (!File.Exists(FullPath))
                        return false;

                    var plainJson = File.ReadAllText(FullPath);
                    _Running = JsonConvert.DeserializeObject<T>(plainJson);

                    return true;
                }
                catch (Exception ex)
                {
                    if (Debugger.IsAttached)
                        throw ex;
                }
            }

            return false;
        }

        public void Save()
        {
            lock (Sync)
            {
                if (Equals(_Running, default(T)))
                    return;

                var plainJson = JsonConvert.SerializeObject(_Running, Formatting.Indented);
                try
                {
                    File.WriteAllText(FullPath, plainJson);
                }
                catch (Exception ex)
                {
                    if (Debugger.IsAttached)
                        throw ex;
                }
            }
        }
    }
}
