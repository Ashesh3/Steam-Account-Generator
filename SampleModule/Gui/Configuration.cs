using SACModuleBase;
using SACModuleBase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleModule.Gui
{
    [Guid("5C8E14BD-6105-475A-81D0-B59AB56B186A")]
    public partial class Configuration : Form, ISACUserInterface
    {
        private ConfigManager<Models.MailConfig> ConfigMail;
        private ConfigManager<Models.CaptchaConfig> ConfigCaptcha;

        public Configuration()
        {
            InitializeComponent();
        }

        public string ShowButtonCaption => "Config";
        public bool ModuleEnabled { get; set; } = true;
        public string ModuleName => "SampleModule: config UI";
        public Version ModuleVersion => new Version("1.3.3.7");

        public void ModuleInitialize(SACInitialize initialize)
        {
            ConfigMail = new ConfigManager<Models.MailConfig>(initialize.ConfigurationPath, "mail.json",
                new Models.MailConfig(), Misc.MailBoxConfigSync);
            ConfigCaptcha = new ConfigManager<Models.CaptchaConfig>(initialize.ConfigurationPath, "captcha.json",
                new Models.CaptchaConfig(), Misc.CaptchaConfigSync);
        }

        public void ShowWindow()
        {
            ConfigMail.Load();
            ConfigCaptcha.Load();

            BsMail.DataSource = ConfigMail.Running;
            BsCaptcha.DataSource = ConfigCaptcha.Running;

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
