using System;
using System.Windows.Forms;
using SteamAccCreator.Web;

namespace SteamAccCreator.Gui
{
    public partial class CaptchaDialog : Form
    {
        private readonly HttpHandler _httpHandler;
        private readonly Models.CaptchaSolvingConfig Config;

        public string[] Solution = new string[0];

        public CaptchaDialog(HttpHandler httpHandler, ref string _status, Models.CaptchaSolvingConfig config)
        {
            _httpHandler = httpHandler;

            InitializeComponent();

            LoadCaptcha(ref _status, Config = config);
        }

        private void LoadCaptcha(ref string _status, Models.CaptchaSolvingConfig config)
        {
            if (config.Enabled)
                Solution = _httpHandler.GetCaptchaImage(ref _status, config);
            else
                boxCaptcha.Image = _httpHandler.GetCaptchaImageraw();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s = "";
            LoadCaptcha(ref s, Config);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
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
    }
}
