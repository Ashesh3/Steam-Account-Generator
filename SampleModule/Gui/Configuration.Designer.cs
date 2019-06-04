namespace SampleModule.Gui
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GbMail = new System.Windows.Forms.GroupBox();
            this.LbMailPort = new System.Windows.Forms.Label();
            this.LabMailHost = new System.Windows.Forms.Label();
            this.LabMailPassword = new System.Windows.Forms.Label();
            this.CbMailSsl = new System.Windows.Forms.CheckBox();
            this.BsMail = new System.Windows.Forms.BindingSource(this.components);
            this.NumMailPort = new System.Windows.Forms.NumericUpDown();
            this.TbMailHost = new System.Windows.Forms.TextBox();
            this.TbMailPassword = new System.Windows.Forms.TextBox();
            this.TbMail = new System.Windows.Forms.TextBox();
            this.LbMail = new System.Windows.Forms.Label();
            this.GbTwoCaptcha = new System.Windows.Forms.GroupBox();
            this.TbTwoCapKey = new System.Windows.Forms.TextBox();
            this.BsCaptcha = new System.Windows.Forms.BindingSource(this.components);
            this.LbTwoCapKey = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnApply = new System.Windows.Forms.Button();
            this.GbMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMailPort)).BeginInit();
            this.GbTwoCaptcha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsCaptcha)).BeginInit();
            this.SuspendLayout();
            // 
            // GbMail
            // 
            this.GbMail.Controls.Add(this.LbMailPort);
            this.GbMail.Controls.Add(this.LabMailHost);
            this.GbMail.Controls.Add(this.LabMailPassword);
            this.GbMail.Controls.Add(this.CbMailSsl);
            this.GbMail.Controls.Add(this.NumMailPort);
            this.GbMail.Controls.Add(this.TbMailHost);
            this.GbMail.Controls.Add(this.TbMailPassword);
            this.GbMail.Controls.Add(this.TbMail);
            this.GbMail.Controls.Add(this.LbMail);
            this.GbMail.Location = new System.Drawing.Point(12, 12);
            this.GbMail.Name = "GbMail";
            this.GbMail.Size = new System.Drawing.Size(264, 145);
            this.GbMail.TabIndex = 0;
            this.GbMail.TabStop = false;
            this.GbMail.Text = "Mail";
            // 
            // LbMailPort
            // 
            this.LbMailPort.AutoSize = true;
            this.LbMailPort.Location = new System.Drawing.Point(11, 99);
            this.LbMailPort.Name = "LbMailPort";
            this.LbMailPort.Size = new System.Drawing.Size(58, 13);
            this.LbMailPort.TabIndex = 3;
            this.LbMailPort.Text = "IMAP Port:";
            // 
            // LabMailHost
            // 
            this.LabMailHost.AutoSize = true;
            this.LabMailHost.Location = new System.Drawing.Point(8, 74);
            this.LabMailHost.Name = "LabMailHost";
            this.LabMailHost.Size = new System.Drawing.Size(61, 13);
            this.LabMailHost.TabIndex = 2;
            this.LabMailHost.Text = "IMAP Host:";
            // 
            // LabMailPassword
            // 
            this.LabMailPassword.AutoSize = true;
            this.LabMailPassword.Location = new System.Drawing.Point(13, 48);
            this.LabMailPassword.Name = "LabMailPassword";
            this.LabMailPassword.Size = new System.Drawing.Size(56, 13);
            this.LabMailPassword.TabIndex = 1;
            this.LabMailPassword.Text = "Password:";
            // 
            // CbMailSsl
            // 
            this.CbMailSsl.AutoSize = true;
            this.CbMailSsl.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BsMail, "UseSsh", true));
            this.CbMailSsl.Location = new System.Drawing.Point(72, 123);
            this.CbMailSsl.Name = "CbMailSsl";
            this.CbMailSsl.Size = new System.Drawing.Size(68, 17);
            this.CbMailSsl.TabIndex = 8;
            this.CbMailSsl.Text = "Use SSL";
            this.CbMailSsl.UseVisualStyleBackColor = true;
            // 
            // BsMail
            // 
            this.BsMail.DataSource = typeof(SampleModule.Models.MailConfig);
            // 
            // NumMailPort
            // 
            this.NumMailPort.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.BsMail, "Port", true));
            this.NumMailPort.Location = new System.Drawing.Point(72, 97);
            this.NumMailPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.NumMailPort.Name = "NumMailPort";
            this.NumMailPort.Size = new System.Drawing.Size(186, 20);
            this.NumMailPort.TabIndex = 7;
            // 
            // TbMailHost
            // 
            this.TbMailHost.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsMail, "Host", true));
            this.TbMailHost.Location = new System.Drawing.Point(72, 71);
            this.TbMailHost.Name = "TbMailHost";
            this.TbMailHost.Size = new System.Drawing.Size(186, 20);
            this.TbMailHost.TabIndex = 6;
            // 
            // TbMailPassword
            // 
            this.TbMailPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsMail, "Password", true));
            this.TbMailPassword.Location = new System.Drawing.Point(72, 45);
            this.TbMailPassword.Name = "TbMailPassword";
            this.TbMailPassword.Size = new System.Drawing.Size(186, 20);
            this.TbMailPassword.TabIndex = 5;
            // 
            // TbMail
            // 
            this.TbMail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsMail, "Email", true));
            this.TbMail.Location = new System.Drawing.Point(72, 19);
            this.TbMail.Name = "TbMail";
            this.TbMail.Size = new System.Drawing.Size(186, 20);
            this.TbMail.TabIndex = 4;
            // 
            // LbMail
            // 
            this.LbMail.AutoSize = true;
            this.LbMail.Location = new System.Drawing.Point(31, 22);
            this.LbMail.Name = "LbMail";
            this.LbMail.Size = new System.Drawing.Size(35, 13);
            this.LbMail.TabIndex = 0;
            this.LbMail.Text = "Email:";
            // 
            // GbTwoCaptcha
            // 
            this.GbTwoCaptcha.Controls.Add(this.TbTwoCapKey);
            this.GbTwoCaptcha.Controls.Add(this.LbTwoCapKey);
            this.GbTwoCaptcha.Location = new System.Drawing.Point(12, 163);
            this.GbTwoCaptcha.Name = "GbTwoCaptcha";
            this.GbTwoCaptcha.Size = new System.Drawing.Size(264, 60);
            this.GbTwoCaptcha.TabIndex = 1;
            this.GbTwoCaptcha.TabStop = false;
            this.GbTwoCaptcha.Text = "2Captcha/RuCaptcha";
            // 
            // TbTwoCapKey
            // 
            this.TbTwoCapKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsCaptcha, "ApiKey", true));
            this.TbTwoCapKey.Location = new System.Drawing.Point(6, 32);
            this.TbTwoCapKey.Name = "TbTwoCapKey";
            this.TbTwoCapKey.Size = new System.Drawing.Size(252, 20);
            this.TbTwoCapKey.TabIndex = 1;
            // 
            // BsCaptcha
            // 
            this.BsCaptcha.DataSource = typeof(SampleModule.Models.CaptchaConfig);
            // 
            // LbTwoCapKey
            // 
            this.LbTwoCapKey.AutoSize = true;
            this.LbTwoCapKey.Location = new System.Drawing.Point(6, 16);
            this.LbTwoCapKey.Name = "LbTwoCapKey";
            this.LbTwoCapKey.Size = new System.Drawing.Size(48, 13);
            this.LbTwoCapKey.TabIndex = 0;
            this.LbTwoCapKey.Text = "API Key:";
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(12, 229);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(99, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnApply
            // 
            this.BtnApply.Location = new System.Drawing.Point(177, 229);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(99, 23);
            this.BtnApply.TabIndex = 3;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // Configuration
            // 
            this.AcceptButton = this.BtnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(289, 263);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.GbTwoCaptcha);
            this.Controls.Add(this.GbMail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.GbMail.ResumeLayout(false);
            this.GbMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumMailPort)).EndInit();
            this.GbTwoCaptcha.ResumeLayout(false);
            this.GbTwoCaptcha.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsCaptcha)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbMail;
        private System.Windows.Forms.GroupBox GbTwoCaptcha;
        private System.Windows.Forms.CheckBox CbMailSsl;
        private System.Windows.Forms.NumericUpDown NumMailPort;
        private System.Windows.Forms.TextBox TbMailHost;
        private System.Windows.Forms.TextBox TbMailPassword;
        private System.Windows.Forms.TextBox TbMail;
        private System.Windows.Forms.Label LbMail;
        private System.Windows.Forms.Label LbMailPort;
        private System.Windows.Forms.Label LabMailHost;
        private System.Windows.Forms.Label LabMailPassword;
        private System.Windows.Forms.TextBox TbTwoCapKey;
        private System.Windows.Forms.Label LbTwoCapKey;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.BindingSource BsMail;
        private System.Windows.Forms.BindingSource BsCaptcha;
    }
}