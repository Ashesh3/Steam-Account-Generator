using System;

namespace SteamAccCreator.Defaults
{
    public partial class Web
    {
        public const string STEAM_JOIN_ADDRESS = "https://store.steampowered.com/join/";
        public static readonly Uri STEAM_JOIN_URI = new Uri(STEAM_JOIN_ADDRESS);

        public const string STEAM_RENDER_CAPTCHA_ADDRESS = "https://store.steampowered.com/login/rendercaptcha";

        public const string STEAM_AJAX_VERIFY_EMAIL_ADDRESS = STEAM_JOIN_ADDRESS + "ajaxverifyemail";
        public static readonly Uri STEAM_AJAX_VERIFY_EMAIL_URI = new Uri(STEAM_AJAX_VERIFY_EMAIL_ADDRESS);

        public const string STEAM_AJAX_CHECK_VERIFIED_ADDRESS = STEAM_JOIN_ADDRESS + "ajaxcheckemailverified";
        public static readonly Uri STEAM_AJAX_CHECK_VERIFIED_URI = new Uri(STEAM_AJAX_CHECK_VERIFIED_ADDRESS);

        public const string STEAM_CHECK_AVAILABLE_ADDRESS = STEAM_JOIN_ADDRESS + "checkavail";
        public static readonly Uri STEAM_CHECK_AVAILABLE_URI = new Uri(STEAM_CHECK_AVAILABLE_ADDRESS);

        public const string STEAM_CHECK_AVAILABLE_PASSWORD_ADDRESS = STEAM_JOIN_ADDRESS + "checkpasswordavail";
        public static readonly Uri STEAM_CHECK_AVAILABLE_PASSWORD_URI = new Uri(STEAM_CHECK_AVAILABLE_PASSWORD_ADDRESS);

        public const string STEAM_CREATE_ACCOUNT_ADDRESS = STEAM_JOIN_ADDRESS + "createaccount";
        public static readonly Uri STEAM_CREATE_ACCOUNT_URI = new Uri(STEAM_CREATE_ACCOUNT_ADDRESS);

        public const string STEAM_ACCOUNT_VERIFY_ADDRESS = "https://store.steampowered.com/account/newaccountverification";
        public static readonly Uri STEAM_ACCOUNT_VERIFY_URI = new Uri(STEAM_ACCOUNT_VERIFY_ADDRESS);
    }
}
