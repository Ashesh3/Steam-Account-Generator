using RestSharp;
using System;

namespace SteamAccCreator.Web.Updater
{
    public class UpdaterHandler
    {
        private const string DEFAULT_URL_UPDATE = "https://earskilla.github.io/SteamAccountGenerator-memes/update.json";

        public static readonly Version CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

        public UpdateInfo UpdateInfo { get; private set; } = new UpdateInfo();
        public Enums.UpdateChannelEnum UpdateChannel { get; private set; }
#if DEV_RELEASE
            = Enums.UpdateChannelEnum.DevRelease;
#else
            = Enums.UpdateChannelEnum.Stable;
#endif
        public Models.VersionInfo VersionInfo
        {
            get
            {
                switch (UpdateChannel)
                {
                    case Enums.UpdateChannelEnum.Stable:
                        return UpdateInfo.Channels.Stable;
                    case Enums.UpdateChannelEnum.DevRelease:
                        return UpdateInfo.Channels.PreRelese;
                    default:
#if DEV_RELEASE
                        goto case Enums.UpdateChannelEnum.DevRelease;
#else
                        goto case Enums.UpdateChannelEnum.Stable;
#endif
                }
            }
        }

        public bool IsCanBeUpdated => VersionInfo.Version > CurrentVersion;

        public void Refresh(Enums.UpdateChannelEnum updateChannel = Enums.UpdateChannelEnum.Stable)
        {
            UpdateChannel = updateChannel;

            try
            {
                var client = new RestClient(DEFAULT_URL_UPDATE);
                var request = new RestRequest(Method.GET);
                var response = client.Execute(request);
                if (!response.IsSuccessful)
                    return;

                UpdateInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<UpdateInfo>(response.Content);

                if (!MailHandler.IsMailBoxCustom)
                {
                    try
                    {
                        var mailBoxUri = new Uri(UpdateInfo.Misc.MailBoxUrl);
                        MailHandler.MailboxUri = mailBoxUri;
                    }
                    catch { Logger.Warn($"Mail box URL is broken. URL: {UpdateInfo.Misc.MailBoxUrl}"); }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Updater error", ex);
            }
        }
    }
}
