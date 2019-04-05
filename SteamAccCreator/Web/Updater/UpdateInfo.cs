using Newtonsoft.Json;

namespace SteamAccCreator.Web.Updater
{
    public class UpdateInfo
    {
        [JsonProperty("updates")]
        public Models.Updates Channels { get; set; } = new Models.Updates();
        [JsonProperty("misc")]
        public Models.Misc Misc { get; set; } = new Models.Misc();
    }
}
