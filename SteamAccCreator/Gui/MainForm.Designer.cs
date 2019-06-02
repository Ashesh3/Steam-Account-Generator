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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblAlias = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.pnlCreation = new System.Windows.Forms.GroupBox();
            this.dataAccounts = new System.Windows.Forms.DataGridView();
            this.colMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSteamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.LinkHowToFindSubId = new System.Windows.Forms.LinkLabel();
            this.BtnExportGames = new System.Windows.Forms.Button();
            this.BtnClearGames = new System.Windows.Forms.Button();
            this.BtnRemoveGame = new System.Windows.Forms.Button();
            this.BtnAddGame = new System.Windows.Forms.Button();
            this.BtnLoadIds = new System.Windows.Forms.Button();
            this.ListGames = new System.Windows.Forms.ListBox();
            this.CbAddGames = new System.Windows.Forms.CheckBox();
            this.CbRandomPassword = new System.Windows.Forms.CheckBox();
            this.CbNeatPassword = new System.Windows.Forms.CheckBox();
            this.CbNeatLogin = new System.Windows.Forms.CheckBox();
            this.CbRandomLogin = new System.Windows.Forms.CheckBox();
            this.CbRandomMail = new System.Windows.Forms.CheckBox();
            this.NumAccountsCount = new System.Windows.Forms.NumericUpDown();
            this.LabAccountsCount = new System.Windows.Forms.Label();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.BtnProfileRmImg = new System.Windows.Forms.Button();
            this.CbProfileEnabled = new System.Windows.Forms.CheckBox();
            this.CbProfileUrl = new System.Windows.Forms.CheckBox();
            this.TbProfileCity = new System.Windows.Forms.TextBox();
            this.TbProfileState = new System.Windows.Forms.TextBox();
            this.TbProfileCountry = new System.Windows.Forms.TextBox();
            this.LabProfileCity = new System.Windows.Forms.Label();
            this.LabProfileState = new System.Windows.Forms.Label();
            this.LabProfileCountry = new System.Windows.Forms.Label();
            this.TbProfileImagePath = new System.Windows.Forms.TextBox();
            this.BtnProfileSelectImg = new System.Windows.Forms.Button();
            this.LabProfileImage = new System.Windows.Forms.Label();
            this.PbProfile = new System.Windows.Forms.PictureBox();
            this.TbProfileBio = new System.Windows.Forms.TextBox();
            this.LabProfileBio = new System.Windows.Forms.Label();
            this.TbProfileRealName = new System.Windows.Forms.TextBox();
            this.LabProfileRealName = new System.Windows.Forms.Label();
            this.TbProfileName = new System.Windows.Forms.TextBox();
            this.LabProfileName = new System.Windows.Forms.Label();
            this.tabCaptcha = new System.Windows.Forms.TabPage();
            this.GbCapTwoCaptcha = new System.Windows.Forms.GroupBox();
            this.CbCapTwoCaptchaReportBad = new System.Windows.Forms.CheckBox();
            this.LbCapTwoCaptchaKey = new System.Windows.Forms.Label();
            this.TbCapTwoCaptchaKey = new System.Windows.Forms.TextBox();
            this.GbCapCaptchasolutions = new System.Windows.Forms.GroupBox();
            this.LbCapCaptchasolutionsSectet = new System.Windows.Forms.Label();
            this.LbCapCaptchasolutionsKey = new System.Windows.Forms.Label();
            this.TbCapCaptchasolutionsSectet = new System.Windows.Forms.TextBox();
            this.TbCapCaptchasolutionsKey = new System.Windows.Forms.TextBox();
            this.LbCapSolver = new System.Windows.Forms.Label();
            this.CbCapSolver = new System.Windows.Forms.ComboBox();
            this.tabFileWriting = new System.Windows.Forms.TabPage();
            this.LinkFwPath = new System.Windows.Forms.LinkLabel();
            this.BtnFwChangeFolder = new System.Windows.Forms.Button();
            this.LabFwPath = new System.Windows.Forms.Label();
            this.CbFwOutType = new System.Windows.Forms.ComboBox();
            this.CbFwMail = new System.Windows.Forms.CheckBox();
            this.CbFwEnable = new System.Windows.Forms.CheckBox();
            this.tabProxy = new System.Windows.Forms.TabPage();
            this.BtnProxyTestCancel = new System.Windows.Forms.Button();
            this.LabProxyTotal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.LabProxyDisabled = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LabProxyGood = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabProxyBad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnProxyLoad = new System.Windows.Forms.Button();
            this.DgvProxyList = new System.Windows.Forms.DataGridView();
            this.BtnProxyTest = new System.Windows.Forms.Button();
            this.CbProxyEnabled = new System.Windows.Forms.CheckBox();
            this.tabModules = new System.Windows.Forms.TabPage();
            this.DgvModules = new System.Windows.Forms.DataGridView();
            this.Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabUpdates = new System.Windows.Forms.TabPage();
            this.BtnUpdateNotes = new System.Windows.Forms.Button();
            this.LbCurrentversionStr = new System.Windows.Forms.Label();
            this.LbServerVersionStr = new System.Windows.Forms.Label();
            this.BtnDlLatestBuild = new System.Windows.Forms.Button();
            this.LbCurrentVersion = new System.Windows.Forms.Label();
            this.LbServerVersion = new System.Windows.Forms.Label();
            this.CbUpdateChannel = new System.Windows.Forms.ComboBox();
            this.LbUpdateChannel = new System.Windows.Forms.Label();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.LinkAboutSmthBy = new System.Windows.Forms.LinkLabel();
            this.LabAboutSmthBy = new System.Windows.Forms.Label();
            this.LinkAboutCodedBy = new System.Windows.Forms.LinkLabel();
            this.LabAboutCodedBy = new System.Windows.Forms.Label();
            this.LinkAboutUpdates = new System.Windows.Forms.LinkLabel();
            this.LabAboutTelegram = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.profileConfigBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BsCaptchaTwoCapConfig = new System.Windows.Forms.BindingSource(this.components);
            this.BsCaptchaCapsolConfig = new System.Windows.Forms.BindingSource(this.components);
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxyTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxyItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enabledDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.versionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsModules = new System.Windows.Forms.BindingSource(this.components);
            this.LabAboutDiscord = new System.Windows.Forms.Label();
            this.LinkAboutDiscord = new System.Windows.Forms.LinkLabel();
            this.pnlCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAccountsCount)).BeginInit();
            this.tabProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbProfile)).BeginInit();
            this.tabCaptcha.SuspendLayout();
            this.GbCapTwoCaptcha.SuspendLayout();
            this.GbCapCaptchasolutions.SuspendLayout();
            this.tabFileWriting.SuspendLayout();
            this.tabProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProxyList)).BeginInit();
            this.tabModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvModules)).BeginInit();
            this.tabUpdates.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileConfigBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsCaptchaTwoCapConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsCaptchaCapsolConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsModules)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(47, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(267, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCreateAccount.Location = new System.Drawing.Point(9, 97);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(305, 23);
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
            this.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlias.ForeColor = System.Drawing.Color.White;
            this.txtAlias.Location = new System.Drawing.Point(47, 45);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(267, 20);
            this.txtAlias.TabIndex = 2;
            this.txtAlias.TextChanged += new System.EventHandler(this.txtAlias_TextChanged);
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.ForeColor = System.Drawing.Color.White;
            this.txtPass.Location = new System.Drawing.Point(47, 71);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(267, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // lblAlias
            // 
            this.lblAlias.AutoSize = true;
            this.lblAlias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblAlias.Location = new System.Drawing.Point(6, 48);
            this.lblAlias.Name = "lblAlias";
            this.lblAlias.Size = new System.Drawing.Size(36, 13);
            this.lblAlias.TabIndex = 12;
            this.lblAlias.Text = "Login:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPass.Location = new System.Drawing.Point(6, 74);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(33, 13);
            this.lblPass.TabIndex = 13;
            this.lblPass.Text = "Pass:";
            // 
            // pnlCreation
            // 
            this.pnlCreation.Controls.Add(this.btnCreateAccount);
            this.pnlCreation.Controls.Add(this.lblPass);
            this.pnlCreation.Controls.Add(this.lblAlias);
            this.pnlCreation.Controls.Add(this.txtPass);
            this.pnlCreation.Controls.Add(this.txtEmail);
            this.pnlCreation.Controls.Add(this.txtAlias);
            this.pnlCreation.Controls.Add(this.lblEmail);
            this.pnlCreation.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlCreation.Location = new System.Drawing.Point(12, 340);
            this.pnlCreation.Name = "pnlCreation";
            this.pnlCreation.Size = new System.Drawing.Size(324, 132);
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
            this.dataAccounts.Location = new System.Drawing.Point(342, 12);
            this.dataAccounts.MultiSelect = false;
            this.dataAccounts.Name = "dataAccounts";
            this.dataAccounts.ReadOnly = true;
            this.dataAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataAccounts.RowHeadersVisible = false;
            this.dataAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAccounts.Size = new System.Drawing.Size(430, 460);
            this.dataAccounts.TabIndex = 19;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabConfig);
            this.tabControl.Controls.Add(this.tabProfile);
            this.tabControl.Controls.Add(this.tabCaptcha);
            this.tabControl.Controls.Add(this.tabFileWriting);
            this.tabControl.Controls.Add(this.tabProxy);
            this.tabControl.Controls.Add(this.tabModules);
            this.tabControl.Controls.Add(this.tabUpdates);
            this.tabControl.Controls.Add(this.tabAbout);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(324, 322);
            this.tabControl.TabIndex = 26;
            // 
            // tabConfig
            // 
            this.tabConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabConfig.Controls.Add(this.LinkHowToFindSubId);
            this.tabConfig.Controls.Add(this.BtnExportGames);
            this.tabConfig.Controls.Add(this.BtnClearGames);
            this.tabConfig.Controls.Add(this.BtnRemoveGame);
            this.tabConfig.Controls.Add(this.BtnAddGame);
            this.tabConfig.Controls.Add(this.BtnLoadIds);
            this.tabConfig.Controls.Add(this.ListGames);
            this.tabConfig.Controls.Add(this.CbAddGames);
            this.tabConfig.Controls.Add(this.CbRandomPassword);
            this.tabConfig.Controls.Add(this.CbNeatPassword);
            this.tabConfig.Controls.Add(this.CbNeatLogin);
            this.tabConfig.Controls.Add(this.CbRandomLogin);
            this.tabConfig.Controls.Add(this.CbRandomMail);
            this.tabConfig.Controls.Add(this.NumAccountsCount);
            this.tabConfig.Controls.Add(this.LabAccountsCount);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(316, 296);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.Text = "Settings";
            // 
            // LinkHowToFindSubId
            // 
            this.LinkHowToFindSubId.AutoSize = true;
            this.LinkHowToFindSubId.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkHowToFindSubId.Location = new System.Drawing.Point(215, 95);
            this.LinkHowToFindSubId.Name = "LinkHowToFindSubId";
            this.LinkHowToFindSubId.Size = new System.Drawing.Size(95, 13);
            this.LinkHowToFindSubId.TabIndex = 29;
            this.LinkHowToFindSubId.TabStop = true;
            this.LinkHowToFindSubId.Text = "How to find sub ID";
            this.LinkHowToFindSubId.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkHowToFindSubId.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkHowToFindSubId_LinkClicked);
            // 
            // BtnExportGames
            // 
            this.BtnExportGames.Location = new System.Drawing.Point(90, 263);
            this.BtnExportGames.Name = "BtnExportGames";
            this.BtnExportGames.Size = new System.Drawing.Size(75, 23);
            this.BtnExportGames.TabIndex = 28;
            this.BtnExportGames.Text = "Export IDs";
            this.BtnExportGames.UseVisualStyleBackColor = true;
            this.BtnExportGames.Click += new System.EventHandler(this.BtnExportGames_Click);
            // 
            // BtnClearGames
            // 
            this.BtnClearGames.Location = new System.Drawing.Point(264, 263);
            this.BtnClearGames.Name = "BtnClearGames";
            this.BtnClearGames.Size = new System.Drawing.Size(46, 23);
            this.BtnClearGames.TabIndex = 27;
            this.BtnClearGames.Text = "Clear";
            this.BtnClearGames.UseVisualStyleBackColor = true;
            this.BtnClearGames.Click += new System.EventHandler(this.BtnClearGames_Click);
            // 
            // BtnRemoveGame
            // 
            this.BtnRemoveGame.Location = new System.Drawing.Point(232, 263);
            this.BtnRemoveGame.Name = "BtnRemoveGame";
            this.BtnRemoveGame.Size = new System.Drawing.Size(26, 23);
            this.BtnRemoveGame.TabIndex = 26;
            this.BtnRemoveGame.Text = "-";
            this.BtnRemoveGame.UseVisualStyleBackColor = true;
            this.BtnRemoveGame.Click += new System.EventHandler(this.BtnRemoveGame_Click);
            // 
            // BtnAddGame
            // 
            this.BtnAddGame.Location = new System.Drawing.Point(200, 263);
            this.BtnAddGame.Name = "BtnAddGame";
            this.BtnAddGame.Size = new System.Drawing.Size(26, 23);
            this.BtnAddGame.TabIndex = 25;
            this.BtnAddGame.Text = "+";
            this.BtnAddGame.UseVisualStyleBackColor = true;
            this.BtnAddGame.Click += new System.EventHandler(this.BtnAddGame_Click);
            // 
            // BtnLoadIds
            // 
            this.BtnLoadIds.Location = new System.Drawing.Point(9, 263);
            this.BtnLoadIds.Name = "BtnLoadIds";
            this.BtnLoadIds.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadIds.TabIndex = 24;
            this.BtnLoadIds.Text = "Load IDs";
            this.BtnLoadIds.UseVisualStyleBackColor = true;
            this.BtnLoadIds.Click += new System.EventHandler(this.BtnLoadIds_Click);
            // 
            // ListGames
            // 
            this.ListGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.ListGames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListGames.ForeColor = System.Drawing.Color.White;
            this.ListGames.FormattingEnabled = true;
            this.ListGames.Location = new System.Drawing.Point(9, 114);
            this.ListGames.Name = "ListGames";
            this.ListGames.Size = new System.Drawing.Size(301, 145);
            this.ListGames.TabIndex = 23;
            this.ListGames.SelectedIndexChanged += new System.EventHandler(this.ListGames_SelectedIndexChanged);
            this.ListGames.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ListGames_Format);
            this.ListGames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListGames_MouseDoubleClick);
            // 
            // CbAddGames
            // 
            this.CbAddGames.AutoSize = true;
            this.CbAddGames.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbAddGames.Location = new System.Drawing.Point(9, 91);
            this.CbAddGames.Name = "CbAddGames";
            this.CbAddGames.Size = new System.Drawing.Size(117, 17);
            this.CbAddGames.TabIndex = 21;
            this.CbAddGames.Text = "Add games from list";
            this.CbAddGames.UseVisualStyleBackColor = true;
            this.CbAddGames.CheckedChanged += new System.EventHandler(this.CbAddGames_CheckedChanged);
            // 
            // CbRandomPassword
            // 
            this.CbRandomPassword.AutoSize = true;
            this.CbRandomPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbRandomPassword.Location = new System.Drawing.Point(9, 68);
            this.CbRandomPassword.Name = "CbRandomPassword";
            this.CbRandomPassword.Size = new System.Drawing.Size(114, 17);
            this.CbRandomPassword.TabIndex = 20;
            this.CbRandomPassword.Text = "Random password";
            this.CbRandomPassword.UseVisualStyleBackColor = true;
            this.CbRandomPassword.CheckedChanged += new System.EventHandler(this.CbRandomPassword_CheckedChanged);
            // 
            // CbNeatPassword
            // 
            this.CbNeatPassword.AutoSize = true;
            this.CbNeatPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbNeatPassword.Location = new System.Drawing.Point(125, 68);
            this.CbNeatPassword.Name = "CbNeatPassword";
            this.CbNeatPassword.Size = new System.Drawing.Size(97, 17);
            this.CbNeatPassword.TabIndex = 19;
            this.CbNeatPassword.Text = "Neat password";
            this.CbNeatPassword.UseVisualStyleBackColor = true;
            this.CbNeatPassword.CheckedChanged += new System.EventHandler(this.CbNeatPassword_CheckedChanged);
            // 
            // CbNeatLogin
            // 
            this.CbNeatLogin.AutoSize = true;
            this.CbNeatLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbNeatLogin.Location = new System.Drawing.Point(125, 45);
            this.CbNeatLogin.Name = "CbNeatLogin";
            this.CbNeatLogin.Size = new System.Drawing.Size(74, 17);
            this.CbNeatLogin.TabIndex = 18;
            this.CbNeatLogin.Text = "Neat login";
            this.CbNeatLogin.UseVisualStyleBackColor = true;
            this.CbNeatLogin.CheckedChanged += new System.EventHandler(this.CbNeatLogin_CheckedChanged);
            // 
            // CbRandomLogin
            // 
            this.CbRandomLogin.AutoSize = true;
            this.CbRandomLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbRandomLogin.Location = new System.Drawing.Point(9, 45);
            this.CbRandomLogin.Name = "CbRandomLogin";
            this.CbRandomLogin.Size = new System.Drawing.Size(91, 17);
            this.CbRandomLogin.TabIndex = 17;
            this.CbRandomLogin.Text = "Random login";
            this.CbRandomLogin.UseVisualStyleBackColor = true;
            this.CbRandomLogin.CheckedChanged += new System.EventHandler(this.CbRandomLogin_CheckedChanged);
            // 
            // CbRandomMail
            // 
            this.CbRandomMail.AutoSize = true;
            this.CbRandomMail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbRandomMail.Location = new System.Drawing.Point(125, 22);
            this.CbRandomMail.Name = "CbRandomMail";
            this.CbRandomMail.Size = new System.Drawing.Size(87, 17);
            this.CbRandomMail.TabIndex = 16;
            this.CbRandomMail.Text = "Random mail";
            this.CbRandomMail.UseVisualStyleBackColor = true;
            this.CbRandomMail.CheckedChanged += new System.EventHandler(this.CbRandomMail_CheckedChanged);
            // 
            // NumAccountsCount
            // 
            this.NumAccountsCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.NumAccountsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumAccountsCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NumAccountsCount.Location = new System.Drawing.Point(9, 19);
            this.NumAccountsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumAccountsCount.Name = "NumAccountsCount";
            this.NumAccountsCount.Size = new System.Drawing.Size(97, 20);
            this.NumAccountsCount.TabIndex = 15;
            this.NumAccountsCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // LabAccountsCount
            // 
            this.LabAccountsCount.AutoSize = true;
            this.LabAccountsCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabAccountsCount.Location = new System.Drawing.Point(6, 3);
            this.LabAccountsCount.Name = "LabAccountsCount";
            this.LabAccountsCount.Size = new System.Drawing.Size(100, 13);
            this.LabAccountsCount.TabIndex = 0;
            this.LabAccountsCount.Text = "Accounts to create:";
            // 
            // tabProfile
            // 
            this.tabProfile.AutoScroll = true;
            this.tabProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabProfile.Controls.Add(this.BtnProfileRmImg);
            this.tabProfile.Controls.Add(this.CbProfileEnabled);
            this.tabProfile.Controls.Add(this.CbProfileUrl);
            this.tabProfile.Controls.Add(this.TbProfileCity);
            this.tabProfile.Controls.Add(this.TbProfileState);
            this.tabProfile.Controls.Add(this.TbProfileCountry);
            this.tabProfile.Controls.Add(this.LabProfileCity);
            this.tabProfile.Controls.Add(this.LabProfileState);
            this.tabProfile.Controls.Add(this.LabProfileCountry);
            this.tabProfile.Controls.Add(this.TbProfileImagePath);
            this.tabProfile.Controls.Add(this.BtnProfileSelectImg);
            this.tabProfile.Controls.Add(this.LabProfileImage);
            this.tabProfile.Controls.Add(this.PbProfile);
            this.tabProfile.Controls.Add(this.TbProfileBio);
            this.tabProfile.Controls.Add(this.LabProfileBio);
            this.tabProfile.Controls.Add(this.TbProfileRealName);
            this.tabProfile.Controls.Add(this.LabProfileRealName);
            this.tabProfile.Controls.Add(this.TbProfileName);
            this.tabProfile.Controls.Add(this.LabProfileName);
            this.tabProfile.ForeColor = System.Drawing.Color.White;
            this.tabProfile.Location = new System.Drawing.Point(4, 22);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(316, 296);
            this.tabProfile.TabIndex = 6;
            this.tabProfile.Text = "Profile";
            // 
            // BtnProfileRmImg
            // 
            this.BtnProfileRmImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProfileRmImg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnProfileRmImg.Location = new System.Drawing.Point(136, 218);
            this.BtnProfileRmImg.Name = "BtnProfileRmImg";
            this.BtnProfileRmImg.Size = new System.Drawing.Size(103, 23);
            this.BtnProfileRmImg.TabIndex = 11;
            this.BtnProfileRmImg.Text = "Remove image";
            this.BtnProfileRmImg.UseVisualStyleBackColor = true;
            this.BtnProfileRmImg.Click += new System.EventHandler(this.BtnProfileRmImg_Click);
            // 
            // CbProfileEnabled
            // 
            this.CbProfileEnabled.AutoSize = true;
            this.CbProfileEnabled.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.profileConfigBindingSource, "Enabled", true));
            this.CbProfileEnabled.Location = new System.Drawing.Point(9, 6);
            this.CbProfileEnabled.Name = "CbProfileEnabled";
            this.CbProfileEnabled.Size = new System.Drawing.Size(59, 17);
            this.CbProfileEnabled.TabIndex = 0;
            this.CbProfileEnabled.Text = "Enable";
            this.CbProfileEnabled.UseVisualStyleBackColor = true;
            // 
            // CbProfileUrl
            // 
            this.CbProfileUrl.AutoSize = true;
            this.CbProfileUrl.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.profileConfigBindingSource, "Url", true));
            this.CbProfileUrl.Location = new System.Drawing.Point(9, 81);
            this.CbProfileUrl.Name = "CbProfileUrl";
            this.CbProfileUrl.Size = new System.Drawing.Size(230, 17);
            this.CbProfileUrl.TabIndex = 5;
            this.CbProfileUrl.Text = "Url: https://steamcommunity.com/id/{login}";
            this.CbProfileUrl.UseVisualStyleBackColor = true;
            // 
            // TbProfileCity
            // 
            this.TbProfileCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProfileCity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProfileCity.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "City", true));
            this.TbProfileCity.ForeColor = System.Drawing.Color.White;
            this.TbProfileCity.Location = new System.Drawing.Point(187, 260);
            this.TbProfileCity.MaxLength = 10;
            this.TbProfileCity.Name = "TbProfileCity";
            this.TbProfileCity.Size = new System.Drawing.Size(123, 20);
            this.TbProfileCity.TabIndex = 17;
            // 
            // TbProfileState
            // 
            this.TbProfileState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProfileState.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "State", true));
            this.TbProfileState.ForeColor = System.Drawing.Color.White;
            this.TbProfileState.Location = new System.Drawing.Point(58, 260);
            this.TbProfileState.MaxLength = 10;
            this.TbProfileState.Name = "TbProfileState";
            this.TbProfileState.Size = new System.Drawing.Size(124, 20);
            this.TbProfileState.TabIndex = 15;
            // 
            // TbProfileCountry
            // 
            this.TbProfileCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProfileCountry.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "Country", true));
            this.TbProfileCountry.ForeColor = System.Drawing.Color.White;
            this.TbProfileCountry.Location = new System.Drawing.Point(9, 260);
            this.TbProfileCountry.MaxLength = 10;
            this.TbProfileCountry.Name = "TbProfileCountry";
            this.TbProfileCountry.Size = new System.Drawing.Size(43, 20);
            this.TbProfileCountry.TabIndex = 13;
            // 
            // LabProfileCity
            // 
            this.LabProfileCity.AutoSize = true;
            this.LabProfileCity.Location = new System.Drawing.Point(184, 244);
            this.LabProfileCity.Name = "LabProfileCity";
            this.LabProfileCity.Size = new System.Drawing.Size(27, 13);
            this.LabProfileCity.TabIndex = 16;
            this.LabProfileCity.Text = "City:";
            // 
            // LabProfileState
            // 
            this.LabProfileState.AutoSize = true;
            this.LabProfileState.Location = new System.Drawing.Point(58, 244);
            this.LabProfileState.Name = "LabProfileState";
            this.LabProfileState.Size = new System.Drawing.Size(124, 13);
            this.LabProfileState.TabIndex = 14;
            this.LabProfileState.Text = "State/Province/City/etc:";
            // 
            // LabProfileCountry
            // 
            this.LabProfileCountry.AutoSize = true;
            this.LabProfileCountry.Location = new System.Drawing.Point(6, 244);
            this.LabProfileCountry.Name = "LabProfileCountry";
            this.LabProfileCountry.Size = new System.Drawing.Size(46, 13);
            this.LabProfileCountry.TabIndex = 12;
            this.LabProfileCountry.Text = "Country:";
            // 
            // TbProfileImagePath
            // 
            this.TbProfileImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProfileImagePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileImagePath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbProfileImagePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "Image", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, "none selected"));
            this.TbProfileImagePath.ForeColor = System.Drawing.Color.White;
            this.TbProfileImagePath.Location = new System.Drawing.Point(9, 199);
            this.TbProfileImagePath.Name = "TbProfileImagePath";
            this.TbProfileImagePath.ReadOnly = true;
            this.TbProfileImagePath.Size = new System.Drawing.Size(231, 13);
            this.TbProfileImagePath.TabIndex = 9;
            this.TbProfileImagePath.Text = "~/home/meme.png";
            // 
            // BtnProfileSelectImg
            // 
            this.BtnProfileSelectImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProfileSelectImg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnProfileSelectImg.Location = new System.Drawing.Point(9, 218);
            this.BtnProfileSelectImg.Name = "BtnProfileSelectImg";
            this.BtnProfileSelectImg.Size = new System.Drawing.Size(121, 23);
            this.BtnProfileSelectImg.TabIndex = 10;
            this.BtnProfileSelectImg.Text = "Select image";
            this.BtnProfileSelectImg.UseVisualStyleBackColor = true;
            this.BtnProfileSelectImg.Click += new System.EventHandler(this.BtnProfileSelectImg_Click);
            // 
            // LabProfileImage
            // 
            this.LabProfileImage.AutoSize = true;
            this.LabProfileImage.Location = new System.Drawing.Point(6, 183);
            this.LabProfileImage.Name = "LabProfileImage";
            this.LabProfileImage.Size = new System.Drawing.Size(39, 13);
            this.LabProfileImage.TabIndex = 8;
            this.LabProfileImage.Text = "Image:";
            // 
            // PbProfile
            // 
            this.PbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PbProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PbProfile.DataBindings.Add(new System.Windows.Forms.Binding("ImageLocation", this.profileConfigBindingSource, "Image", true));
            this.PbProfile.ImageLocation = "";
            this.PbProfile.Location = new System.Drawing.Point(246, 177);
            this.PbProfile.Name = "PbProfile";
            this.PbProfile.Size = new System.Drawing.Size(64, 64);
            this.PbProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbProfile.TabIndex = 8;
            this.PbProfile.TabStop = false;
            // 
            // TbProfileBio
            // 
            this.TbProfileBio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProfileBio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileBio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProfileBio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "Bio", true));
            this.TbProfileBio.ForeColor = System.Drawing.Color.White;
            this.TbProfileBio.Location = new System.Drawing.Point(37, 101);
            this.TbProfileBio.Multiline = true;
            this.TbProfileBio.Name = "TbProfileBio";
            this.TbProfileBio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbProfileBio.Size = new System.Drawing.Size(273, 70);
            this.TbProfileBio.TabIndex = 7;
            // 
            // LabProfileBio
            // 
            this.LabProfileBio.AutoSize = true;
            this.LabProfileBio.Location = new System.Drawing.Point(6, 101);
            this.LabProfileBio.Name = "LabProfileBio";
            this.LabProfileBio.Size = new System.Drawing.Size(25, 13);
            this.LabProfileBio.TabIndex = 6;
            this.LabProfileBio.Text = "Bio:";
            // 
            // TbProfileRealName
            // 
            this.TbProfileRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProfileRealName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileRealName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProfileRealName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "RealName", true));
            this.TbProfileRealName.ForeColor = System.Drawing.Color.White;
            this.TbProfileRealName.Location = new System.Drawing.Point(73, 55);
            this.TbProfileRealName.Name = "TbProfileRealName";
            this.TbProfileRealName.Size = new System.Drawing.Size(237, 20);
            this.TbProfileRealName.TabIndex = 4;
            // 
            // LabProfileRealName
            // 
            this.LabProfileRealName.AutoSize = true;
            this.LabProfileRealName.Location = new System.Drawing.Point(6, 58);
            this.LabProfileRealName.Name = "LabProfileRealName";
            this.LabProfileRealName.Size = new System.Drawing.Size(61, 13);
            this.LabProfileRealName.TabIndex = 3;
            this.LabProfileRealName.Text = "Real name:";
            // 
            // TbProfileName
            // 
            this.TbProfileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbProfileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbProfileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbProfileName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.profileConfigBindingSource, "Name", true));
            this.TbProfileName.ForeColor = System.Drawing.Color.White;
            this.TbProfileName.Location = new System.Drawing.Point(50, 29);
            this.TbProfileName.Name = "TbProfileName";
            this.TbProfileName.Size = new System.Drawing.Size(260, 20);
            this.TbProfileName.TabIndex = 2;
            // 
            // LabProfileName
            // 
            this.LabProfileName.AutoSize = true;
            this.LabProfileName.Location = new System.Drawing.Point(6, 31);
            this.LabProfileName.Name = "LabProfileName";
            this.LabProfileName.Size = new System.Drawing.Size(38, 13);
            this.LabProfileName.TabIndex = 1;
            this.LabProfileName.Text = "Name:";
            // 
            // tabCaptcha
            // 
            this.tabCaptcha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabCaptcha.Controls.Add(this.GbCapTwoCaptcha);
            this.tabCaptcha.Controls.Add(this.GbCapCaptchasolutions);
            this.tabCaptcha.Controls.Add(this.LbCapSolver);
            this.tabCaptcha.Controls.Add(this.CbCapSolver);
            this.tabCaptcha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabCaptcha.Location = new System.Drawing.Point(4, 22);
            this.tabCaptcha.Name = "tabCaptcha";
            this.tabCaptcha.Padding = new System.Windows.Forms.Padding(3);
            this.tabCaptcha.Size = new System.Drawing.Size(316, 296);
            this.tabCaptcha.TabIndex = 1;
            this.tabCaptcha.Text = "Captcha";
            // 
            // GbCapTwoCaptcha
            // 
            this.GbCapTwoCaptcha.Controls.Add(this.CbCapTwoCaptchaReportBad);
            this.GbCapTwoCaptcha.Controls.Add(this.LbCapTwoCaptchaKey);
            this.GbCapTwoCaptcha.Controls.Add(this.TbCapTwoCaptchaKey);
            this.GbCapTwoCaptcha.ForeColor = System.Drawing.Color.White;
            this.GbCapTwoCaptcha.Location = new System.Drawing.Point(6, 111);
            this.GbCapTwoCaptcha.Name = "GbCapTwoCaptcha";
            this.GbCapTwoCaptcha.Size = new System.Drawing.Size(304, 68);
            this.GbCapTwoCaptcha.TabIndex = 14;
            this.GbCapTwoCaptcha.TabStop = false;
            this.GbCapTwoCaptcha.Text = "2Captcha/RuCaptcha";
            // 
            // CbCapTwoCaptchaReportBad
            // 
            this.CbCapTwoCaptchaReportBad.AutoSize = true;
            this.CbCapTwoCaptchaReportBad.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.BsCaptchaTwoCapConfig, "ReportBad", true));
            this.CbCapTwoCaptchaReportBad.ForeColor = System.Drawing.Color.White;
            this.CbCapTwoCaptchaReportBad.Location = new System.Drawing.Point(9, 45);
            this.CbCapTwoCaptchaReportBad.Name = "CbCapTwoCaptchaReportBad";
            this.CbCapTwoCaptchaReportBad.Size = new System.Drawing.Size(139, 17);
            this.CbCapTwoCaptchaReportBad.TabIndex = 2;
            this.CbCapTwoCaptchaReportBad.Text = "Report if not recognized";
            this.CbCapTwoCaptchaReportBad.UseVisualStyleBackColor = true;
            // 
            // LbCapTwoCaptchaKey
            // 
            this.LbCapTwoCaptchaKey.AutoSize = true;
            this.LbCapTwoCaptchaKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LbCapTwoCaptchaKey.Location = new System.Drawing.Point(6, 21);
            this.LbCapTwoCaptchaKey.Name = "LbCapTwoCaptchaKey";
            this.LbCapTwoCaptchaKey.Size = new System.Drawing.Size(48, 13);
            this.LbCapTwoCaptchaKey.TabIndex = 0;
            this.LbCapTwoCaptchaKey.Text = "API Key:";
            // 
            // TbCapTwoCaptchaKey
            // 
            this.TbCapTwoCaptchaKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbCapTwoCaptchaKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCapTwoCaptchaKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsCaptchaTwoCapConfig, "ApiKey", true));
            this.TbCapTwoCaptchaKey.ForeColor = System.Drawing.Color.White;
            this.TbCapTwoCaptchaKey.Location = new System.Drawing.Point(60, 19);
            this.TbCapTwoCaptchaKey.Name = "TbCapTwoCaptchaKey";
            this.TbCapTwoCaptchaKey.Size = new System.Drawing.Size(238, 20);
            this.TbCapTwoCaptchaKey.TabIndex = 1;
            // 
            // GbCapCaptchasolutions
            // 
            this.GbCapCaptchasolutions.Controls.Add(this.LbCapCaptchasolutionsSectet);
            this.GbCapCaptchasolutions.Controls.Add(this.LbCapCaptchasolutionsKey);
            this.GbCapCaptchasolutions.Controls.Add(this.TbCapCaptchasolutionsSectet);
            this.GbCapCaptchasolutions.Controls.Add(this.TbCapCaptchasolutionsKey);
            this.GbCapCaptchasolutions.ForeColor = System.Drawing.Color.White;
            this.GbCapCaptchasolutions.Location = new System.Drawing.Point(6, 33);
            this.GbCapCaptchasolutions.Name = "GbCapCaptchasolutions";
            this.GbCapCaptchasolutions.Size = new System.Drawing.Size(304, 72);
            this.GbCapCaptchasolutions.TabIndex = 13;
            this.GbCapCaptchasolutions.TabStop = false;
            this.GbCapCaptchasolutions.Text = "Captchasolutions";
            // 
            // LbCapCaptchasolutionsSectet
            // 
            this.LbCapCaptchasolutionsSectet.AutoSize = true;
            this.LbCapCaptchasolutionsSectet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LbCapCaptchasolutionsSectet.Location = new System.Drawing.Point(6, 47);
            this.LbCapCaptchasolutionsSectet.Name = "LbCapCaptchasolutionsSectet";
            this.LbCapCaptchasolutionsSectet.Size = new System.Drawing.Size(61, 13);
            this.LbCapCaptchasolutionsSectet.TabIndex = 2;
            this.LbCapCaptchasolutionsSectet.Text = "Secret key:";
            // 
            // LbCapCaptchasolutionsKey
            // 
            this.LbCapCaptchasolutionsKey.AutoSize = true;
            this.LbCapCaptchasolutionsKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LbCapCaptchasolutionsKey.Location = new System.Drawing.Point(19, 21);
            this.LbCapCaptchasolutionsKey.Name = "LbCapCaptchasolutionsKey";
            this.LbCapCaptchasolutionsKey.Size = new System.Drawing.Size(48, 13);
            this.LbCapCaptchasolutionsKey.TabIndex = 0;
            this.LbCapCaptchasolutionsKey.Text = "API Key:";
            // 
            // TbCapCaptchasolutionsSectet
            // 
            this.TbCapCaptchasolutionsSectet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbCapCaptchasolutionsSectet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCapCaptchasolutionsSectet.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsCaptchaCapsolConfig, "ApiSecret", true));
            this.TbCapCaptchasolutionsSectet.ForeColor = System.Drawing.Color.White;
            this.TbCapCaptchasolutionsSectet.Location = new System.Drawing.Point(73, 45);
            this.TbCapCaptchasolutionsSectet.Name = "TbCapCaptchasolutionsSectet";
            this.TbCapCaptchasolutionsSectet.Size = new System.Drawing.Size(225, 20);
            this.TbCapCaptchasolutionsSectet.TabIndex = 3;
            // 
            // TbCapCaptchasolutionsKey
            // 
            this.TbCapCaptchasolutionsKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbCapCaptchasolutionsKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCapCaptchasolutionsKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.BsCaptchaCapsolConfig, "ApiKey", true));
            this.TbCapCaptchasolutionsKey.ForeColor = System.Drawing.Color.White;
            this.TbCapCaptchasolutionsKey.Location = new System.Drawing.Point(73, 19);
            this.TbCapCaptchasolutionsKey.Name = "TbCapCaptchasolutionsKey";
            this.TbCapCaptchasolutionsKey.Size = new System.Drawing.Size(225, 20);
            this.TbCapCaptchasolutionsKey.TabIndex = 1;
            // 
            // LbCapSolver
            // 
            this.LbCapSolver.AutoSize = true;
            this.LbCapSolver.ForeColor = System.Drawing.Color.White;
            this.LbCapSolver.Location = new System.Drawing.Point(7, 9);
            this.LbCapSolver.Name = "LbCapSolver";
            this.LbCapSolver.Size = new System.Drawing.Size(109, 13);
            this.LbCapSolver.TabIndex = 12;
            this.LbCapSolver.Text = "Captcha solving type:";
            // 
            // CbCapSolver
            // 
            this.CbCapSolver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbCapSolver.FormattingEnabled = true;
            this.CbCapSolver.Items.AddRange(new object[] {
            "Hand mode",
            "Captchasolutions",
            "2Captcha | RuCaptcha",
            "Modules"});
            this.CbCapSolver.Location = new System.Drawing.Point(122, 6);
            this.CbCapSolver.Name = "CbCapSolver";
            this.CbCapSolver.Size = new System.Drawing.Size(188, 21);
            this.CbCapSolver.TabIndex = 11;
            this.CbCapSolver.SelectedIndexChanged += new System.EventHandler(this.CbCapSolver_SelectedIndexChanged);
            // 
            // tabFileWriting
            // 
            this.tabFileWriting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabFileWriting.Controls.Add(this.LinkFwPath);
            this.tabFileWriting.Controls.Add(this.BtnFwChangeFolder);
            this.tabFileWriting.Controls.Add(this.LabFwPath);
            this.tabFileWriting.Controls.Add(this.CbFwOutType);
            this.tabFileWriting.Controls.Add(this.CbFwMail);
            this.tabFileWriting.Controls.Add(this.CbFwEnable);
            this.tabFileWriting.Location = new System.Drawing.Point(4, 22);
            this.tabFileWriting.Name = "tabFileWriting";
            this.tabFileWriting.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileWriting.Size = new System.Drawing.Size(316, 296);
            this.tabFileWriting.TabIndex = 2;
            this.tabFileWriting.Text = "File writing";
            // 
            // LinkFwPath
            // 
            this.LinkFwPath.AutoSize = true;
            this.LinkFwPath.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkFwPath.Location = new System.Drawing.Point(35, 26);
            this.LinkFwPath.Name = "LinkFwPath";
            this.LinkFwPath.Size = new System.Drawing.Size(168, 13);
            this.LinkFwPath.TabIndex = 27;
            this.LinkFwPath.TabStop = true;
            this.LinkFwPath.Text = "/home/%username%/accounts.txt";
            this.LinkFwPath.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkFwPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkFwPath_LinkClicked);
            // 
            // BtnFwChangeFolder
            // 
            this.BtnFwChangeFolder.Location = new System.Drawing.Point(10, 42);
            this.BtnFwChangeFolder.Name = "BtnFwChangeFolder";
            this.BtnFwChangeFolder.Size = new System.Drawing.Size(300, 23);
            this.BtnFwChangeFolder.TabIndex = 26;
            this.BtnFwChangeFolder.Text = "Change directory";
            this.BtnFwChangeFolder.UseVisualStyleBackColor = true;
            this.BtnFwChangeFolder.Click += new System.EventHandler(this.BtnFwChangeFolder_Click);
            // 
            // LabFwPath
            // 
            this.LabFwPath.AutoSize = true;
            this.LabFwPath.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabFwPath.Location = new System.Drawing.Point(6, 26);
            this.LabFwPath.Name = "LabFwPath";
            this.LabFwPath.Size = new System.Drawing.Size(32, 13);
            this.LabFwPath.TabIndex = 25;
            this.LabFwPath.Text = "Path:";
            // 
            // CbFwOutType
            // 
            this.CbFwOutType.DisplayMember = "0";
            this.CbFwOutType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFwOutType.FormattingEnabled = true;
            this.CbFwOutType.Items.AddRange(new object[] {
            "User:Pass Formatting",
            "Original Formatting",
            "KeePass CSV Formatting"});
            this.CbFwOutType.Location = new System.Drawing.Point(10, 71);
            this.CbFwOutType.Name = "CbFwOutType";
            this.CbFwOutType.Size = new System.Drawing.Size(300, 21);
            this.CbFwOutType.TabIndex = 23;
            this.CbFwOutType.SelectedIndexChanged += new System.EventHandler(this.CbFwOutType_SelectedIndexChanged);
            // 
            // CbFwMail
            // 
            this.CbFwMail.AutoSize = true;
            this.CbFwMail.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbFwMail.Location = new System.Drawing.Point(91, 6);
            this.CbFwMail.Name = "CbFwMail";
            this.CbFwMail.Size = new System.Drawing.Size(72, 17);
            this.CbFwMail.TabIndex = 1;
            this.CbFwMail.Text = "Write mail";
            this.CbFwMail.UseVisualStyleBackColor = true;
            this.CbFwMail.CheckedChanged += new System.EventHandler(this.CbFwMail_CheckedChanged);
            // 
            // CbFwEnable
            // 
            this.CbFwEnable.AutoSize = true;
            this.CbFwEnable.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbFwEnable.Location = new System.Drawing.Point(6, 6);
            this.CbFwEnable.Name = "CbFwEnable";
            this.CbFwEnable.Size = new System.Drawing.Size(79, 17);
            this.CbFwEnable.TabIndex = 0;
            this.CbFwEnable.Text = "Write to file";
            this.CbFwEnable.UseVisualStyleBackColor = true;
            this.CbFwEnable.CheckedChanged += new System.EventHandler(this.CbFwEnable_CheckedChanged);
            // 
            // tabProxy
            // 
            this.tabProxy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabProxy.Controls.Add(this.BtnProxyTestCancel);
            this.tabProxy.Controls.Add(this.LabProxyTotal);
            this.tabProxy.Controls.Add(this.label12);
            this.tabProxy.Controls.Add(this.LabProxyDisabled);
            this.tabProxy.Controls.Add(this.label5);
            this.tabProxy.Controls.Add(this.LabProxyGood);
            this.tabProxy.Controls.Add(this.label3);
            this.tabProxy.Controls.Add(this.LabProxyBad);
            this.tabProxy.Controls.Add(this.label1);
            this.tabProxy.Controls.Add(this.BtnProxyLoad);
            this.tabProxy.Controls.Add(this.DgvProxyList);
            this.tabProxy.Controls.Add(this.BtnProxyTest);
            this.tabProxy.Controls.Add(this.CbProxyEnabled);
            this.tabProxy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabProxy.Location = new System.Drawing.Point(4, 22);
            this.tabProxy.Name = "tabProxy";
            this.tabProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabProxy.Size = new System.Drawing.Size(316, 296);
            this.tabProxy.TabIndex = 3;
            this.tabProxy.Text = "Proxy";
            // 
            // BtnProxyTestCancel
            // 
            this.BtnProxyTestCancel.Enabled = false;
            this.BtnProxyTestCancel.Location = new System.Drawing.Point(260, 265);
            this.BtnProxyTestCancel.Name = "BtnProxyTestCancel";
            this.BtnProxyTestCancel.Size = new System.Drawing.Size(50, 23);
            this.BtnProxyTestCancel.TabIndex = 21;
            this.BtnProxyTestCancel.Text = "Cancel";
            this.BtnProxyTestCancel.UseVisualStyleBackColor = true;
            this.BtnProxyTestCancel.Click += new System.EventHandler(this.BtnProxyTestCancel_Click);
            // 
            // LabProxyTotal
            // 
            this.LabProxyTotal.AutoSize = true;
            this.LabProxyTotal.ForeColor = System.Drawing.Color.White;
            this.LabProxyTotal.Location = new System.Drawing.Point(54, 276);
            this.LabProxyTotal.Name = "LabProxyTotal";
            this.LabProxyTotal.Size = new System.Drawing.Size(13, 13);
            this.LabProxyTotal.TabIndex = 20;
            this.LabProxyTotal.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(23, 276);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Total:";
            // 
            // LabProxyDisabled
            // 
            this.LabProxyDisabled.AutoSize = true;
            this.LabProxyDisabled.ForeColor = System.Drawing.Color.Gold;
            this.LabProxyDisabled.Location = new System.Drawing.Point(54, 263);
            this.LabProxyDisabled.Name = "LabProxyDisabled";
            this.LabProxyDisabled.Size = new System.Drawing.Size(13, 13);
            this.LabProxyDisabled.TabIndex = 18;
            this.LabProxyDisabled.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(6, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Disabled:";
            // 
            // LabProxyGood
            // 
            this.LabProxyGood.AutoSize = true;
            this.LabProxyGood.ForeColor = System.Drawing.Color.Chartreuse;
            this.LabProxyGood.Location = new System.Drawing.Point(54, 249);
            this.LabProxyGood.Name = "LabProxyGood";
            this.LabProxyGood.Size = new System.Drawing.Size(13, 13);
            this.LabProxyGood.TabIndex = 16;
            this.LabProxyGood.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Good:";
            // 
            // LabProxyBad
            // 
            this.LabProxyBad.AutoSize = true;
            this.LabProxyBad.ForeColor = System.Drawing.Color.Red;
            this.LabProxyBad.Location = new System.Drawing.Point(54, 236);
            this.LabProxyBad.Name = "LabProxyBad";
            this.LabProxyBad.Size = new System.Drawing.Size(13, 13);
            this.LabProxyBad.TabIndex = 14;
            this.LabProxyBad.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Bad:";
            // 
            // BtnProxyLoad
            // 
            this.BtnProxyLoad.Location = new System.Drawing.Point(216, 236);
            this.BtnProxyLoad.Name = "BtnProxyLoad";
            this.BtnProxyLoad.Size = new System.Drawing.Size(94, 23);
            this.BtnProxyLoad.TabIndex = 12;
            this.BtnProxyLoad.Text = "Load from file";
            this.BtnProxyLoad.UseVisualStyleBackColor = true;
            this.BtnProxyLoad.Click += new System.EventHandler(this.BtnProxyLoad_Click);
            // 
            // DgvProxyList
            // 
            this.DgvProxyList.AllowUserToAddRows = false;
            this.DgvProxyList.AllowUserToDeleteRows = false;
            this.DgvProxyList.AllowUserToResizeRows = false;
            this.DgvProxyList.AutoGenerateColumns = false;
            this.DgvProxyList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvProxyList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvProxyList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.DgvProxyList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DgvProxyList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvProxyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvProxyList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewCheckBoxColumn,
            this.Status,
            this.hostDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.proxyTypeDataGridViewTextBoxColumn});
            this.DgvProxyList.DataSource = this.proxyItemBindingSource;
            this.DgvProxyList.Location = new System.Drawing.Point(8, 35);
            this.DgvProxyList.MultiSelect = false;
            this.DgvProxyList.Name = "DgvProxyList";
            this.DgvProxyList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DgvProxyList.RowHeadersVisible = false;
            this.DgvProxyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvProxyList.Size = new System.Drawing.Size(302, 195);
            this.DgvProxyList.TabIndex = 11;
            // 
            // BtnProxyTest
            // 
            this.BtnProxyTest.Location = new System.Drawing.Point(216, 265);
            this.BtnProxyTest.Name = "BtnProxyTest";
            this.BtnProxyTest.Size = new System.Drawing.Size(38, 23);
            this.BtnProxyTest.TabIndex = 9;
            this.BtnProxyTest.Text = "Test";
            this.BtnProxyTest.UseVisualStyleBackColor = true;
            this.BtnProxyTest.Click += new System.EventHandler(this.BtnProxyTest_Click);
            // 
            // CbProxyEnabled
            // 
            this.CbProxyEnabled.AutoSize = true;
            this.CbProxyEnabled.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbProxyEnabled.Location = new System.Drawing.Point(8, 10);
            this.CbProxyEnabled.Name = "CbProxyEnabled";
            this.CbProxyEnabled.Size = new System.Drawing.Size(65, 17);
            this.CbProxyEnabled.TabIndex = 2;
            this.CbProxyEnabled.Text = "Enabled";
            this.CbProxyEnabled.UseVisualStyleBackColor = true;
            this.CbProxyEnabled.CheckedChanged += new System.EventHandler(this.CbProxyEnabled_CheckedChanged);
            // 
            // tabModules
            // 
            this.tabModules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabModules.Controls.Add(this.DgvModules);
            this.tabModules.Location = new System.Drawing.Point(4, 22);
            this.tabModules.Name = "tabModules";
            this.tabModules.Padding = new System.Windows.Forms.Padding(3);
            this.tabModules.Size = new System.Drawing.Size(316, 296);
            this.tabModules.TabIndex = 7;
            this.tabModules.Text = "Modules";
            // 
            // DgvModules
            // 
            this.DgvModules.AllowUserToAddRows = false;
            this.DgvModules.AllowUserToDeleteRows = false;
            this.DgvModules.AllowUserToResizeRows = false;
            this.DgvModules.AutoGenerateColumns = false;
            this.DgvModules.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.DgvModules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvModules.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.enabledDataGridViewCheckBoxColumn1,
            this.nameDataGridViewTextBoxColumn,
            this.versionDataGridViewTextBoxColumn,
            this.Button});
            this.DgvModules.DataSource = this.BsModules;
            this.DgvModules.Location = new System.Drawing.Point(0, 0);
            this.DgvModules.MultiSelect = false;
            this.DgvModules.Name = "DgvModules";
            this.DgvModules.RowHeadersVisible = false;
            this.DgvModules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DgvModules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvModules.Size = new System.Drawing.Size(316, 296);
            this.DgvModules.TabIndex = 0;
            this.DgvModules.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvModules_CellContentClick);
            // 
            // Button
            // 
            this.Button.DataPropertyName = "ButtonName";
            this.Button.HeaderText = "Action";
            this.Button.Name = "Button";
            this.Button.ReadOnly = true;
            this.Button.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Button.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tabUpdates
            // 
            this.tabUpdates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabUpdates.Controls.Add(this.BtnUpdateNotes);
            this.tabUpdates.Controls.Add(this.LbCurrentversionStr);
            this.tabUpdates.Controls.Add(this.LbServerVersionStr);
            this.tabUpdates.Controls.Add(this.BtnDlLatestBuild);
            this.tabUpdates.Controls.Add(this.LbCurrentVersion);
            this.tabUpdates.Controls.Add(this.LbServerVersion);
            this.tabUpdates.Controls.Add(this.CbUpdateChannel);
            this.tabUpdates.Controls.Add(this.LbUpdateChannel);
            this.tabUpdates.ForeColor = System.Drawing.Color.White;
            this.tabUpdates.Location = new System.Drawing.Point(4, 22);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdates.Size = new System.Drawing.Size(316, 296);
            this.tabUpdates.TabIndex = 5;
            this.tabUpdates.Text = "Updates";
            // 
            // BtnUpdateNotes
            // 
            this.BtnUpdateNotes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnUpdateNotes.Location = new System.Drawing.Point(9, 63);
            this.BtnUpdateNotes.Name = "BtnUpdateNotes";
            this.BtnUpdateNotes.Size = new System.Drawing.Size(172, 23);
            this.BtnUpdateNotes.TabIndex = 4;
            this.BtnUpdateNotes.Text = "Release notes";
            this.BtnUpdateNotes.UseVisualStyleBackColor = true;
            this.BtnUpdateNotes.Click += new System.EventHandler(this.BtnUpdateNotes_Click);
            // 
            // LbCurrentversionStr
            // 
            this.LbCurrentversionStr.AutoSize = true;
            this.LbCurrentversionStr.Location = new System.Drawing.Point(100, 43);
            this.LbCurrentversionStr.Name = "LbCurrentversionStr";
            this.LbCurrentversionStr.Size = new System.Drawing.Size(22, 13);
            this.LbCurrentversionStr.TabIndex = 6;
            this.LbCurrentversionStr.Text = "-.-.-";
            // 
            // LbServerVersionStr
            // 
            this.LbServerVersionStr.AutoSize = true;
            this.LbServerVersionStr.Location = new System.Drawing.Point(100, 30);
            this.LbServerVersionStr.Name = "LbServerVersionStr";
            this.LbServerVersionStr.Size = new System.Drawing.Size(22, 13);
            this.LbServerVersionStr.TabIndex = 5;
            this.LbServerVersionStr.Text = "-.-.-";
            // 
            // BtnDlLatestBuild
            // 
            this.BtnDlLatestBuild.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnDlLatestBuild.Location = new System.Drawing.Point(187, 63);
            this.BtnDlLatestBuild.Name = "BtnDlLatestBuild";
            this.BtnDlLatestBuild.Size = new System.Drawing.Size(123, 23);
            this.BtnDlLatestBuild.TabIndex = 7;
            this.BtnDlLatestBuild.Text = "Download";
            this.BtnDlLatestBuild.UseVisualStyleBackColor = true;
            this.BtnDlLatestBuild.Visible = false;
            this.BtnDlLatestBuild.Click += new System.EventHandler(this.BtnDlLatestBuild_Click);
            // 
            // LbCurrentVersion
            // 
            this.LbCurrentVersion.AutoSize = true;
            this.LbCurrentVersion.Location = new System.Drawing.Point(16, 43);
            this.LbCurrentVersion.Name = "LbCurrentVersion";
            this.LbCurrentVersion.Size = new System.Drawing.Size(81, 13);
            this.LbCurrentVersion.TabIndex = 3;
            this.LbCurrentVersion.Text = "Current version:";
            // 
            // LbServerVersion
            // 
            this.LbServerVersion.AutoSize = true;
            this.LbServerVersion.Location = new System.Drawing.Point(19, 30);
            this.LbServerVersion.Name = "LbServerVersion";
            this.LbServerVersion.Size = new System.Drawing.Size(78, 13);
            this.LbServerVersion.TabIndex = 2;
            this.LbServerVersion.Text = "Server version:";
            // 
            // CbUpdateChannel
            // 
            this.CbUpdateChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbUpdateChannel.FormattingEnabled = true;
            this.CbUpdateChannel.Items.AddRange(new object[] {
            "Stable",
            "Dev-Release"});
            this.CbUpdateChannel.Location = new System.Drawing.Point(103, 6);
            this.CbUpdateChannel.Name = "CbUpdateChannel";
            this.CbUpdateChannel.Size = new System.Drawing.Size(207, 21);
            this.CbUpdateChannel.TabIndex = 1;
            // 
            // LbUpdateChannel
            // 
            this.LbUpdateChannel.AutoSize = true;
            this.LbUpdateChannel.Location = new System.Drawing.Point(6, 9);
            this.LbUpdateChannel.Name = "LbUpdateChannel";
            this.LbUpdateChannel.Size = new System.Drawing.Size(91, 13);
            this.LbUpdateChannel.TabIndex = 0;
            this.LbUpdateChannel.Text = "Updates channel:";
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabAbout.Controls.Add(this.LinkAboutDiscord);
            this.tabAbout.Controls.Add(this.LabAboutDiscord);
            this.tabAbout.Controls.Add(this.LinkAboutSmthBy);
            this.tabAbout.Controls.Add(this.LabAboutSmthBy);
            this.tabAbout.Controls.Add(this.LinkAboutCodedBy);
            this.tabAbout.Controls.Add(this.LabAboutCodedBy);
            this.tabAbout.Controls.Add(this.LinkAboutUpdates);
            this.tabAbout.Controls.Add(this.LabAboutTelegram);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(316, 296);
            this.tabAbout.TabIndex = 4;
            this.tabAbout.Text = "About";
            // 
            // LinkAboutSmthBy
            // 
            this.LinkAboutSmthBy.AutoSize = true;
            this.LinkAboutSmthBy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkAboutSmthBy.Location = new System.Drawing.Point(122, 32);
            this.LinkAboutSmthBy.Name = "LinkAboutSmthBy";
            this.LinkAboutSmthBy.Size = new System.Drawing.Size(140, 13);
            this.LinkAboutSmthBy.TabIndex = 5;
            this.LinkAboutSmthBy.TabStop = true;
            this.LinkAboutSmthBy.Text = "https://github.com/EarsKilla";
            this.LinkAboutSmthBy.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkAboutSmthBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // LabAboutSmthBy
            // 
            this.LabAboutSmthBy.AutoSize = true;
            this.LabAboutSmthBy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabAboutSmthBy.Location = new System.Drawing.Point(6, 32);
            this.LabAboutSmthBy.Name = "LabAboutSmthBy";
            this.LabAboutSmthBy.Size = new System.Drawing.Size(119, 13);
            this.LabAboutSmthBy.TabIndex = 4;
            this.LabAboutSmthBy.Text = "Redesigin and code by:";
            // 
            // LinkAboutCodedBy
            // 
            this.LinkAboutCodedBy.AutoSize = true;
            this.LinkAboutCodedBy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkAboutCodedBy.Location = new System.Drawing.Point(58, 19);
            this.LinkAboutCodedBy.Name = "LinkAboutCodedBy";
            this.LinkAboutCodedBy.Size = new System.Drawing.Size(149, 13);
            this.LinkAboutCodedBy.TabIndex = 3;
            this.LinkAboutCodedBy.TabStop = true;
            this.LinkAboutCodedBy.Text = "https://tele.click/dedsec1337";
            this.LinkAboutCodedBy.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkAboutCodedBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // LabAboutCodedBy
            // 
            this.LabAboutCodedBy.AutoSize = true;
            this.LabAboutCodedBy.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabAboutCodedBy.Location = new System.Drawing.Point(6, 19);
            this.LabAboutCodedBy.Name = "LabAboutCodedBy";
            this.LabAboutCodedBy.Size = new System.Drawing.Size(55, 13);
            this.LabAboutCodedBy.TabIndex = 2;
            this.LabAboutCodedBy.Text = "Coded by:";
            // 
            // LinkAboutUpdates
            // 
            this.LinkAboutUpdates.AutoSize = true;
            this.LinkAboutUpdates.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkAboutUpdates.Location = new System.Drawing.Point(140, 6);
            this.LinkAboutUpdates.Name = "LinkAboutUpdates";
            this.LinkAboutUpdates.Size = new System.Drawing.Size(128, 13);
            this.LinkAboutUpdates.TabIndex = 1;
            this.LinkAboutUpdates.TabStop = true;
            this.LinkAboutUpdates.Text = "https://tele.click/sag_bot";
            this.LinkAboutUpdates.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkAboutUpdates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // LabAboutTelegram
            // 
            this.LabAboutTelegram.AutoSize = true;
            this.LabAboutTelegram.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LabAboutTelegram.Location = new System.Drawing.Point(6, 6);
            this.LabAboutTelegram.Name = "LabAboutTelegram";
            this.LabAboutTelegram.Size = new System.Drawing.Size(140, 13);
            this.LabAboutTelegram.TabIndex = 0;
            this.LabAboutTelegram.Text = "Join Telegram For Updates: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // profileConfigBindingSource
            // 
            this.profileConfigBindingSource.DataSource = typeof(SteamAccCreator.Models.ProfileConfig);
            // 
            // BsCaptchaTwoCapConfig
            // 
            this.BsCaptchaTwoCapConfig.DataSource = typeof(SteamAccCreator.Models.RuCaptchaConfig);
            // 
            // BsCaptchaCapsolConfig
            // 
            this.BsCaptchaCapsolConfig.DataSource = typeof(SteamAccCreator.Models.CaptchaSolutionsConfig);
            // 
            // enabledDataGridViewCheckBoxColumn
            // 
            this.enabledDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.enabledDataGridViewCheckBoxColumn.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn.FillWeight = 32F;
            this.enabledDataGridViewCheckBoxColumn.HeaderText = "Use";
            this.enabledDataGridViewCheckBoxColumn.MinimumWidth = 32;
            this.enabledDataGridViewCheckBoxColumn.Name = "enabledDataGridViewCheckBoxColumn";
            this.enabledDataGridViewCheckBoxColumn.Width = 32;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 62;
            // 
            // hostDataGridViewTextBoxColumn
            // 
            this.hostDataGridViewTextBoxColumn.DataPropertyName = "Host";
            this.hostDataGridViewTextBoxColumn.HeaderText = "Host";
            this.hostDataGridViewTextBoxColumn.Name = "hostDataGridViewTextBoxColumn";
            this.hostDataGridViewTextBoxColumn.ReadOnly = true;
            this.hostDataGridViewTextBoxColumn.Width = 54;
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            this.portDataGridViewTextBoxColumn.ReadOnly = true;
            this.portDataGridViewTextBoxColumn.Width = 51;
            // 
            // proxyTypeDataGridViewTextBoxColumn
            // 
            this.proxyTypeDataGridViewTextBoxColumn.DataPropertyName = "ProxyType";
            this.proxyTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.proxyTypeDataGridViewTextBoxColumn.Name = "proxyTypeDataGridViewTextBoxColumn";
            this.proxyTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.proxyTypeDataGridViewTextBoxColumn.Width = 56;
            // 
            // proxyItemBindingSource
            // 
            this.proxyItemBindingSource.DataSource = typeof(SteamAccCreator.Models.ProxyItem);
            // 
            // enabledDataGridViewCheckBoxColumn1
            // 
            this.enabledDataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.enabledDataGridViewCheckBoxColumn1.DataPropertyName = "Enabled";
            this.enabledDataGridViewCheckBoxColumn1.HeaderText = "";
            this.enabledDataGridViewCheckBoxColumn1.Name = "enabledDataGridViewCheckBoxColumn1";
            this.enabledDataGridViewCheckBoxColumn1.ToolTipText = "Enabled";
            this.enabledDataGridViewCheckBoxColumn1.Width = 5;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // versionDataGridViewTextBoxColumn
            // 
            this.versionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.versionDataGridViewTextBoxColumn.DataPropertyName = "Version";
            this.versionDataGridViewTextBoxColumn.HeaderText = "Version";
            this.versionDataGridViewTextBoxColumn.Name = "versionDataGridViewTextBoxColumn";
            this.versionDataGridViewTextBoxColumn.ReadOnly = true;
            this.versionDataGridViewTextBoxColumn.Width = 67;
            // 
            // BsModules
            // 
            this.BsModules.DataSource = typeof(SteamAccCreator.Models.ModuleBinding);
            // 
            // LabAboutDiscord
            // 
            this.LabAboutDiscord.AutoSize = true;
            this.LabAboutDiscord.ForeColor = System.Drawing.Color.White;
            this.LabAboutDiscord.Location = new System.Drawing.Point(6, 45);
            this.LabAboutDiscord.Name = "LabAboutDiscord";
            this.LabAboutDiscord.Size = new System.Drawing.Size(96, 13);
            this.LabAboutDiscord.TabIndex = 6;
            this.LabAboutDiscord.Text = "EarsKilla\'s Discord:";
            // 
            // LinkAboutDiscord
            // 
            this.LinkAboutDiscord.AutoSize = true;
            this.LinkAboutDiscord.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkAboutDiscord.Location = new System.Drawing.Point(99, 45);
            this.LinkAboutDiscord.Name = "LinkAboutDiscord";
            this.LinkAboutDiscord.Size = new System.Drawing.Size(144, 13);
            this.LinkAboutDiscord.TabIndex = 7;
            this.LinkAboutDiscord.TabStop = true;
            this.LinkAboutDiscord.Text = "https://discord.gg/R96F2DA";
            this.LinkAboutDiscord.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkAboutDiscord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(784, 489);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.dataAccounts);
            this.Controls.Add(this.pnlCreation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 528);
            this.Name = "MainForm";
            this.Text = "Steam Account Creator - @DedSec1337";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.pnlCreation.ResumeLayout(false);
            this.pnlCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAccountsCount)).EndInit();
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbProfile)).EndInit();
            this.tabCaptcha.ResumeLayout(false);
            this.tabCaptcha.PerformLayout();
            this.GbCapTwoCaptcha.ResumeLayout(false);
            this.GbCapTwoCaptcha.PerformLayout();
            this.GbCapCaptchasolutions.ResumeLayout(false);
            this.GbCapCaptchasolutions.PerformLayout();
            this.tabFileWriting.ResumeLayout(false);
            this.tabFileWriting.PerformLayout();
            this.tabProxy.ResumeLayout(false);
            this.tabProxy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProxyList)).EndInit();
            this.tabModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvModules)).EndInit();
            this.tabUpdates.ResumeLayout(false);
            this.tabUpdates.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profileConfigBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsCaptchaTwoCapConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsCaptchaCapsolConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proxyItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsModules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblAlias;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.GroupBox pnlCreation;
        private System.Windows.Forms.DataGridView dataAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlias;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSteamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.ListBox ListGames;
        private System.Windows.Forms.CheckBox CbAddGames;
        private System.Windows.Forms.CheckBox CbRandomPassword;
        private System.Windows.Forms.CheckBox CbNeatPassword;
        private System.Windows.Forms.CheckBox CbNeatLogin;
        private System.Windows.Forms.CheckBox CbRandomLogin;
        private System.Windows.Forms.CheckBox CbRandomMail;
        private System.Windows.Forms.NumericUpDown NumAccountsCount;
        private System.Windows.Forms.Label LabAccountsCount;
        private System.Windows.Forms.TabPage tabCaptcha;
        private System.Windows.Forms.TabPage tabFileWriting;
        private System.Windows.Forms.LinkLabel LinkFwPath;
        private System.Windows.Forms.Button BtnFwChangeFolder;
        private System.Windows.Forms.Label LabFwPath;
        public System.Windows.Forms.ComboBox CbFwOutType;
        private System.Windows.Forms.CheckBox CbFwMail;
        private System.Windows.Forms.CheckBox CbFwEnable;
        private System.Windows.Forms.TabPage tabProxy;
        private System.Windows.Forms.CheckBox CbProxyEnabled;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.LinkLabel LinkAboutSmthBy;
        private System.Windows.Forms.Label LabAboutSmthBy;
        private System.Windows.Forms.LinkLabel LinkAboutCodedBy;
        private System.Windows.Forms.Label LabAboutCodedBy;
        private System.Windows.Forms.LinkLabel LinkAboutUpdates;
        private System.Windows.Forms.Label LabAboutTelegram;
        private System.Windows.Forms.Button BtnLoadIds;
        private System.Windows.Forms.Button BtnProxyTest;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnClearGames;
        private System.Windows.Forms.Button BtnRemoveGame;
        private System.Windows.Forms.Button BtnAddGame;
        private System.Windows.Forms.Button BtnExportGames;
        private System.Windows.Forms.LinkLabel LinkHowToFindSubId;
        private System.Windows.Forms.DataGridView DgvProxyList;
        private System.Windows.Forms.BindingSource proxyItemBindingSource;
        private System.Windows.Forms.Button BtnProxyLoad;
        private System.Windows.Forms.Label LabProxyTotal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label LabProxyDisabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LabProxyGood;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabProxyBad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn proxyTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabUpdates;
        private System.Windows.Forms.Label LbServerVersion;
        private System.Windows.Forms.ComboBox CbUpdateChannel;
        private System.Windows.Forms.Label LbUpdateChannel;
        private System.Windows.Forms.Label LbCurrentVersion;
        private System.Windows.Forms.Label LbCurrentversionStr;
        private System.Windows.Forms.Label LbServerVersionStr;
        private System.Windows.Forms.Button BtnDlLatestBuild;
        private System.Windows.Forms.Button BtnUpdateNotes;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.Label LabProfileBio;
        private System.Windows.Forms.TextBox TbProfileRealName;
        private System.Windows.Forms.Label LabProfileRealName;
        private System.Windows.Forms.TextBox TbProfileName;
        private System.Windows.Forms.Label LabProfileName;
        private System.Windows.Forms.TextBox TbProfileImagePath;
        private System.Windows.Forms.Button BtnProfileSelectImg;
        private System.Windows.Forms.Label LabProfileImage;
        private System.Windows.Forms.PictureBox PbProfile;
        private System.Windows.Forms.TextBox TbProfileBio;
        private System.Windows.Forms.Label LabProfileCity;
        private System.Windows.Forms.Label LabProfileState;
        private System.Windows.Forms.Label LabProfileCountry;
        private System.Windows.Forms.TextBox TbProfileCity;
        private System.Windows.Forms.TextBox TbProfileState;
        private System.Windows.Forms.TextBox TbProfileCountry;
        private System.Windows.Forms.CheckBox CbProfileUrl;
        private System.Windows.Forms.BindingSource profileConfigBindingSource;
        private System.Windows.Forms.CheckBox CbProfileEnabled;
        private System.Windows.Forms.Button BtnProfileRmImg;
        private System.Windows.Forms.Button BtnProxyTestCancel;
        private System.Windows.Forms.TabPage tabModules;
        private System.Windows.Forms.DataGridView DgvModules;
        private System.Windows.Forms.BindingSource BsModules;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enabledDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Button;
        private System.Windows.Forms.Label LbCapSolver;
        private System.Windows.Forms.ComboBox CbCapSolver;
        private System.Windows.Forms.GroupBox GbCapTwoCaptcha;
        private System.Windows.Forms.GroupBox GbCapCaptchasolutions;
        private System.Windows.Forms.Label LbCapCaptchasolutionsSectet;
        private System.Windows.Forms.Label LbCapCaptchasolutionsKey;
        private System.Windows.Forms.TextBox TbCapCaptchasolutionsSectet;
        private System.Windows.Forms.TextBox TbCapCaptchasolutionsKey;
        private System.Windows.Forms.CheckBox CbCapTwoCaptchaReportBad;
        private System.Windows.Forms.Label LbCapTwoCaptchaKey;
        private System.Windows.Forms.TextBox TbCapTwoCaptchaKey;
        private System.Windows.Forms.BindingSource BsCaptchaTwoCapConfig;
        private System.Windows.Forms.BindingSource BsCaptchaCapsolConfig;
        private System.Windows.Forms.LinkLabel LinkAboutDiscord;
        private System.Windows.Forms.Label LabAboutDiscord;
    }
}

