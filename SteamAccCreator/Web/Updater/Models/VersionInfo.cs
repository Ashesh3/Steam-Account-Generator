using Newtonsoft.Json;
using System;

namespace SteamAccCreator.Web.Updater.Models
{
    public class VersionInfo
    {
        [JsonProperty("major")]
        public int Major { get; set; } = 0;
        [JsonProperty("minor")]
        public int Minor { get; set; } = 0;
        [JsonProperty("build")]
        public int Build { get; set; } = 0;
        [JsonProperty("pre")]
        public int? PreRelease { get; set; } = null;
        [JsonProperty("notes")]
        public string ReleaseNotes { get; set; } = string.Empty;
        [JsonProperty("download")]
        public DownloadLinks Downloads { get; set; } = new DownloadLinks();

        [JsonIgnore]
        public Version Version => new Version(Major, Minor, Build, 0);
    }
}
