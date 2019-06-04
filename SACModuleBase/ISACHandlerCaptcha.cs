using SACModuleBase.Models.Capcha;

namespace SACModuleBase
{
    public interface ISACHandlerCaptcha : ISACBase
    {
        CaptchaResponse Solve(CaptchaRequest request);
    }
}
