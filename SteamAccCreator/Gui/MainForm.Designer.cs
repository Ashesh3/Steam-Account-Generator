namespace SteamAccCreator.Gui
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.nmbrAmountAccounts = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.chkRandomMail = new System.Windows.Forms.CheckBox();
            this.pnlSettings = new System.Windows.Forms.GroupBox();
            this.csgo = new System.Windows.Forms.CheckBox();
            this.neatpassBox = new System.Windows.Forms.CheckBox();
            this.NeatUsername = new System.Windows.Forms.CheckBox();
            this.chkWriteIntoFile = new System.Windows.Forms.CheckBox();
            this.chkAutoVerifyMail = new System.Windows.Forms.CheckBox();
            this.chkRandomAlias = new System.Windows.Forms.CheckBox();
            this.chkRandomPass = new System.Windows.Forms.CheckBox();
            this.autocap = new System.Windows.Forms.CheckBox();
            this.pnlCreation = new System.Windows.Forms.GroupBox();
            this.dataAccounts = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.captwoapikey = new System.Windows.Forms.TextBox();
            this.captchasolutions = new System.Windows.Forms.RadioButton();
            this.twocap = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.secretkey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.apikey = new System.Windows.Forms.TextBox();
            this.colMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSteamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.capHandMode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmbrAmountAccounts)).BeginInit();
            this.pnlSettings.SuspendLayout();
            this.pnlCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.txtEmail.Location = new System.Drawing.Point(47, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(283, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreateAccount.Location = new System.Drawing.Point(12, 97);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(318, 23);
            this.btnCreateAccount.TabIndex = 5;
            this.btnCreateAccount.Text = "Create Accounts";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.BtnCreateAccount_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEmail.Location = new System.Drawing.Point(6, 22);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email:";
            // 
            // txtAlias
            // 
            this.txtAlias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.txtAlias.Location = new System.Drawing.Point(47, 45);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(283, 20);
            this.txtAlias.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.txtPass.Location = new System.Drawing.Point(47, 71);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(283, 20);
            this.txtPass.TabIndex = 3;
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAlias.Location = new System.Drawing.Point(9, 48);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(32, 13);
            this.lblAlias.TabIndex = 12;
            this.lblAlias.Text = "Alias:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPass.Location = new System.Drawing.Point(8, 74);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(33, 13);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Pass:";
            // 
            // nmbrAmountAccounts
            // 
            this.nmbrAmountAccounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.nmbrAmountAccounts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.nmbrAmountAccounts.Location = new System.Drawing.Point(52, 20);
            this.nmbrAmountAccounts.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmbrAmountAccounts.Name = "nmbrAmountAccounts";
            this.nmbrAmountAccounts.Size = new System.Drawing.Size(41, 20);
            this.nmbrAmountAccounts.TabIndex = 14;
            this.nmbrAmountAccounts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmbrAmountAccounts.ValueChanged += new System.EventHandler(this.nmbrAmountAccounts_ValueChanged);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 22);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(41, 13);
            this.lblAmount.TabIndex = 15;
            this.lblAmount.Text = "Create:";
            // 
            // chkRandomMail
            // 
            this.chkRandomMail.AutoSize = true;
            this.chkRandomMail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRandomMail.Location = new System.Drawing.Point(9, 46);
            this.chkRandomMail.Name = "chkRandomMail";
            this.chkRandomMail.Size = new System.Drawing.Size(88, 17);
            this.chkRandomMail.TabIndex = 16;
            this.chkRandomMail.Text = "Random Mail";
            this.chkRandomMail.UseVisualStyleBackColor = true;
            this.chkRandomMail.CheckedChanged += new System.EventHandler(this.ChkRandomMail_CheckedChanged);
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoSize = true;
            this.pnlSettings.Controls.Add(this.csgo);
            this.pnlSettings.Controls.Add(this.neatpassBox);
            this.pnlSettings.Controls.Add(this.NeatUsername);
            this.pnlSettings.Controls.Add(this.chkWriteIntoFile);
            this.pnlSettings.Controls.Add(this.chkAutoVerifyMail);
            this.pnlSettings.Controls.Add(this.chkRandomAlias);
            this.pnlSettings.Controls.Add(this.chkRandomPass);
            this.pnlSettings.Controls.Add(this.nmbrAmountAccounts);
            this.pnlSettings.Controls.Add(this.chkRandomMail);
            this.pnlSettings.Controls.Add(this.lblAmount);
            this.pnlSettings.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlSettings.Location = new System.Drawing.Point(15, 12);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(343, 105);
            this.pnlSettings.TabIndex = 17;
            this.pnlSettings.TabStop = false;
            this.pnlSettings.Text = "Settings";
            // 
            // csgo
            // 
            this.csgo.AccessibleName = "csgo";
            this.csgo.AutoSize = true;
            this.csgo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.csgo.Location = new System.Drawing.Point(232, 19);
            this.csgo.Margin = new System.Windows.Forms.Padding(2);
            this.csgo.Name = "csgo";
            this.csgo.Size = new System.Drawing.Size(78, 17);
            this.csgo.TabIndex = 24;
            this.csgo.Text = "Add CSGO";
            this.csgo.UseVisualStyleBackColor = true;
            this.csgo.CheckedChanged += new System.EventHandler(this.csgo_CheckedChanged);
            // 
            // neatpassBox
            // 
            this.neatpassBox.AccessibleName = "NeatPass";
            this.neatpassBox.AutoSize = true;
            this.neatpassBox.Checked = true;
            this.neatpassBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.neatpassBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.neatpassBox.Location = new System.Drawing.Point(232, 46);
            this.neatpassBox.Margin = new System.Windows.Forms.Padding(2);
            this.neatpassBox.Name = "neatpassBox";
            this.neatpassBox.Size = new System.Drawing.Size(98, 17);
            this.neatpassBox.TabIndex = 22;
            this.neatpassBox.Text = "Neat Password";
            this.neatpassBox.UseVisualStyleBackColor = true;
            this.neatpassBox.Visible = false;
            this.neatpassBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // NeatUsername
            // 
            this.NeatUsername.AccessibleName = "neatUsername";
            this.NeatUsername.AutoSize = true;
            this.NeatUsername.Checked = true;
            this.NeatUsername.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NeatUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NeatUsername.Location = new System.Drawing.Point(232, 67);
            this.NeatUsername.Margin = new System.Windows.Forms.Padding(2);
            this.NeatUsername.Name = "NeatUsername";
            this.NeatUsername.Size = new System.Drawing.Size(100, 17);
            this.NeatUsername.TabIndex = 21;
            this.NeatUsername.Text = "Neat Username";
            this.NeatUsername.UseVisualStyleBackColor = true;
            this.NeatUsername.Visible = false;
            this.NeatUsername.CheckedChanged += new System.EventHandler(this.NeatUsername_CheckedChanged);
            // 
            // chkWriteIntoFile
            // 
            this.chkWriteIntoFile.AutoSize = true;
            this.chkWriteIntoFile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkWriteIntoFile.Location = new System.Drawing.Point(108, 20);
            this.chkWriteIntoFile.Name = "chkWriteIntoFile";
            this.chkWriteIntoFile.Size = new System.Drawing.Size(117, 17);
            this.chkWriteIntoFile.TabIndex = 20;
            this.chkWriteIntoFile.Text = "Write Data Into File";
            this.chkWriteIntoFile.UseVisualStyleBackColor = true;
            this.chkWriteIntoFile.CheckedChanged += new System.EventHandler(this.ChkWriteIntoFile_CheckedChanged);
            // 
            // chkAutoVerifyMail
            // 
            this.chkAutoVerifyMail.AutoCheck = false;
            this.chkAutoVerifyMail.AutoSize = true;
            this.chkAutoVerifyMail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkAutoVerifyMail.Location = new System.Drawing.Point(108, 46);
            this.chkAutoVerifyMail.Name = "chkAutoVerifyMail";
            this.chkAutoVerifyMail.Size = new System.Drawing.Size(99, 17);
            this.chkAutoVerifyMail.TabIndex = 19;
            this.chkAutoVerifyMail.Text = "Auto Mail Verify";
            this.chkAutoVerifyMail.UseVisualStyleBackColor = true;
            this.chkAutoVerifyMail.CheckedChanged += new System.EventHandler(this.ChkAutoVerifyMail_CheckedChanged);
            // 
            // chkRandomAlias
            // 
            this.chkRandomAlias.AutoSize = true;
            this.chkRandomAlias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRandomAlias.Location = new System.Drawing.Point(108, 69);
            this.chkRandomAlias.Name = "chkRandomAlias";
            this.chkRandomAlias.Size = new System.Drawing.Size(91, 17);
            this.chkRandomAlias.TabIndex = 18;
            this.chkRandomAlias.Text = "Random Alias";
            this.chkRandomAlias.UseVisualStyleBackColor = true;
            this.chkRandomAlias.CheckedChanged += new System.EventHandler(this.ChkRandomAlias_CheckedChanged);
            // 
            // chkRandomPass
            // 
            this.chkRandomPass.AutoSize = true;
            this.chkRandomPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkRandomPass.Location = new System.Drawing.Point(9, 69);
            this.chkRandomPass.Name = "chkRandomPass";
            this.chkRandomPass.Size = new System.Drawing.Size(92, 17);
            this.chkRandomPass.TabIndex = 18;
            this.chkRandomPass.Text = "Random Pass";
            this.chkRandomPass.UseVisualStyleBackColor = true;
            this.chkRandomPass.CheckedChanged += new System.EventHandler(this.ChkRandomPass_CheckedChanged);
            // 
            // autocap
            // 
            this.autocap.AccessibleName = "Autocap";
            this.autocap.AutoSize = true;
            this.autocap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.autocap.Location = new System.Drawing.Point(10, 21);
            this.autocap.Margin = new System.Windows.Forms.Padding(2);
            this.autocap.Name = "autocap";
            this.autocap.Size = new System.Drawing.Size(91, 17);
            this.autocap.TabIndex = 23;
            this.autocap.Text = "Auto Captcha";
            this.autocap.UseVisualStyleBackColor = true;
            this.autocap.CheckedChanged += new System.EventHandler(this.autocap_CheckedChanged);
            // 
            // pnlCreation
            // 
            this.pnlCreation.AutoSize = true;
            this.pnlCreation.Controls.Add(this.btnCreateAccount);
            this.pnlCreation.Controls.Add(this.lblPass);
            this.pnlCreation.Controls.Add(this.lblAlias);
            this.pnlCreation.Controls.Add(this.txtPass);
            this.pnlCreation.Controls.Add(this.txtEmail);
            this.pnlCreation.Controls.Add(this.txtAlias);
            this.pnlCreation.Controls.Add(this.lblEmail);
            this.pnlCreation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCreation.Location = new System.Drawing.Point(15, 123);
            this.pnlCreation.Name = "pnlCreation";
            this.pnlCreation.Size = new System.Drawing.Size(343, 139);
            this.pnlCreation.TabIndex = 18;
            this.pnlCreation.TabStop = false;
            // 
            // dataAccounts
            // 
            this.dataAccounts.AllowUserToAddRows = false;
            this.dataAccounts.AllowUserToDeleteRows = false;
            this.dataAccounts.AllowUserToOrderColumns = true;
            this.dataAccounts.AllowUserToResizeRows = false;
            this.dataAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataAccounts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataAccounts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.dataAccounts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMail,
            this.colAlias,
            this.colPass,
            this.colSteamId,
            this.colStatus});
            this.dataAccounts.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataAccounts.Location = new System.Drawing.Point(364, 12);
            this.dataAccounts.MultiSelect = false;
            this.dataAccounts.Name = "dataAccounts";
            this.dataAccounts.ReadOnly = true;
            this.dataAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataAccounts.RowHeadersVisible = false;
            this.dataAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAccounts.Size = new System.Drawing.Size(450, 663);
            this.dataAccounts.TabIndex = 19;
            this.dataAccounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAccounts_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(15, 419);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 108);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Writing";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "User:Pass Formatting",
            "Original Formatting",
            "KeePass CSV Formatting"});
            this.comboBox1.Location = new System.Drawing.Point(9, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(321, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(121, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox4.Location = new System.Drawing.Point(9, 43);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(106, 17);
            this.checkBox4.TabIndex = 19;
            this.checkBox4.Text = "Custom Directory";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox7.Location = new System.Drawing.Point(9, 20);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(79, 17);
            this.checkBox7.TabIndex = 16;
            this.checkBox7.Text = "Write Email";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Location = new System.Drawing.Point(15, 533);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 70);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proxy Support";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(249, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 21);
            this.button2.TabIndex = 27;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(77, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Working: ?";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox2.Location = new System.Drawing.Point(194, 18);
            this.textBox2.MaxLength = 6;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(49, 20);
            this.textBox2.TabIndex = 24;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(80, 18);
            this.textBox1.MaxLength = 15;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 20);
            this.textBox1.TabIndex = 23;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox1.Location = new System.Drawing.Point(9, 21);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.Text = "Enabled";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.capHandMode);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.captwoapikey);
            this.groupBox3.Controls.Add(this.captchasolutions);
            this.groupBox3.Controls.Add(this.twocap);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.secretkey);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.apikey);
            this.groupBox3.Controls.Add(this.autocap);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(15, 267);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(343, 145);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Captcha Solving";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(7, 113);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "API Key";
            // 
            // captwoapikey
            // 
            this.captwoapikey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.captwoapikey.Enabled = false;
            this.captwoapikey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.captwoapikey.Location = new System.Drawing.Point(56, 110);
            this.captwoapikey.Margin = new System.Windows.Forms.Padding(2);
            this.captwoapikey.Name = "captwoapikey";
            this.captwoapikey.Size = new System.Drawing.Size(274, 20);
            this.captwoapikey.TabIndex = 30;
            // 
            // captchasolutions
            // 
            this.captchasolutions.AutoSize = true;
            this.captchasolutions.Checked = true;
            this.captchasolutions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.captchasolutions.Location = new System.Drawing.Point(10, 44);
            this.captchasolutions.Margin = new System.Windows.Forms.Padding(2);
            this.captchasolutions.Name = "captchasolutions";
            this.captchasolutions.Size = new System.Drawing.Size(106, 17);
            this.captchasolutions.TabIndex = 29;
            this.captchasolutions.TabStop = true;
            this.captchasolutions.Text = "Captchasolutions";
            this.captchasolutions.UseVisualStyleBackColor = true;
            this.captchasolutions.CheckedChanged += new System.EventHandler(this.captchasolutions_CheckedChanged);
            // 
            // twocap
            // 
            this.twocap.AutoSize = true;
            this.twocap.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.twocap.Location = new System.Drawing.Point(10, 89);
            this.twocap.Margin = new System.Windows.Forms.Padding(2);
            this.twocap.Name = "twocap";
            this.twocap.Size = new System.Drawing.Size(130, 17);
            this.twocap.TabIndex = 28;
            this.twocap.Text = "2Captcha/RuCaptcha";
            this.twocap.UseVisualStyleBackColor = true;
            this.twocap.CheckedChanged += new System.EventHandler(this.twocap_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(225, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Secret Key";
            // 
            // secretkey
            // 
            this.secretkey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.secretkey.Enabled = false;
            this.secretkey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.secretkey.Location = new System.Drawing.Point(228, 65);
            this.secretkey.Margin = new System.Windows.Forms.Padding(2);
            this.secretkey.Name = "secretkey";
            this.secretkey.Size = new System.Drawing.Size(102, 20);
            this.secretkey.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(7, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "API Key";
            // 
            // apikey
            // 
            this.apikey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.apikey.Enabled = false;
            this.apikey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.apikey.Location = new System.Drawing.Point(56, 65);
            this.apikey.Margin = new System.Windows.Forms.Padding(2);
            this.apikey.Name = "apikey";
            this.apikey.Size = new System.Drawing.Size(168, 20);
            this.apikey.TabIndex = 24;
            // 
            // colMail
            // 
            this.colMail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colMail.Frozen = true;
            this.colMail.HeaderText = "Mail";
            this.colMail.Name = "colMail";
            this.colMail.ReadOnly = true;
            this.colMail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colMail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colMail.Width = 32;
            // 
            // colAlias
            // 
            this.colAlias.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAlias.Frozen = true;
            this.colAlias.HeaderText = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.ReadOnly = true;
            this.colAlias.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colAlias.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAlias.Width = 35;
            // 
            // colPass
            // 
            this.colPass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPass.Frozen = true;
            this.colPass.HeaderText = "Pass";
            this.colPass.Name = "colPass";
            this.colPass.ReadOnly = true;
            this.colPass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPass.Width = 36;
            // 
            // colSteamId
            // 
            this.colSteamId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSteamId.Frozen = true;
            this.colSteamId.HeaderText = "Steam ID";
            this.colSteamId.Name = "colSteamId";
            this.colSteamId.ReadOnly = true;
            this.colSteamId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSteamId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSteamId.Width = 57;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStatus.Frozen = true;
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colStatus.Width = 651;
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.linkLabel2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox4.Location = new System.Drawing.Point(15, 609);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(343, 66);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "About";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(5, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Join Telegram For Updates: ";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(140, 20);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(128, 13);
            this.linkLabel2.TabIndex = 33;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://tele.click/sag_bot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Coded by: ";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(58, 37);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(149, 13);
            this.linkLabel1.TabIndex = 35;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://tele.click/dedsec1337";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // capHandMode
            // 
            this.capHandMode.AutoSize = true;
            this.capHandMode.Location = new System.Drawing.Point(106, 21);
            this.capHandMode.Name = "capHandMode";
            this.capHandMode.Size = new System.Drawing.Size(81, 17);
            this.capHandMode.TabIndex = 32;
            this.capHandMode.Text = "Hand mode";
            this.capHandMode.UseVisualStyleBackColor = true;
            this.capHandMode.CheckedChanged += new System.EventHandler(this.capHandMode_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(829, 692);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataAccounts);
            this.Controls.Add(this.pnlCreation);
            this.Controls.Add(this.pnlSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(845, 731);
            this.Name = "MainForm";
            this.Text = "Steam Account Creator - @DedSec1337";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmbrAmountAccounts)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.pnlCreation.ResumeLayout(false);
            this.pnlCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.NumericUpDown nmbrAmountAccounts;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.CheckBox chkRandomMail;
        private System.Windows.Forms.GroupBox pnlSettings;
        private System.Windows.Forms.CheckBox chkWriteIntoFile;
        private System.Windows.Forms.CheckBox chkAutoVerifyMail;
        private System.Windows.Forms.CheckBox chkRandomAlias;
        private System.Windows.Forms.CheckBox chkRandomPass;
        private System.Windows.Forms.GroupBox pnlCreation;
        private System.Windows.Forms.DataGridView dataAccounts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox7;
        public System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox NeatUsername;
        private System.Windows.Forms.CheckBox neatpassBox;
        private System.Windows.Forms.CheckBox autocap;
        private System.Windows.Forms.CheckBox csgo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox secretkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apikey;
        private System.Windows.Forms.RadioButton captchasolutions;
        private System.Windows.Forms.RadioButton twocap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox captwoapikey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSteamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.CheckBox capHandMode;
    }
}

