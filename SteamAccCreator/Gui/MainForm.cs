using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SteamAccCreator.Gui
{
    public partial class MainForm : Form
    {
        public bool RandomMail { get; private set; }
        public bool UseCsgo { get; private set; }
        public bool RandomAlias { get; private set; }
        public bool Neatusername { get; private set; }
        public bool NeatPassword { get; private set; }
        public bool RandomPass { get; private set; }
        public bool WriteIntoFile { get; private set; }
        public bool UseProxy { get; private set; }
        public bool AutoMailVerify { get; private set; }
        public bool UseCaptchaService { get; private set; }
        public bool Use2Cap { get; private set; }
        public static string apixkey;
        public static string twocapkey;
        public static string secxkey;
        private int _index = 0;

        public MainForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public string proxyval = null;
        public int proxyport = 0;
        public bool proxy = false;

        public async void BtnCreateAccount_Click(object sender, EventArgs e)
        {
            //btnCreateAccount.Visible = false;
            if (nmbrAmountAccounts.Value > 100)
                nmbrAmountAccounts.Value = 100;
            else if (nmbrAmountAccounts.Value < 1)
                nmbrAmountAccounts.Value = 1;

            if (UseCaptchaService)
            {
                if (!Use2Cap)
                {
                    if (secretkey.Text == "" || apikey.Text == "")
                    {
                        UseCaptchaService = false;
                        autocap.Checked = false;
                    }
                    else
                    {
                        apixkey = apikey.Text;
                        secxkey = secretkey.Text;
                    }
                }
                else
                {
                    if (captwoapikey.Text == "")
                    {
                        UseCaptchaService = false;
                        autocap.Checked = false;
                    }
                    else
                    {
                        twocapkey = captwoapikey.Text;
                    }
                }
            }

            if (checkBox1.Checked == true)
            {
                proxyval = textBox1.Text;
                proxyport = Convert.ToInt32(textBox2.Text);
                proxy = true;
            }
            else
            {
                proxy = false;
            }

            async Task makeSomeShitForValve()
            {
                var slowCaptchaMode = capHandMode.Checked;
                if (slowCaptchaMode)
                    capHandMode.Enabled = false;

                for (var i = 0; i < nmbrAmountAccounts.Value; i++)
                {
                    var accCreator = new AccountCreator(this, txtEmail.Text, txtAlias.Text, txtPass.Text, _index, UseCaptchaService);
                    if (slowCaptchaMode)
                    {
                        await Task.Run(() => accCreator.Run());
                    }
                    else
                    {
                        var thread = new Thread(accCreator.Run);
                        thread.Start();
                    }
                    _index++;
                }

                capHandMode.Enabled = true;
            }

            if (checkBox4.Checked == true)
            {
                if (!string.IsNullOrEmpty(file))
                {
                    await makeSomeShitForValve();
                }
                else
                {
                    MessageBox.Show("Please Select a File to Edit. :)");
                }
            }
            else
            {
                await makeSomeShitForValve();
            }

        }

        public void AddToTable(string mail, string alias, string pass, long steamId)
        {
            BeginInvoke(new Action(() =>
            {
                dataAccounts.Rows.Add(new DataGridViewRow
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell {Value = mail},
                        new DataGridViewTextBoxCell {Value = alias},
                        new DataGridViewTextBoxCell {Value = pass},
                        new DataGridViewTextBoxCell {Value = $"{steamId}"},
                        new DataGridViewTextBoxCell {Value = "Ready"}
                    }
                });
            }));
        }

        public void UpdateStatus(int i, string status, long steamId)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    dataAccounts.Rows[i].Cells[3].Value = $"{steamId}";
                    dataAccounts.Rows[i].Cells[4].Value = status;
                }
                catch (Exception)
                {

                }
            }));
        }


        private void ChkAutoVerifyMail_CheckedChanged(object sender, EventArgs e)
        {
            AutoMailVerify = chkAutoVerifyMail.Checked;
        }

        private void ChkWriteIntoFile_CheckedChanged(object sender, EventArgs e)
        {
            WriteIntoFile = chkWriteIntoFile.Checked;
        }

        private void ChkRandomMail_CheckedChanged(object sender, EventArgs e)
        {
            chkWriteIntoFile.ForeColor = System.Drawing.Color.White;
            chkAutoVerifyMail.ForeColor = System.Drawing.Color.White;
            var state = chkRandomMail.Checked;
            chkAutoVerifyMail.Checked = state;
            chkAutoVerifyMail.AutoCheck = state;
            RandomMail = state;
            txtEmail.Enabled = !state;
            ToggleForceWriteIntoFile();
            chkWriteIntoFile.ForeColor = System.Drawing.Color.White;
            chkAutoVerifyMail.ForeColor = System.Drawing.Color.White;
        }

        private void ChkRandomPass_CheckedChanged(object sender, EventArgs e)
        {
            var state = chkRandomPass.Checked;
            txtPass.Enabled = !state;
            RandomPass = state;
            neatpassBox.Visible = true;
            NeatPassword = true;
            ToggleForceWriteIntoFile();
        }

        private void ChkRandomAlias_CheckedChanged(object sender, EventArgs e)
        {
            var state = chkRandomAlias.Checked;
            Neatusername = true;
            txtAlias.Enabled = !state;
            NeatUsername.Visible = state;
            RandomAlias = state;
            ToggleForceWriteIntoFile();
        }

        private void ToggleForceWriteIntoFile()
        {
            var shouldForce = chkRandomMail.Checked || chkRandomPass.Checked || chkRandomAlias.Checked;
            chkWriteIntoFile.Checked = shouldForce;
            chkWriteIntoFile.AutoCheck = !shouldForce;
            chkWriteIntoFile.ForeColor = System.Drawing.Color.White;
            chkAutoVerifyMail.ForeColor = System.Drawing.Color.White;
        }

        public bool istrue = false;
        public string Path = @"accounts.txt";

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                button1.Enabled = true;
                Path = file;
            }
            else
            {
                button1.Enabled = false;
                Path = @"accounts.txt";
            }
        }

        public string file = null;

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text File|*.txt|KeePass CSV|*.csv";
            saveFileDialog1.Title = "Save Files To";

            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.OverwritePrompt = true;

            var isComboBox = sender == comboBox1;
            if (isComboBox)
                saveFileDialog1.FilterIndex = 2;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog1.FileName;
                checkBox4.Checked = true;
                if (saveFileDialog1.FilterIndex == 2)
                {
                    comboBox1.SelectedIndex = (int)(original = File.FileManager.FileWriteType.KeePassCSV);
                    checkBox4.Enabled = comboBox1.Enabled = false;

                    using (var fw = new StreamWriter(file))
                    {
                        fw.WriteLine("Title,User Name,Password,URL,Notes");
                    }
                }
                else
                    checkBox4.Enabled = comboBox1.Enabled = true;
            }
            else if (isComboBox)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                istrue = true;
            }
            else
            {
                istrue = false;
            }
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Path = saveFileDialog1.FileName;
            MessageBox.Show($"File \"{System.IO.Path.GetFileName(Path)}\" will be saved here: {System.IO.Path.GetDirectoryName(Path)}");
        }

        private void nmbrAmountAccounts_ValueChanged(object sender, EventArgs e)
        {
            if (nmbrAmountAccounts.Value > 100)
            {
                nmbrAmountAccounts.Value = 100;
            }
        }

        public File.FileManager.FileWriteType original = File.FileManager.FileWriteType.Original;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    if (SocketConnect(textBox1.Text, Convert.ToInt32(textBox2.Text)) == true)
                    {
                        label1.Text = "Working: True";
                    }
                    else
                    {
                        label1.Text = "Working: False";
                    }
                }
            }
        }

        private void SiteLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://steam.bot.nu/steam/");
        }

        private void NeatUsername_CheckedChanged(object sender, EventArgs e)
        {
            var state = NeatUsername.Checked;
            Neatusername = state;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            var state = neatpassBox.Checked;
            NeatPassword = state;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tele.click/dedsec1337");
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
        }

        private void autocap_CheckedChanged(object sender, EventArgs e)
        {
            Use2Cap = false;
            captchasolutions.Checked = true;
            twocap.Checked = false;
            var state = autocap.Checked;
            UseCaptchaService = state;
            if (UseCaptchaService)
            {
                apikey.Enabled = true;
                secretkey.Enabled = true;
            }
            else
            {
                apikey.Enabled = false;
                secretkey.Enabled = false;
                captwoapikey.Enabled = false;
            }

        }

        private void csgo_CheckedChanged(object sender, EventArgs e)
        {
            var state = csgo.Checked;
            UseCsgo = state;
        }

        private void twocap_CheckedChanged(object sender, EventArgs e)
        {
            var state = twocap.Checked;
            Use2Cap = state;

            if (state)
            {
                apikey.Enabled = false;
                secretkey.Enabled = false;
                captwoapikey.Enabled = true;
            }
            else
            {
                apikey.Enabled = true;
                secretkey.Enabled = true;
                captwoapikey.Enabled = false;
            }
            if (!UseCaptchaService)
            {
                apikey.Enabled = false;
                secretkey.Enabled = false;
                captwoapikey.Enabled = false;

            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void captchasolutions_CheckedChanged(object sender, EventArgs e)
        {
            var state = captchasolutions.Checked;
            Use2Cap = !state;
            if (!state)
            {
                apikey.Enabled = false;
                secretkey.Enabled = false;
                captwoapikey.Enabled = true;
            }
            else
            {
                apikey.Enabled = true;
                secretkey.Enabled = true;
                captwoapikey.Enabled = false;
            }
            if (!UseCaptchaService)
            {
                apikey.Enabled = false;
                secretkey.Enabled = false;
                captwoapikey.Enabled = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tele.click/sag_bot");
        }

        private void dataAccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            original = (File.FileManager.FileWriteType)comboBox1.SelectedIndex;
            if (original == File.FileManager.FileWriteType.KeePassCSV && sender == comboBox1)
                button1_Click(sender, e);
        }

        private void capHandMode_CheckedChanged(object sender, EventArgs e)
        {
            if (capHandMode.Checked)
                autocap.Checked = false;

            captchasolutions.Enabled =
                apikey.Enabled =
                secretkey.Enabled =
                twocap.Enabled =
                captwoapikey.Enabled =
                autocap.Enabled = !capHandMode.Checked;
        }
    }
}
