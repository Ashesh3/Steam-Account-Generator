using RestSharp;
using System;

namespace SteamAccCreator.Web.Updater
{
    public class UpdaterHandler
    {
        public static readonly Version CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
#if PRE_RELEASE
        public static readonly int PreRelease = 5;
#endif

        public UpdateInfo UpdateInfo { get; private set; } = new UpdateInfo();
        public Enums.UpdateChannelEnum UpdateChannel { get; private set; }
#if PRE_RELEASE
            = Enums.UpdateChannelEnum.PreRelease;
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
                    case Enums.UpdateChannelEnum.PreRelease:
                        return UpdateInfo.Channels.PreRelese;
                    default:
#if PRE_RELEASE
                        goto case Enums.UpdateChannelEnum.PreRelease;
#else
                        goto case Enums.UpdateChannelEnum.Stable;
#endif
                }
            }
        }

        public bool IsCanBeUpdated
        {
            get
            {
                switch (UpdateChannel)
                {
                    case Enums.UpdateChannelEnum.Stable:
                        return VersionInfo.Version > CurrentVersion;
                    case Enums.UpdateChannelEnum.PreRelease:
#if PRE_RELEASE
                        return VersionInfo.Version >= CurrentVersion && VersionInfo.PreRelease > PreRelease;
#else
                        return VersionInfo.Version >= CurrentVersion && VersionInfo.PreRelease.HasValue;
#endif
                    default:
#if PRE_RELEASE
                        goto case Enums.UpdateChannelEnum.PreRelease;
#else
                        goto case Enums.UpdateChannelEnum.Stable;
#endif
                }
            }
        }

        public void Refresh(Enums.UpdateChannelEnum updateChannel = Enums.UpdateChannelEnum.Stable)
        {
            UpdateChannel = updateChannel;

            try
            {
                var client = new RestClient(Program.DEFAULT_URL_UPDATE);
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
