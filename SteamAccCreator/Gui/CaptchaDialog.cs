using System;
using System.Windows.Forms;
using SteamAccCreator.Web;

namespace SteamAccCreator.Gui
{
    public partial class CaptchaDialog : Form
    {
        public string[] ans;
        public bool autox;
        private readonly HttpHandler _httpHandler;
        public CaptchaDialog(HttpHandler httpHandler, ref string _status,bool auto = false,bool twocap = false)
        {
            InitializeComponent();
            autox = auto;
            _httpHandler = httpHandler;
            if(twocap)
                LoadCaptcha(auto, ref _status,true);
            else
                LoadCaptcha(auto, ref _status, false);
        }

        private void LoadCaptcha(bool auto,ref string _status,bool usetwocap = false)
        {

            if (!auto)
            {
                boxCaptcha.Image = _httpHandler.GetCaptchaImageraw();
            }
            else
            {
               if(usetwocap)
                    ans = _httpHandler.GetCaptchaImage(ref _status,true);
               else
                    ans = _httpHandler.GetCaptchaImage(ref _status);
            }
            //boxCaptcha.Image = _httpHandler.GetCaptchaImage();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string s="";
            LoadCaptcha(autox,ref s);
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
