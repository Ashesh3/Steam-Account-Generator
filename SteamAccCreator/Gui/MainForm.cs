using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class MainForm : Form
    {
        private static readonly string FILE_CONFIG = Path.Combine(Environment.CurrentDirectory, "config.json");

        public Models.Configuration Configuration { get; private set; } = new Models.Configuration();

        public MainForm()
        {
            InitializeComponent();

            // load config here
            try
            {
                if (System.IO.File.Exists(FILE_CONFIG))
                {
                    var configData = System.IO.File.ReadAllText(FILE_CONFIG);
                    Configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Configuration>(configData);
                }
            }
            catch { Configuration = new Models.Configuration(); }

            Configuration.FixNulls();

            if (string.IsNullOrEmpty(Configuration.Output.Path))
                Configuration.Output.Path = Path.Combine(Environment.CurrentDirectory, "accounts.txt");

            CbRandomMail.Checked = Configuration.Mail.Random;
            txtEmail.Text = Configuration.Mail.Value;

            CbRandomLogin.Checked = Configuration.Login.Random;
            CbNeatLogin.Checked = Configuration.Login.Neat;
            txtAlias.Text = Configuration.Login.Value;

            CbRandomPassword.Checked = Configuration.Password.Random;
            CbNeatPassword.Checked = Configuration.Password.Neat;
            txtPass.Text = Configuration.Password.Value;

            CbAddGames.Checked = Configuration.Games.AddGames;
            ListGames.Items.AddRange(Configuration.Games.GamesToAdd ?? new Models.GameInfo[0]);

            CbCapAuto.Checked = Configuration.Captcha.Enabled;
            CbCapHandMode.Checked = Configuration.Captcha.HandMode;
            RadCapCaptchasolutions.Checked = !(RadCapRuCaptcha.Checked = Configuration.Captcha.Service == Enums.CaptchaService.RuCaptcha);
            TbCapSolutionsApi.Text = Configuration.Captcha.CaptchaSolutions.ApiKey;
            TbCapSolutionsSecret.Text = Configuration.Captcha.CaptchaSolutions.ApiSecret;
            TbCapRuCapApi.Text = Configuration.Captcha.RuCaptcha.ApiKey;

            CbFwEnable.Checked = Configuration.Output.Enabled;
            CbFwMail.Checked = Configuration.Output.WriteEmails;
            //LinkFwPath.Text = Configuration.Output.Path;
            LinkFwPath.Text = Configuration.Output.GetVisualPath();
            CbFwOutType.SelectedIndex = (int)Configuration.Output.SaveType;

            CbProxyEnabled.Checked = Configuration.Proxy.Enabled;
            TbProxyAddr.Text = Configuration.Proxy.Host;
            TbProxyPort.Value = (Configuration.Proxy.Port < 1 || Configuration.Proxy.Port > 65535) ? Configuration.Proxy.Port = 1 : Configuration.Proxy.Port;
        }

        public async void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            if (NumAccountsCount.Value > 100)
                NumAccountsCount.Value = 100;
            else if (NumAccountsCount.Value < 1)
                NumAccountsCount.Value = 1;

            Configuration.Captcha.Enabled = CbCapAuto.Checked && CbCapAuto.Enabled;
            if (Configuration.Captcha.Enabled)
            {
                switch (Configuration.Captcha.Service)
                {
                    case Enums.CaptchaService.Captchasolutions:
                        {
                            if (string.IsNullOrEmpty(TbCapSolutionsApi.Text) ||
                                string.IsNullOrEmpty(TbCapSolutionsSecret.Text))
                            {
                                CbCapAuto.Checked = Configuration.Captcha.Enabled = false;
                            }
                            else
                            {
                                Configuration.Captcha.CaptchaSolutions.ApiKey = TbCapSolutionsApi.Text;
                                Configuration.Captcha.CaptchaSolutions.ApiSecret = TbCapSolutionsSecret.Text;
                            }
                        }
                        break;
                    case Enums.CaptchaService.RuCaptcha:
                        {
                            if (string.IsNullOrEmpty(TbCapRuCapApi.Text))
                                CbCapAuto.Checked = Configuration.Captcha.Enabled = false;
                            else
                                Configuration.Captcha.RuCaptcha.ApiKey = TbCapRuCapApi.Text;
                        }
                        break;
                    case Enums.CaptchaService.Unknown:
                    default:
                        CbCapAuto.Checked = Configuration.Captcha.Enabled = false;
                        break;
                }
            }

            Configuration.Proxy.Enabled = CbProxyEnabled.Checked;
            if (Configuration.Proxy.Enabled)
            {
                Configuration.Proxy.Host = TbProxyAddr.Text;
                Configuration.Proxy.Port = (int)TbProxyPort.Value;
            }

            if (CbFwEnable.Checked == true && string.IsNullOrEmpty(Configuration.Output.Path))
                Configuration.Output.Path = Path.Combine(Environment.CurrentDirectory, $"Accounts.{((CbFwOutType.SelectedIndex == 2) ? "csv" : "txt")}");

            var slowCaptchaMode = Configuration.Captcha.HandMode = CbCapHandMode.Checked;
            if (slowCaptchaMode)
                CbCapHandMode.Enabled = false;

            for (var i = 0; i < NumAccountsCount.Value; i++)
            {
                var accCreator = new AccountCreator(this, Configuration.Clone());
                if (slowCaptchaMode)
                {
                    await Task.Run(() => accCreator.Run());
                }
                else
                {
                    var thread = new Thread(accCreator.Run);
                    thread.Start();
                }
            }

            CbCapHandMode.Enabled = true;
        }

        public int AddToTable(string mail, string alias, string pass, long steamId, string status)
        {
            var index = -1;
            Invoke(new Action(() =>
            {
                index = dataAccounts.Rows.Add(new DataGridViewRow
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell {Value = mail},
                        new DataGridViewTextBoxCell {Value = alias},
                        new DataGridViewTextBoxCell {Value = pass},
                        new DataGridViewTextBoxCell {Value = $"{steamId}"},
                        new DataGridViewTextBoxCell {Value = status}
                    }
                });
            }));
            return index;
        }

        public void UpdateStatus(int i, string status, long steamId)
        {
            Invoke(new Action(() =>
            {
                UpdateStatus(i,
                    dataAccounts.Rows[i].Cells[0].Value?.ToString() ?? "",
                    dataAccounts.Rows[i].Cells[1].Value?.ToString() ?? "",
                    dataAccounts.Rows[i].Cells[2].Value?.ToString() ?? "",
                    steamId,
                    status);
            }));
        }

        public void UpdateStatus(int i, string mail, string alias, string password, long steamId, string status)
            => UpdateStatus(i, mail, alias, password, $"{steamId}", status);
        public void UpdateStatus(int i, string mail, string alias, string password, string steamId, string status)
        {
            Invoke(new Action(() =>
            {
                try
                {
                    dataAccounts.Rows[i].Cells[0].Value = mail;
                    dataAccounts.Rows[i].Cells[1].Value = alias;
                    dataAccounts.Rows[i].Cells[2].Value = password;
                    dataAccounts.Rows[i].Cells[3].Value = $"{steamId}";
                    dataAccounts.Rows[i].Cells[4].Value = status;
                }
                catch { }
            }));
        }

        private void ToggleForceWriteIntoFile()
        {
            var shouldForce = CbRandomMail.Checked || CbRandomPassword.Checked || CbRandomLogin.Checked;
            CbFwEnable.Checked = shouldForce;
            CbFwEnable.AutoCheck = !shouldForce;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Configuration.Output.Path = saveFileDialog1.FileName;

            LinkFwPath.Text = Configuration.Output.GetVisualPath();
        }

        public static bool SocketConnect(string host, int port)
        {
            var is_success = false;
            try
            {
                var connsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 200);
                Thread.Sleep(500);
                var hip = IPAddress.Parse(host);
                var ipep = new IPEndPoint(hip, port);
                connsock.Connect(ipep);
                if (connsock.Connected)
                {
                    is_success = true;
                }
                connsock.Close();
            }
            catch (Exception)
            {
                is_success = false;
            }
            return is_success;
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = sender as LinkLabel;
            if (link == null)
                return;

            try
            {
                System.Diagnostics.Process.Start(link.Text);
                e.Link.Visited = true;
            }
            catch { }
        }

        private void CbRandomMail_CheckedChanged(object sender, EventArgs e)
        {
            txtEmail.Enabled = !(Configuration.Mail.Random = CbRandomMail.Checked);
            ToggleForceWriteIntoFile();
        }

        private void CbRandomLogin_CheckedChanged(object sender, EventArgs e)
        {
            txtAlias.Enabled = !(CbNeatLogin.Enabled = Configuration.Login.Random = CbRandomLogin.Checked);
            ToggleForceWriteIntoFile();
        }

        private void CbNeatLogin_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Login.Neat = CbNeatLogin.Checked;
        }

        private void CbRandomPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.Enabled = !(CbNeatPassword.Enabled = Configuration.Password.Random = CbRandomPassword.Checked);
            ToggleForceWriteIntoFile();
        }

        private void CbNeatPassword_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Password.Neat = CbNeatPassword.Checked;
        }

        private void BtnLoadIds_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All supported|*.txt;*.json|Text file|*.txt|JSON file|*.json|Try to parse from any type|*.*";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            var fileData = System.IO.File.ReadAllText(openFileDialog1.FileName);
            Configuration.Games.GamesToAdd = Configuration.Games.GamesToAdd ?? new Models.GameInfo[0];
            try
            {
                var games = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<Models.GameInfo>>(fileData);
                var _temp = Configuration.Games.GamesToAdd.ToList();

                games = games.Where(x => !_temp.Any(g => g.Equals(x)));
                _temp.AddRange(games);

                Configuration.Games.GamesToAdd = _temp;
            }
            catch
            {
                var matches = Regex.Matches(fileData, @"(\d+):(.*)", RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                {
                    try
                    {
                        var game = new Models.GameInfo()
                        {
                            SubId = int.Parse(match.Groups[1].Value),
                            Name = match.Groups[2].Value
                        };

                        if (!Configuration.Games.GamesToAdd.Any(x => x.Equals(game)))
                            Configuration.Games.GamesToAdd = Configuration.Games.GamesToAdd.Append(game);
                    }
                    catch { }
                }
            }

            ListGames.UpdateItems(Configuration.Games.GamesToAdd);
        }

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddGameDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Configuration.Games.GamesToAdd = Configuration.Games.GamesToAdd.Append(dialog.GameInfo);
                    ListGames.UpdateItems(Configuration.Games.GamesToAdd);
                }
            }
        }

        private void BtnRemoveGame_Click(object sender, EventArgs e)
        {
            var index = ListGames.SelectedIndex;
            if (index < 0 || index >= ListGames.Items.Count)
                return;

            var _temp = Configuration.Games.GamesToAdd.ToList();
            _temp.RemoveAt(index);
            Configuration.Games.GamesToAdd = _temp;
            ListGames.UpdateItems(Configuration.Games.GamesToAdd);
        }

        private void BtnClearGames_Click(object sender, EventArgs e)
        {
            Configuration.Games.GamesToAdd = new Models.GameInfo[0];
            ListGames.Items.Clear();
        }

        private void ListGames_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem.GetType() != typeof(Models.GameInfo))
                return;

            var info = e.ListItem as Models.GameInfo;
            e.Value = $"{info.Name} ({info.SubId})";
        }

        private void ListGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ListGames.SelectedIndex;

            BtnAddGame.Enabled = BtnRemoveGame.Enabled = !(index < 0 || index >= ListGames.Items.Count);
        }

        private void ListGames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = ListGames.SelectedIndex;
            if (index < 0 || index >= ListGames.Items.Count)
                return;

            var game = ListGames.Items[index] as Models.GameInfo;
            using (var dialog = new AddGameDialog(game))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var _temp = Configuration.Games.GamesToAdd.ToList();
                    ListGames.Items[index] = _temp[index] = game;
                    Configuration.Games.GamesToAdd = _temp;
                }
            }
        }

        private void BtnExportGames_Click(object sender, EventArgs e)
        {
            if (ListGames.Items.Count < 1)
            {
                MessageBox.Show(this, "Games list is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            saveFileDialog1.Filter = "JSON|*.json";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.OverwritePrompt = true;

            saveFileDialog1.Title = "Export game IDs";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            var data = Newtonsoft.Json.JsonConvert.SerializeObject(Configuration.Games.GamesToAdd, Newtonsoft.Json.Formatting.Indented);
            System.IO.File.WriteAllText(saveFileDialog1.FileName, data);
        }

        private void CbAddGames_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Games.AddGames = CbAddGames.Checked;
        }

        private void CbCapAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (Configuration.Captcha.Enabled = CbCapAuto.Checked)
            {
                RadCapCaptchasolutions.Enabled =
                    RadCapRuCaptcha.Enabled = true;

                RadCapCaptchasolutions_CheckedChanged(this, e);
                RadCapRuCaptcha_CheckedChanged(this, e);
            }
            else
            {
                RadCapCaptchasolutions.Enabled =
                    RadCapRuCaptcha.Enabled =
                    TbCapRuCapApi.Enabled =
                    TbCapSolutionsApi.Enabled =
                    TbCapSolutionsSecret.Enabled = false;
            }
        }

        private void CbCapHandMode_CheckedChanged(object sender, EventArgs e)
        {
            CbCapAuto.Checked = CbCapAuto.Enabled = !CbCapHandMode.Checked;
        }

        private void RadCapCaptchasolutions_CheckedChanged(object sender, EventArgs e)
        {
            TbCapSolutionsApi.Enabled =
                TbCapSolutionsSecret.Enabled = RadCapCaptchasolutions.Checked;
        }

        private void RadCapRuCaptcha_CheckedChanged(object sender, EventArgs e)
        {
            TbCapRuCapApi.Enabled = RadCapRuCaptcha.Checked;
        }

        private void CbFwEnable_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Output.Enabled = CbFwEnable.Checked;
        }

        private void CbFwMail_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Output.WriteEmails = CbFwMail.Checked;
        }

        private void BtnFwChangeFolder_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text File|*.txt|KeePass CSV|*.csv";
            saveFileDialog1.Title = "Save Files To";

            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.OverwritePrompt = true;

            saveFileDialog1.ShowDialog();
        }

        private void CbFwOutType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration.Output.SaveType = (File.SaveType)CbFwOutType.SelectedIndex;

            if (Configuration.Output.SaveType == File.SaveType.KeepassCsv)
                Configuration.Output.Path = Path.ChangeExtension(Configuration.Output.Path, "csv");
            else
                Configuration.Output.Path = Path.ChangeExtension(Configuration.Output.Path, "txt");

            LinkFwPath.Text = Configuration.Output.GetVisualPath();
        }

        private void LinkFwPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
                return;

            System.Diagnostics.Process.Start("explorer.exe", $"/select, \"{Configuration.Output.Path}\"");
            e.Link.Visited = true;
        }

        private void CbProxyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Proxy.Enabled = CbProxyEnabled.Checked;
        }

        private void BtnProxyTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbProxyAddr.Text))
                return;

            LabProxyStatus.Text = "Testing...";

            LabProxyStatus.Text = (SocketConnect(TbProxyAddr.Text, (int)TbProxyPort.Value) == true) ? "True" : "False";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var confData = Newtonsoft.Json.JsonConvert.SerializeObject(Configuration, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(FILE_CONFIG, confData);
            }
            catch { }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Configuration.Mail.Value = txtEmail.Text;
        }

        private void txtAlias_TextChanged(object sender, EventArgs e)
        {
            Configuration.Login.Value = txtAlias.Text;
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            Configuration.Password.Value = txtPass.Text;
        }
    }
}
