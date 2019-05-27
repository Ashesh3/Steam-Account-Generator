using SACModuleBase;
using SACModuleBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleModule.Gui
{
    public partial class Configuration : Form, ISACUserInterface
    {
        private ConfigManager<Models.MailConfig> ConfigMail;
        private ConfigManager<Models.CaptchaConfig> ConfigCaptcha;

        public Configuration()
        {
            InitializeComponent();
        }

        public string ShowButtonCaption => throw new NotImplementedException();

        public bool ModuleEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string ModuleName => throw new NotImplementedException();

        public Version ModuleVersion => throw new NotImplementedException();

        public void ModuleInitialize(SACInitialize initialize)
        {
            ConfigMail = new ConfigManager<Models.MailConfig>(initialize.ConfigurationPath, "mail.json",
                new Models.MailConfig(), Misc.MailBoxConfigSync);
            ConfigCaptcha = new ConfigManager<Models.CaptchaConfig>(initialize.ConfigurationPath, "captcha.json",
                new Models.CaptchaConfig(), Misc.CaptchaConfigSync);

            BsMail.DataSource = ConfigMail.Running;
            BsCaptcha.DataSource = ConfigCaptcha.Running;
        }

        public void ShowWindow()
        {
            ConfigMail.Load();
            ConfigCaptcha.Load();

            Monitor.Enter(Misc.CaptchaConfigSync);
            Monitor.Enter(Misc.MailBoxConfigSync);
            var dialogResult = this.ShowDialog();
            Monitor.Exit(Misc.CaptchaConfigSync);
            Monitor.Exit(Misc.MailBoxConfigSync);

            if (dialogResult == DialogResult.OK)
            {
                ConfigMail.Save();
                ConfigCaptcha.Save();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
