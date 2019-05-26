using SACModuleBase;
using SACModuleBase.Models;
using SACModuleBase.Models.Capcha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleModule
{
    public class ImageCaptcha : ISACHandlerCaptcha
    {
        public bool ModuleEnabled { get; set; } = true;
        public string ModuleName => "Sample image captcha";
        public Version ModuleVersion => new Version("1.0.0.0");

        public void ModuleInitialize(SACInitialize initialize) { }

        public CaptchaResponse Solve(CaptchaRequest request)
        {
            var ss = new SACModuleBase.Models.SACInitialize()
            {
                ConfigurationPath = ""
            };
            throw new NotImplementedException();
        }
    }
}
