using Newtonsoft.Json;

namespace SteamAccCreator.Web.Updater.Models
{
    public class DownloadLinks
    {
        [JsonProperty("windows")]
        public string Windows { get; set; } = string.Empty;
    }
}
