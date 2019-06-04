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
        const string URL_WIKI_FIND_SUBID = "https://github.com/EarsKilla/Steam-Account-Generator/wiki/Find-sub-ID";
        public const long PHOTO_MAX_SIZE = 1048576;

        public Models.Configuration Configuration { get; private set; } = new Models.Configuration();
        public Web.ProxyManager ProxyManager { get; private set; }
        public Models.ModuleManager ModuleManager { get; private set; }

        public MainForm()
        {
            Logger.Trace($"{nameof(InitializeComponent)}()...");
            InitializeComponent();

            Logger.Trace($"Loading config: {Pathes.FILE_CONFIG}");
            try
            {
                if (System.IO.File.Exists(Pathes.FILE_CONFIG))
                {
                    Logger.Trace("Reading config file...");
                    var configData = System.IO.File.ReadAllText(Pathes.FILE_CONFIG);
                    Logger.Trace("Deserializing config from JSON...");
                    Configuration = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Configuration>(configData);
                    Logger.Trace("Config data has been loaded.");
                }
                else
                    Logger.Trace("Config file does not exists. Using defaults...");
            }
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Logger.Error("Probabply deserializing error...", jEx);
                Configuration = new Models.Configuration();
                Logger.Trace("Using defaults...");
            }
            catch (Exception ex)
            {
                Logger.Error("Config load or deserializing error or something else.", ex);
                Configuration = new Models.Configuration();
                Logger.Trace("Using defaults...");
            }

            Logger.Trace("Fixing NULL elements...");
            Configuration.FixNulls();

            Logger.Trace("Checking out file...");
            if (string.IsNullOrEmpty(Configuration.Output.Path))
                Configuration.Output.Path = Path.Combine(Environment.CurrentDirectory, "accounts.txt");

            Logger.Trace("Setting properties for base settings (mail, login, password, etc)...");
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

            Logger.Trace("Setting properties for captcha...");
            CbCapSolver.SelectedIndex = Configuration.Captcha.ServiceIndex;
            BsCaptchaCapsolConfig.DataSource = Configuration.Captcha.CaptchaSolutions;
            BsCaptchaTwoCapConfig.DataSource = Configuration.Captcha.RuCaptcha;

            Logger.Trace("Setting properties for file writing...");
            CbFwEnable.Checked = Configuration.Output.Enabled;
            CbFwMail.Checked = Configuration.Output.WriteEmails;
            LinkFwPath.Text = Configuration.Output.GetVisualPath();
            CbFwOutType.SelectedIndex = (int)Configuration.Output.SaveType;

            Logger.Trace("Setting properties for proxy...");
            CbProxyEnabled.Checked = Configuration.Proxy.Enabled;
            DgvProxyList.DataSource = Configuration.Proxy.List;

            Logger.Trace("Setting properties for profile...");
            profileConfigBindingSource.DataSource = Configuration.Profile;

            CbUpdateChannel.SelectedIndex = (int)Program.UpdaterHandler.UpdateChannel;
            CbUpdateChannel_SelectedIndexChanged(this, null);
            CbUpdateChannel.SelectedIndexChanged += CbUpdateChannel_SelectedIndexChanged;

            ProxyManager = new Web.ProxyManager(this);

            ModuleManager = new Models.ModuleManager(Configuration);
            DgvModules.DataSource = ModuleManager.ModuleBindings;
        }

        private void SaveConfig()
        {
            try
            {
                Logger.Info("Saving config...");
                var confData = Newtonsoft.Json.JsonConvert.SerializeObject(Configuration, Newtonsoft.Json.Formatting.Indented);
                System.IO.File.WriteAllText(Pathes.FILE_CONFIG, confData);
                Logger.Info("Saving config done!");
            }
            catch (Exception ex)
            {
                Logger.Error("Saving config error!", ex);
            }

            ModuleManager.SaveDisabled();
        }

        public async void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            Logger.Trace($"{nameof(btnCreateAccount)} was clicked...");

            if (NumAccountsCount.Value > 100)
                NumAccountsCount.Value = 100;
            else if (NumAccountsCount.Value < 1)
                NumAccountsCount.Value = 1;

            Logger.Trace($"Accounts to create: {NumAccountsCount}.");

            switch (Configuration.Captcha.Service)
            {
                case Enums.CaptchaService.Captchasolutions:
                    {
                        if (string.IsNullOrEmpty(Configuration.Captcha.CaptchaSolutions.ApiKey) ||
                            string.IsNullOrEmpty(Configuration.Captcha.CaptchaSolutions.ApiSecret))
                        {
                            Logger.Trace("Captchasolutions cannot be used. API and secret keys is empty! Checking modules...");
                            Configuration.Captcha.Service = Enums.CaptchaService.Module;
                            goto case Enums.CaptchaService.Module;
                        }
                        Logger.Trace("Using Captchasolutions...");
                    }
                    break;
                case Enums.CaptchaService.RuCaptcha:
                    {
                        if (string.IsNullOrEmpty(Configuration.Captcha.RuCaptcha.ApiKey))
                        {
                            Logger.Trace("TwoCaptcha/RuCaptcha cannot be used. API key is empty! Checking modules...");
                            Configuration.Captcha.Service = Enums.CaptchaService.Module;
                            goto case Enums.CaptchaService.Module;
                        }
                        Logger.Trace("Using TwoCaptcha/RuCaptcha...");
                    }
                    break;
                case Enums.CaptchaService.Module:
                    {
                        if (ModuleManager.Modules.GetCaptchaSolvers().Count() < 1 &&
                            ModuleManager.Modules.GetReCaptchaSolvers().Count() < 1)
                        {
                            Logger.Trace("No any module with captcha solving support. Swithing to manual mode...");
                            Configuration.Captcha.Service = Enums.CaptchaService.None;
                            goto default;
                        }
                        Logger.Trace("Using modules...");
                    }
                    break;
                case Enums.CaptchaService.None:
                default:
                    Logger.Trace("Using manual mode...");
                    break;
            }

            Configuration.Proxy.Enabled = CbProxyEnabled.Checked;
            if (ProxyManager.Enabled && ProxyManager.Current == null)
                ProxyManager.GetNew();
            else if (!ProxyManager.Enabled)
                ProxyManager.GetNew();

            if (CbFwEnable.Checked && string.IsNullOrEmpty(Configuration.Output.Path))
                Configuration.Output.Path = Path.Combine(Environment.CurrentDirectory, $"Accounts.{((CbFwOutType.SelectedIndex == 2) ? "csv" : "txt")}");

            if (CbFwEnable.Checked)
                Logger.Info($"File writing is enabled and file will be here: {Configuration.Output.Path}.");

            SaveConfig();

            var slowCaptchaMode = Configuration.Captcha.Service == Enums.CaptchaService.None;
            for (var i = 0; i < NumAccountsCount.Value; i++)
            {
                Logger.Trace($"Account {i + 1} of {NumAccountsCount}.");
                var accCreator = new AccountCreator(this, Configuration.Clone());
                if (slowCaptchaMode)
                {
                    Logger.Trace($"Account {i + 1} of {NumAccountsCount}. Starting in async/await thread...");
                    await Task.Run(() => accCreator.Run());
                }
                else
                {
                    Logger.Trace($"Account {i + 1} of {NumAccountsCount}. Starting in new thread...");
                    var thread = new Thread(accCreator.Run);
                    thread.Start();
                }
            }
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
            Logger.Trace($"int index({index}) = {nameof(AddToTable)}(\"{mail}\", \"{alias}\", \"****** PASSWORD ******\", \"{steamId}\", \"{status}\");");
            return index;
        }

        public void UpdateStatus(int i, string status, long steamId)
        {
            Logger.Trace($"void {nameof(UpdateStatus)}(\"{i}\", \"{status}\", \"{steamId}\");");
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
            Logger.Trace($"void {nameof(UpdateStatus)}(\"{i}\", \"{mail}\", \"{alias}\", \"****** PASSWORD ******\", \"{steamId}\", \"{status}\");");
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
            Logger.Trace($"void {nameof(ToggleForceWriteIntoFile)}();");
            var shouldForce = CbRandomMail.Checked || CbRandomPassword.Checked || CbRandomLogin.Checked;
            Logger.Trace($"void {nameof(ToggleForceWriteIntoFile)}();###var {nameof(shouldForce)} = {shouldForce}");
            CbFwEnable.Checked = shouldForce;
            CbFwEnable.AutoCheck = !shouldForce;
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Logger.Trace($"void {nameof(LinkClicked)}();");
            var link = sender as LinkLabel;
            if (link == null)
                return;

            try
            {
                System.Diagnostics.Process.Start(link.Text);
                e.Link.Visited = true;
                Logger.Trace($"void {nameof(LinkClicked)}();###var {nameof(link.Text)} = {link.Text}");
            }
            catch (Exception ex) { Logger.Error("Exception thrown while opening link...", ex); }
        }

        private void CbRandomMail_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Mail.Random = CbRandomMail.Checked;
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
            Logger.Trace($"void {nameof(BtnLoadIds_Click)}();");

            openFileDialog1.Filter = "All supported|*.txt;*.json|Text file|*.txt|JSON file|*.json|Try to parse from any type|*.*";
            openFileDialog1.Title = "Load game sub IDs";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            Logger.Trace($"Selected id's file: {openFileDialog1.FileName}");

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
            catch (Newtonsoft.Json.JsonException jEx)
            {
                Logger.Error("JSON exception was thrown... It's probably file don't contains JSON data. Trying to parse it...", jEx);
                try
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
                        catch (Exception cEx) { Logger.Error("Parsing error (in foreach)!", cEx); }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("Parsing via regexp. error!", ex);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Parsing error!", ex);
            }

            Logger.Trace($"Updating {nameof(ListGames)}... Count of games: {Configuration.Games.GamesToAdd.Count()}");
            ListGames.UpdateItems(Configuration.Games.GamesToAdd);
        }

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            Logger.Trace($"{nameof(BtnAddGame_Click)}(..., ...);");
            using (var dialog = new AddGameDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Configuration.Games.GamesToAdd = Configuration.Games.GamesToAdd.Append(dialog.GameInfo);
                    ListGames.UpdateItems(Configuration.Games.GamesToAdd);
                    Logger.Debug($"{dialog.GameInfo.SubId}:{dialog.GameInfo.Name} added.");
                }
            }
        }

        private void BtnRemoveGame_Click(object sender, EventArgs e)
        {
            Logger.Trace($"{nameof(BtnRemoveGame_Click)}(..., ...);");
            var index = ListGames.SelectedIndex;
            if (index < 0 || index >= ListGames.Items.Count)
                return;

            var _temp = Configuration.Games.GamesToAdd.ToList();
            var _game = _temp.ElementAtOrDefault(index);
            Logger.Debug($"{(_game?.SubId)?.ToString() ?? "NULL"}:{_game?.Name ?? "NULL"} removed.");
            _temp.RemoveAt(index);
            Configuration.Games.GamesToAdd = _temp;
            ListGames.UpdateItems(Configuration.Games.GamesToAdd);
        }

        private void BtnClearGames_Click(object sender, EventArgs e)
        {
            Logger.Trace($"{nameof(BtnClearGames_Click)}(..., ...);");
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
            Logger.Trace($"{nameof(ListGames_MouseDoubleClick)}(..., ...);");
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
                    Logger.Debug($"{game.SubId}:{game.Name} edited.");
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

        private void LinkHowToFindSubId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(URL_WIKI_FIND_SUBID);
            e.Link.Visited = true;
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
            saveFileDialog1.Title = "Where to save accounts";

            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.OverwritePrompt = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Configuration.Output.Path = saveFileDialog1.FileName;

                Logger.Debug($"Save path was changed to: {Configuration.Output.Path}");

                if (saveFileDialog1.FilterIndex == 2)
                    CbFwOutType.SelectedIndex = (int)File.SaveType.KeepassCsv;

                LinkFwPath.Text = Configuration.Output.GetVisualPath();
            }
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
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                case PlatformID.Unix:
                    System.Diagnostics.Process.Start($"file://{Path.GetDirectoryName(Configuration.Output.Path)}");
                    break;
                case PlatformID.Win32NT:
                    System.Diagnostics.Process.Start("explorer.exe", $"/select, \"{Configuration.Output.Path}\"");
                    break;
                default:
                    return;
            }

            e.Link.Visited = true;
        }

        private void CbProxyEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Proxy.Enabled = CbProxyEnabled.Checked;
        }

        private async void BtnProxyTest_Click(object sender, EventArgs e)
        {
            int disabled = 0, error = 0, good = 0;
            LabProxyTotal.Text = (Configuration.Proxy?.List?.Count())?.ToString() ?? "NULL";
            void updateCounters()
            {
                ExecuteInvoke(() =>
                {
                    LabProxyBad.Text = $"{error}";
                    LabProxyGood.Text = $"{good}";
                    LabProxyDisabled.Text = $"{disabled}";

                    DgvProxyList.Refresh();
                });
            }

            BtnProxyTestCancel.Enabled = true;
            BtnProxyLoad.Enabled =
                BtnProxyTest.Enabled = false;
            await ProxyManager.CheckProxies(() =>
            { // proxy is disabled
                disabled++;
                updateCounters();
            },
            () =>
            { // proxy not passed checks
                error++;
                updateCounters();
            },
            () =>
            { // proxy is working
                good++;
                updateCounters();
            },
            () =>
            { // check ended
                ExecuteInvoke(() =>
                {
                    BtnProxyTestCancel.Enabled = false;

                    BtnProxyLoad.Enabled =
                        BtnProxyTest.Enabled = true;
                });
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
            Logger.Info("Shutting down...");
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

        private void BtnProxyLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text file|*.txt";
            openFileDialog1.Title = "Load proxy list";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            Logger.Trace("Loading proxies...");

            var data = System.IO.File.ReadAllLines(openFileDialog1.FileName);
            var proxies = new List<Models.ProxyItem>();
            var proxiesOld = (DgvProxyList.DataSource as IEnumerable<Models.ProxyItem>) ?? new Models.ProxyItem[0];

            if (proxiesOld.Count() > 0)
            {
                switch (MessageBox.Show(this, "Merge with current proxies?", "Proxy loading...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        proxies.AddRange(proxiesOld);
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        return;
                }
            }

            Logger.Trace($"Proxies file have {data.Count()} line(s).");

            foreach (var line in data)
            {
                try
                {
                    proxies.Add(new Models.ProxyItem(line));
                }
                catch (Exception ex)
                {
                    Logger.Error($"Adding proxy error. Line: {line}", ex);
                }
            }

            DgvProxyList.DataSource = Configuration.Proxy.List = proxies;

            Logger.Trace("Loading proxies done.");
        }

        private void BtnProxyTestCancel_Click(object sender, EventArgs e)
        {
            BtnProxyTestCancel.Enabled = false;
            ProxyManager.CancelChecking();
        }

        private void CbUpdateChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender != this)
                Program.UpdaterHandler.Refresh((Web.Updater.Enums.UpdateChannelEnum)CbUpdateChannel.SelectedIndex);

            LbCurrentversionStr.Text = Web.Updater.UpdaterHandler.CurrentVersion.ToString(3);
            LbServerVersionStr.Text = Program.UpdaterHandler.VersionInfo.ToString();

            if (Program.UpdaterHandler.IsCanBeUpdated && sender == this)
                tabControl.SelectedTab = tabUpdates;

            BtnDlLatestBuild.Visible = Program.UpdaterHandler.IsCanBeUpdated;
        }

        private void BtnDlLatestBuild_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Program.UpdaterHandler.VersionInfo.Downloads.Windows);
            }
            catch (Exception ex)
            {
                Logger.Error("Error while opening update download.", ex);
            }
        }

        private void BtnUpdateNotes_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Program.UpdaterHandler.VersionInfo.ReleaseNotes);
            }
            catch (Exception ex)
            {
                Logger.Error("Error while opening update download.", ex);
            }
        }

        private void BtnProfileSelectImg_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog()
            {
                Filter = "Image files|*.png;*.jpg;*.jpeg;*.gif|All files|*.*",
            };

            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            var fileInfo = new FileInfo(openDialog.FileName);
            if (fileInfo.Length > PHOTO_MAX_SIZE)
            {
                MessageBox.Show(this, "Cannot use this file. It cannot be larger than 1024kb.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TbProfileImagePath.Text = openDialog.FileName;
        }

        private void BtnProfileRmImg_Click(object sender, EventArgs e)
        {
            TbProfileImagePath.Text = "";
        }

        public void ExecuteInvoke(Action action)
            => this.Invoke(action);
        public T ExecuteInvoke<T>(Func<T> action)
        {
            var result = default(T);
            ExecuteInvoke(new Action(() => result = action()));
            return result;
        }

        private object InvokeSync = new object();
        public void ExecuteInvokeLock(Action action)
        {
            lock (InvokeSync)
            {
                ExecuteInvoke(action);
            }
        }
        public T ExecuteInvokeLock<T>(Func<T> action)
        {
            lock (InvokeSync)
            {
                return ExecuteInvoke(action);
            }
        }

        // lol. yeah. someone ask me to implement this xd
        private FormWindowState OldWinState = FormWindowState.Normal;
        private bool IsFullScreenLikeBrowser = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F11)
            {
                IsFullScreenLikeBrowser = !IsFullScreenLikeBrowser;

                if (IsFullScreenLikeBrowser)
                {
                    OldWinState = this.WindowState;

                    this.WindowState = FormWindowState.Maximized;
                    this.FormBorderStyle = FormBorderStyle.None;
                }
                else
                {
                    this.WindowState = OldWinState;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DgvModules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3)
                return;

            var module = ModuleManager.ModuleBindings.ElementAtOrDefault(e.RowIndex);
            module?.OnClick?.Invoke();
        }

        private void CbCapSolver_SelectedIndexChanged(object sender, EventArgs e)
        {
            Configuration.Captcha.ServiceIndex = CbCapSolver.SelectedIndex;
        }
    }
}
