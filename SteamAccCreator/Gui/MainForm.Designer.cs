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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
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
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CbCapRuReportBad = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TbCapRuCapApi = new System.Windows.Forms.TextBox();
            this.TbCapSolutionsSecret = new System.Windows.Forms.TextBox();
            this.TbCapSolutionsApi = new System.Windows.Forms.TextBox();
            this.RadCapRuCaptcha = new System.Windows.Forms.RadioButton();
            this.RadCapCaptchasolutions = new System.Windows.Forms.RadioButton();
            this.CbCapAuto = new System.Windows.Forms.CheckBox();
            this.CbCapHandMode = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LinkFwPath = new System.Windows.Forms.LinkLabel();
            this.BtnFwChangeFolder = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.CbFwOutType = new System.Windows.Forms.ComboBox();
            this.CbFwMail = new System.Windows.Forms.CheckBox();
            this.CbFwEnable = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.LinkSmthBy = new System.Windows.Forms.LinkLabel();
            this.label17 = new System.Windows.Forms.Label();
            this.LinkCodedBy = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.LinkUpdates = new System.Windows.Forms.LinkLabel();
            this.label15 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.proxyItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.enabledDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proxyTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAccounts)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAccountsCount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProxyList)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyItemBindingSource)).BeginInit();
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(324, 322);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabPage1.Controls.Add(this.LinkHowToFindSubId);
            this.tabPage1.Controls.Add(this.BtnExportGames);
            this.tabPage1.Controls.Add(this.BtnClearGames);
            this.tabPage1.Controls.Add(this.BtnRemoveGame);
            this.tabPage1.Controls.Add(this.BtnAddGame);
            this.tabPage1.Controls.Add(this.BtnLoadIds);
            this.tabPage1.Controls.Add(this.ListGames);
            this.tabPage1.Controls.Add(this.CbAddGames);
            this.tabPage1.Controls.Add(this.CbRandomPassword);
            this.tabPage1.Controls.Add(this.CbNeatPassword);
            this.tabPage1.Controls.Add(this.CbNeatLogin);
            this.tabPage1.Controls.Add(this.CbRandomLogin);
            this.tabPage1.Controls.Add(this.CbRandomMail);
            this.tabPage1.Controls.Add(this.NumAccountsCount);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(316, 296);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Accounts to create:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabPage2.Controls.Add(this.CbCapRuReportBad);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.TbCapRuCapApi);
            this.tabPage2.Controls.Add(this.TbCapSolutionsSecret);
            this.tabPage2.Controls.Add(this.TbCapSolutionsApi);
            this.tabPage2.Controls.Add(this.RadCapRuCaptcha);
            this.tabPage2.Controls.Add(this.RadCapCaptchasolutions);
            this.tabPage2.Controls.Add(this.CbCapAuto);
            this.tabPage2.Controls.Add(this.CbCapHandMode);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(316, 296);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Captcha";
            // 
            // CbCapRuReportBad
            // 
            this.CbCapRuReportBad.AutoSize = true;
            this.CbCapRuReportBad.ForeColor = System.Drawing.Color.White;
            this.CbCapRuReportBad.Location = new System.Drawing.Point(170, 78);
            this.CbCapRuReportBad.Name = "CbCapRuReportBad";
            this.CbCapRuReportBad.Size = new System.Drawing.Size(139, 17);
            this.CbCapRuReportBad.TabIndex = 10;
            this.CbCapRuReportBad.Text = "Report if not recognized";
            this.CbCapRuReportBad.UseVisualStyleBackColor = true;
            this.CbCapRuReportBad.CheckedChanged += new System.EventHandler(this.CbCapRuReportBad_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(6, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "API Key:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(206, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Secret key:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(3, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "API Key:";
            // 
            // TbCapRuCapApi
            // 
            this.TbCapRuCapApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbCapRuCapApi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCapRuCapApi.Enabled = false;
            this.TbCapRuCapApi.ForeColor = System.Drawing.Color.White;
            this.TbCapRuCapApi.Location = new System.Drawing.Point(57, 101);
            this.TbCapRuCapApi.Name = "TbCapRuCapApi";
            this.TbCapRuCapApi.Size = new System.Drawing.Size(252, 20);
            this.TbCapRuCapApi.TabIndex = 6;
            // 
            // TbCapSolutionsSecret
            // 
            this.TbCapSolutionsSecret.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbCapSolutionsSecret.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCapSolutionsSecret.Enabled = false;
            this.TbCapSolutionsSecret.ForeColor = System.Drawing.Color.White;
            this.TbCapSolutionsSecret.Location = new System.Drawing.Point(204, 52);
            this.TbCapSolutionsSecret.Name = "TbCapSolutionsSecret";
            this.TbCapSolutionsSecret.Size = new System.Drawing.Size(105, 20);
            this.TbCapSolutionsSecret.TabIndex = 5;
            // 
            // TbCapSolutionsApi
            // 
            this.TbCapSolutionsApi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.TbCapSolutionsApi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TbCapSolutionsApi.Enabled = false;
            this.TbCapSolutionsApi.ForeColor = System.Drawing.Color.White;
            this.TbCapSolutionsApi.Location = new System.Drawing.Point(57, 52);
            this.TbCapSolutionsApi.Name = "TbCapSolutionsApi";
            this.TbCapSolutionsApi.Size = new System.Drawing.Size(141, 20);
            this.TbCapSolutionsApi.TabIndex = 4;
            // 
            // RadCapRuCaptcha
            // 
            this.RadCapRuCaptcha.AutoSize = true;
            this.RadCapRuCaptcha.Enabled = false;
            this.RadCapRuCaptcha.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RadCapRuCaptcha.Location = new System.Drawing.Point(6, 78);
            this.RadCapRuCaptcha.Name = "RadCapRuCaptcha";
            this.RadCapRuCaptcha.Size = new System.Drawing.Size(130, 17);
            this.RadCapRuCaptcha.TabIndex = 3;
            this.RadCapRuCaptcha.Text = "2Captcha/RuCaptcha";
            this.RadCapRuCaptcha.UseVisualStyleBackColor = true;
            this.RadCapRuCaptcha.CheckedChanged += new System.EventHandler(this.RadCapRuCaptcha_CheckedChanged);
            // 
            // RadCapCaptchasolutions
            // 
            this.RadCapCaptchasolutions.AutoSize = true;
            this.RadCapCaptchasolutions.Checked = true;
            this.RadCapCaptchasolutions.Enabled = false;
            this.RadCapCaptchasolutions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RadCapCaptchasolutions.Location = new System.Drawing.Point(6, 29);
            this.RadCapCaptchasolutions.Name = "RadCapCaptchasolutions";
            this.RadCapCaptchasolutions.Size = new System.Drawing.Size(106, 17);
            this.RadCapCaptchasolutions.TabIndex = 2;
            this.RadCapCaptchasolutions.TabStop = true;
            this.RadCapCaptchasolutions.Text = "Captchasolutions";
            this.RadCapCaptchasolutions.UseVisualStyleBackColor = true;
            this.RadCapCaptchasolutions.CheckedChanged += new System.EventHandler(this.RadCapCaptchasolutions_CheckedChanged);
            // 
            // CbCapAuto
            // 
            this.CbCapAuto.AutoSize = true;
            this.CbCapAuto.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbCapAuto.Location = new System.Drawing.Point(93, 6);
            this.CbCapAuto.Name = "CbCapAuto";
            this.CbCapAuto.Size = new System.Drawing.Size(90, 17);
            this.CbCapAuto.TabIndex = 1;
            this.CbCapAuto.Text = "Auto captcha";
            this.CbCapAuto.UseVisualStyleBackColor = true;
            this.CbCapAuto.CheckedChanged += new System.EventHandler(this.CbCapAuto_CheckedChanged);
            // 
            // CbCapHandMode
            // 
            this.CbCapHandMode.AutoSize = true;
            this.CbCapHandMode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CbCapHandMode.Location = new System.Drawing.Point(6, 6);
            this.CbCapHandMode.Name = "CbCapHandMode";
            this.CbCapHandMode.Size = new System.Drawing.Size(81, 17);
            this.CbCapHandMode.TabIndex = 0;
            this.CbCapHandMode.Text = "Hand mode";
            this.CbCapHandMode.UseVisualStyleBackColor = true;
            this.CbCapHandMode.CheckedChanged += new System.EventHandler(this.CbCapHandMode_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabPage3.Controls.Add(this.LinkFwPath);
            this.tabPage3.Controls.Add(this.BtnFwChangeFolder);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.CbFwOutType);
            this.tabPage3.Controls.Add(this.CbFwMail);
            this.tabPage3.Controls.Add(this.CbFwEnable);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(316, 296);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "File writing";
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(6, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Path:";
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
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabPage4.Controls.Add(this.LabProxyTotal);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.LabProxyDisabled);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.LabProxyGood);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.LabProxyBad);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.BtnProxyLoad);
            this.tabPage4.Controls.Add(this.DgvProxyList);
            this.tabPage4.Controls.Add(this.BtnProxyTest);
            this.tabPage4.Controls.Add(this.CbProxyEnabled);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(316, 296);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Proxy";
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
            this.BtnProxyLoad.Location = new System.Drawing.Point(172, 6);
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
            this.DgvProxyList.Size = new System.Drawing.Size(302, 195);
            this.DgvProxyList.TabIndex = 11;
            // 
            // BtnProxyTest
            // 
            this.BtnProxyTest.Location = new System.Drawing.Point(272, 6);
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
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.tabPage5.Controls.Add(this.LinkSmthBy);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.LinkCodedBy);
            this.tabPage5.Controls.Add(this.label16);
            this.tabPage5.Controls.Add(this.LinkUpdates);
            this.tabPage5.Controls.Add(this.label15);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(316, 296);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "About";
            // 
            // LinkSmthBy
            // 
            this.LinkSmthBy.AutoSize = true;
            this.LinkSmthBy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkSmthBy.Location = new System.Drawing.Point(120, 32);
            this.LinkSmthBy.Name = "LinkSmthBy";
            this.LinkSmthBy.Size = new System.Drawing.Size(140, 13);
            this.LinkSmthBy.TabIndex = 5;
            this.LinkSmthBy.TabStop = true;
            this.LinkSmthBy.Text = "https://github.com/EarsKilla";
            this.LinkSmthBy.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkSmthBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label17.Location = new System.Drawing.Point(6, 32);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Redesigin and smth by:";
            // 
            // LinkCodedBy
            // 
            this.LinkCodedBy.AutoSize = true;
            this.LinkCodedBy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkCodedBy.Location = new System.Drawing.Point(58, 19);
            this.LinkCodedBy.Name = "LinkCodedBy";
            this.LinkCodedBy.Size = new System.Drawing.Size(149, 13);
            this.LinkCodedBy.TabIndex = 3;
            this.LinkCodedBy.TabStop = true;
            this.LinkCodedBy.Text = "https://tele.click/dedsec1337";
            this.LinkCodedBy.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkCodedBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label16.Location = new System.Drawing.Point(6, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Coded by:";
            // 
            // LinkUpdates
            // 
            this.LinkUpdates.AutoSize = true;
            this.LinkUpdates.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.LinkUpdates.Location = new System.Drawing.Point(140, 6);
            this.LinkUpdates.Name = "LinkUpdates";
            this.LinkUpdates.Size = new System.Drawing.Size(128, 13);
            this.LinkUpdates.TabIndex = 1;
            this.LinkUpdates.TabStop = true;
            this.LinkUpdates.Text = "https://tele.click/sag_bot";
            this.LinkUpdates.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LinkUpdates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label15.Location = new System.Drawing.Point(6, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Join Telegram For Updates: ";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // proxyItemBindingSource
            // 
            this.proxyItemBindingSource.DataSource = typeof(SteamAccCreator.Models.ProxyItem);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(784, 489);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumAccountsCount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvProxyList)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proxyItemBindingSource)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox ListGames;
        private System.Windows.Forms.CheckBox CbAddGames;
        private System.Windows.Forms.CheckBox CbRandomPassword;
        private System.Windows.Forms.CheckBox CbNeatPassword;
        private System.Windows.Forms.CheckBox CbNeatLogin;
        private System.Windows.Forms.CheckBox CbRandomLogin;
        private System.Windows.Forms.CheckBox CbRandomMail;
        private System.Windows.Forms.NumericUpDown NumAccountsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TbCapRuCapApi;
        private System.Windows.Forms.TextBox TbCapSolutionsSecret;
        private System.Windows.Forms.TextBox TbCapSolutionsApi;
        private System.Windows.Forms.RadioButton RadCapRuCaptcha;
        private System.Windows.Forms.RadioButton RadCapCaptchasolutions;
        private System.Windows.Forms.CheckBox CbCapAuto;
        private System.Windows.Forms.CheckBox CbCapHandMode;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel LinkFwPath;
        private System.Windows.Forms.Button BtnFwChangeFolder;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox CbFwOutType;
        private System.Windows.Forms.CheckBox CbFwMail;
        private System.Windows.Forms.CheckBox CbFwEnable;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox CbProxyEnabled;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.LinkLabel LinkSmthBy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.LinkLabel LinkCodedBy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel LinkUpdates;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button BtnLoadIds;
        private System.Windows.Forms.Button BtnProxyTest;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button BtnClearGames;
        private System.Windows.Forms.Button BtnRemoveGame;
        private System.Windows.Forms.Button BtnAddGame;
        private System.Windows.Forms.Button BtnExportGames;
        private System.Windows.Forms.LinkLabel LinkHowToFindSubId;
        private System.Windows.Forms.CheckBox CbCapRuReportBad;
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
    }
}

