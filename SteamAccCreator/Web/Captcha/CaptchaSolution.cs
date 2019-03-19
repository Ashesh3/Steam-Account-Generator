namespace SteamAccCreator.Web.Captcha
{
    public class CaptchaSolution
    {
        public bool Solved { get; private set; }
        public bool RetryAvailable { get; private set; }
        public string Message { get; private set; }
        public string Solution { get; private set; }
        public string Id { get; private set; }
        public Models.CaptchaSolvingConfig Config { get; private set; }

        public CaptchaSolution(string solution, string id, Models.CaptchaSolvingConfig config) : this(true, false, null, solution, id, config) { }
        public CaptchaSolution(bool retryAvailable, string message, Models.CaptchaSolvingConfig config) : this(false, retryAvailable, message, null, null, config) { }
        public CaptchaSolution(bool solved, bool retryAvailable, string message, string solution, string id, Models.CaptchaSolvingConfig config)
        {
            Solved = solved;
            RetryAvailable = retryAvailable;
            Message = message ?? string.Empty;
            Solution = solution ?? string.Empty;
            Id = id ?? string.Empty;
            Config = Config;
        }
    }
}
