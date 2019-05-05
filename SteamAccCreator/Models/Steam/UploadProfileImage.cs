using Newtonsoft.Json;

namespace SteamAccCreator.Models.Steam
{
    public class UploadProfileImage
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
