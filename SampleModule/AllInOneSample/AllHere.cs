using SACModuleBase;
using SACModuleBase.Attributes;
using SACModuleBase.Models;
using SACModuleBase.Models.Capcha;
using SACModuleBase.Models.Mail;
using System.Collections.Generic;

namespace SampleModule.AllInOneSample
{
    [SACModuleInfo("4C51DE5C-C702-40F2-8701-15F7F3C4F8B3", "All in one sample", "13.37")]
    public class AllHere : ISACHandlerMailBox, ISACHandlerCaptcha, ISACHandlerReCaptcha, ISACUserInterface
    {
        /* Notes
         * 
         * As you can understand, you can separate all classes
         * and merge all in one class like this. You just need to remove
         * SACModuleInfo from another classes and if you want his
         * interface. From now it will work in one module.
         * 
         * But i don't recomend to do this. Because user can't disable
         * part of module. For example: user want to use only custom
         * mail box, but don't want to use captcha solver.
         * So this class only for example that it is possible.
         */

        private Gui.Configuration GuiConfiguration;
        private MailBox MailBox;
        private ImageCaptcha ImageCaptcha;
        private ReCaptcha ReCaptcha;

        public bool ModuleEnabled { get; set; } = true;

        public void ModuleInitialize(SACInitialize initialize)
        {
            GuiConfiguration = new Gui.Configuration();
            GuiConfiguration.ModuleInitialize(initialize);

            MailBox = new MailBox();
            MailBox.ModuleInitialize(initialize);

            ImageCaptcha = new ImageCaptcha();
            ImageCaptcha.ModuleInitialize(initialize);

            ReCaptcha = new ReCaptcha();
            ReCaptcha.ModuleInitialize(initialize);
        }

        public string ShowButtonCaption => GuiConfiguration?.ShowButtonCaption ?? "Init...";
        public void ShowWindow()
            => GuiConfiguration?.ShowWindow();

        public MailBoxResponse GetMailBox(MailBoxRequest request)
            => MailBox?.GetMailBox(request);
        public IReadOnlyCollection<MailBoxMailItem> GetMails(MailBoxResponse response)
            => MailBox?.GetMails(response);

        public CaptchaResponse Solve(CaptchaRequest request)
            => ImageCaptcha?.Solve(request);

        public CaptchaResponse Solve(ReCaptchaRequest request)
            => ReCaptcha?.Solve(request);
    }
}
