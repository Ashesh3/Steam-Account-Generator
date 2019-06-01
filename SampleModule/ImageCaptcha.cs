using SACModuleBase;
using SACModuleBase.Attributes;
using SACModuleBase.Models;
using SACModuleBase.Models.Capcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SampleModule
{
    [SACModuleInfo("17442A38-3A1D-4AF0-A677-ECF5BAF36DC0", "Sample image captcha", "1.0.0.0")]
    public class ImageCaptcha : ISACHandlerCaptcha
    {
        public bool ModuleEnabled { get; set; } = true;

        private ConfigManager<Models.CaptchaConfig> Config;

        public void ModuleInitialize(SACInitialize initialize)
        {
            Config = new ConfigManager<Models.CaptchaConfig>(initialize.ConfigurationPath, "captcha.json",
                new Models.CaptchaConfig(), Misc.CaptchaConfigSync);
        }

        public CaptchaResponse Solve(CaptchaRequest request)
        {
            if (!Config.Load())
            {
                Config.Save();
                return new CaptchaResponse(SACModuleBase.Enums.Captcha.CaptchaStatus.CannotSolve, "Config load error");
            }

            var _params = new Dictionary<string, object>()
            {
                { "key", Config?.Running?.ApiKey ?? "" },
                { "soft_id", "2370" },
                { "json", "0" },
                { "method", "base64" },
                { "body", $"data:image/jpg;base64,{request.CaptchaImage}" }
            };

            var _captchaIdResponse = Misc.TwoCaptcha("in.php", _params);
            var _captchaStatus = _captchaIdResponse?.FirstOrDefault()?.ToUpper() ?? "UNKNOWN";
            switch (_captchaStatus)
            {
                case "OK":
                    break;
                case "ERROR_NO_SLOT_AVAILABLE":
                    Thread.Sleep(6000);
                    return new CaptchaResponse(SACModuleBase.Enums.Captcha.CaptchaStatus.RetryAvailable, _captchaStatus, null);
                default:
                    return new CaptchaResponse(SACModuleBase.Enums.Captcha.CaptchaStatus.Failed, _captchaStatus, null);
            }

            var _captchaId = _captchaIdResponse.ElementAt(1);
            Thread.Sleep(TimeSpan.FromSeconds(20));

            var solution = string.Empty;
            for (int i = 0; i < 3; i++)
            {
                var _captchaResponse = Misc.TwoCaptcha("res.php",
                    new Dictionary<string, object>()
                    {
                                    { "key", Config?.Running?.ApiKey ?? "" },
                                    { "action", "get" },
                                    { "id", _captchaId },
                                    { "json", "0" },
                    });

                var _status = _captchaResponse?.FirstOrDefault()?.ToUpper() ?? "UNKNOWN";
                switch (_status)
                {
                    case "OK":
                        return new CaptchaResponse(_captchaResponse.ElementAt(1), _captchaId);
                    case "CAPCHA_NOT_READY":
                    case "ERROR_NO_SLOT_AVAILABLE":
                        Thread.Sleep(6000);
                        continue;
                    default:
                        return new CaptchaResponse(SACModuleBase.Enums.Captcha.CaptchaStatus.RetryAvailable, _status);
                }
            }

            return new CaptchaResponse(SACModuleBase.Enums.Captcha.CaptchaStatus.CannotSolve, "Something went wrong...");
        }
    }
}
