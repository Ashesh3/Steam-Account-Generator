using SACModuleBase.Enums.Captcha;

namespace SACModuleBase.Models.Capcha
{
    public class CaptchaResponse
    {
        public CaptchaStatus Status { get; private set; } = CaptchaStatus.Failed;
        public string Solution { get; private set; }
        public string Message { get; private set; }
        public object Identify { get; private set; }

        public CaptchaResponse(CaptchaStatus status, string message, object identify) : this(status, message)
        {
            Identify = identify;
        }
        public CaptchaResponse(CaptchaStatus status, string message)
        {
            Status = status;
            Message = message;
        }
        public CaptchaResponse(string solution, object identify) : this(solution)
        {
            Identify = identify;
        }
        public CaptchaResponse(string solution)
        {
            Status = CaptchaStatus.Success;
            Solution = solution;
        }
    }
}
