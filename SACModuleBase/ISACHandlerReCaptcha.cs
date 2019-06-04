using SACModuleBase.Models.Capcha;

namespace SACModuleBase
{
    public interface ISACHandlerReCaptcha : ISACBase
    {
        CaptchaResponse Solve(ReCaptchaRequest request);
    }
}
