using System;
using System.Windows.Forms;
using SteamAccCreator.Web;

namespace SteamAccCreator.Gui
{
    public partial class CaptchaDialog : Form
    {
        private readonly HttpHandler _httpHandler;
        private readonly Models.CaptchaSolvingConfig Config;

        public Web.Captcha.CaptchaSolution Solution;

        public CaptchaDialog(HttpHandler httpHandler, Action<string> updateStatus, Models.CaptchaSolvingConfig config)
        {
            Logger.Debug("Init. solving captcha...");

            Solution = new Web.Captcha.CaptchaSolution(false, "Something went wrong...", config);

            _httpHandler = httpHandler;

            InitializeComponent();

            LoadCaptcha(updateStatus, Config = config);
        }

        private void LoadCaptcha(Action<string> updateStatus, Models.CaptchaSolvingConfig config)
        {
            if (config.Enabled)
            {
                Logger.Debug("Solving captcha using services...");
                Solution = _httpHandler.SolveCaptcha(updateStatus, config);
            }
            else
            {
                Logger.Debug("Solving captcha using dialog box...");
                boxCaptcha.Image = _httpHandler.GetCaptchaImageraw();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            boxCaptcha.Image = _httpHandler.GetCaptchaImageraw();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Solution = new Web.Captcha.CaptchaSolution(txtCaptcha.Text, null, Config);
            DialogResult = DialogResult.OK;
            Close();
            Logger.Debug($"Captcha solution: {Solution.Solution}");
        }

        private void TxtCaptcha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnConfirm_Click(sender, e);
        }

        private void TxtCaptcha_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
