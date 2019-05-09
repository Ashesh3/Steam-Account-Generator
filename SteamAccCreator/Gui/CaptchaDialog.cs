using System;
using System.Windows.Forms;
using SteamAccCreator.Web;
using SteamAccCreator.Web.Captcha;

namespace SteamAccCreator.Gui
{
    public partial class CaptchaDialog : Form, Interfaces.ICaptchaDialog
    {
        private readonly HttpHandler _httpHandler;
        private readonly Models.Configuration Config;
        private readonly Action<string> UpdateStatus;

        private CaptchaSolution Solution;

        public CaptchaDialog(HttpHandler httpHandler, Action<string> updateStatus, Models.Configuration config)
        {
            Logger.Debug("Init. solving captcha...");

            Solution = new CaptchaSolution(false, "Something went wrong...", config.Captcha);

            _httpHandler = httpHandler;

            InitializeComponent();

            Config = config;
            UpdateStatus = updateStatus;

            LoadCaptcha();
        }

        private void DrawCaptcha()
        {
            var img = _httpHandler.GetCaptchaImageraw();
            if (img == null)
            {
                MessageBox.Show(this, "Someting went wrong with loading captcha image...", "Captcha getting error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            boxCaptcha.Image = img;
        }

        private void LoadCaptcha()
        {
            if (Config.Captcha.Enabled)
            {
                Logger.Debug("Solving captcha using services...");
                Solution = _httpHandler.SolveCaptcha(UpdateStatus, Config);
            }
            else
            {
                Logger.Debug("Solving captcha using dialog box...");
                DrawCaptcha();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DrawCaptcha();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Solution = new CaptchaSolution(txtCaptcha.Text, null, Config.Captcha);
            DialogResult = DialogResult.OK;
            Close();
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

        private void CaptchaDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing &&
                DialogResult != DialogResult.OK)
            {
                Solution = new CaptchaSolution(false, "You closed captcha dialog box.", Config.Captcha);
                DialogResult = DialogResult.Cancel;
            }
        }

        public DialogResult ShowDialog(out CaptchaSolution solution)
        {
            var result = this.ShowDialog();
            solution = this.Solution;
            return result;
        }
    }
}
