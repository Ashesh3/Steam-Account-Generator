using Gecko;
using SteamAccCreator.Web.Captcha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class ReCaptchaDialog : Form, Interfaces.ICaptchaDialog
    {
        private CaptchaSolution Solution = new CaptchaSolution(false, "Something went wrong.", null);
        private Models.Configuration Configuration;

        public ReCaptchaDialog(Models.Configuration configuration, Models.ProxyItem proxy)
        {
            Configuration = configuration;
            Solution = new CaptchaSolution(false, Solution.Message, configuration.Captcha);
            InitializeComponent();

            if ((proxy?.Enabled ?? false))
            {
                GeckoPreferences.Default["network.proxy.type"] = 1;

                // clear proxies
                GeckoSetProxy(Enums.ProxyType.Http, "", 0);
                GeckoSetProxy(Enums.ProxyType.Socks4, "", 0);

                GeckoSetProxy(proxy.ProxyType, proxy.Host, proxy.Port);
            }
            else
                GeckoPreferences.Default["network.proxy.type"] = 0;
        }

        private void GeckoSetProxy(Enums.ProxyType proxyType, string host, int port)
        {
            switch (proxyType)
            {
                case Enums.ProxyType.Socks4:
                case Enums.ProxyType.Socks5:
                    GeckoPreferences.Default["network.proxy.socks"] = host;
                    GeckoPreferences.Default["network.proxy.socks_port"] = port;
                    break;
                case Enums.ProxyType.Unknown:
                case Enums.ProxyType.Http:
                case Enums.ProxyType.Https:
                default:
                    GeckoPreferences.Default["network.proxy.http"] = host;
                    GeckoPreferences.Default["network.proxy.http_port"] = port;
                    GeckoPreferences.Default["network.proxy.ssl"] = host;
                    GeckoPreferences.Default["network.proxy.ssl_port"] = port;
                    break;
            }

            if (proxyType == Enums.ProxyType.Socks4)
                GeckoPreferences.Default["network.proxy.socks_version"] = 4;
            else if (proxyType == Enums.ProxyType.Socks5)
                GeckoPreferences.Default["network.proxy.socks_version"] = 5;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Solution = new CaptchaSolution(false, "Closed captcha dialog.", Configuration.Captcha);
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            var resps = geckoWebBrowser1.Document.GetElementsByName("g-recaptcha-response");
            var solutionText = string.Empty;
            foreach (var resp in resps)
            {
                var textArea = resp as Gecko.DOM.GeckoTextAreaElement;
                var captchaText = textArea?.Value ?? "";
                if (string.IsNullOrEmpty(captchaText))
                    continue;

                solutionText += $"{captchaText}\n\n";
            }

            var captchagid = (geckoWebBrowser1.Document.GetElementById("captchagid")
                ?? geckoWebBrowser1.Document.GetElementsByName("captchagid")?.FirstOrDefault(x=> x != null))
                as Gecko.DOM.GeckoInputElement;

            Solution = new CaptchaSolution(solutionText, captchagid?.Value, Configuration.Captcha);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void geckoWebBrowser1_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {
            if (Regex.IsMatch(e.Uri?.Segments?.LastOrDefault() ?? "",
                @"join\/?", RegexOptions.IgnoreCase)
                || (e.Uri?.Host ?? "").ToLower() != (Defaults.Web.STEAM_JOIN_URI?.Host?.ToLower() ?? "NULL"))
            {
                Logger.Trace("Navigated to /join/.");
                return;
            }

            try
            {
                Logger.Info("Stopping navigation to new location...");
                e.Cancel = true;
            }
            catch(Exception ex)
            {
                Logger.Error("Failed to stop navigation...", ex);
                try
                {
                    geckoWebBrowser1.Navigate(Defaults.Web.STEAM_JOIN_ADDRESS);
                }
                catch(Exception exNav)
                {
                    Logger.Error("Navigation error", exNav);
                }
            }
        }

        private void geckoWebBrowser1_ReadyStateChange(object sender, DomEventArgs e)
        {
            var accFormBox = geckoWebBrowser1.Document.GetElementById("account_form_box");
            foreach (var accChild in accFormBox.ChildNodes)
            {
                if (accChild == null)
                    continue;

                if (accChild.NodeType != NodeType.Element)
                    continue;

                var joinRow = accChild as GeckoHtmlElement;
                if (!(joinRow?.ClassName?.Contains("join_form") ?? false))
                    continue;

                foreach (var jRowChild in joinRow.ChildNodes)
                {
                    if (jRowChild == null)
                        continue;

                    if (jRowChild.NodeType != NodeType.Element)
                        continue;

                    var jForm = jRowChild as GeckoHtmlElement;
                    if (!(jForm?.ClassName?.Contains("form_row") ?? false))
                        continue;

                    joinRow.RemoveChild(jRowChild);
                }
            }
        }

        private void geckoWebBrowser1_CreateWindow(object sender, GeckoCreateWindowEventArgs e)
        {
            e.Cancel = true;
        }

        public DialogResult ShowDialog(out CaptchaSolution solution)
        {
            btnReload_Click(null, null);

            var result = this.ShowDialog();
            solution = this.Solution;
            return result;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate(Defaults.Web.STEAM_JOIN_ADDRESS);
        }
    }
}
