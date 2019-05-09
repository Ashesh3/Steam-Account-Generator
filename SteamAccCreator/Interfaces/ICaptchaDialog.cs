using System;
using System.Windows.Forms;

namespace SteamAccCreator.Interfaces
{
    public interface ICaptchaDialog : IDisposable
    {
        DialogResult ShowDialog(out Web.Captcha.CaptchaSolution solution);
    }
}
