using Newtonsoft.Json;

namespace SteamAccCreator.Web.Updater.Models
{
    public class Updates
    {
        [JsonProperty("stable")]
        public VersionInfo Stable { get; set; } = new VersionInfo();
        [JsonProperty("pre")]
        public VersionInfo PreRelese { get; set; } = new VersionInfo();
    }
}
