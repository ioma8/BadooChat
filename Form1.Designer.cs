namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.userImage = new System.Windows.Forms.PictureBox();
            this.newMsgTxtBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.timerUpdateData = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.MSLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searcherButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.S1Label = new System.Windows.Forms.Label();
            this.RTLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pagesCount = new System.Windows.Forms.NumericUpDown();
            this.refreshCheck = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerForTrayIcon = new System.Windows.Forms.Timer(this.components);
            this.timerRedrawAll = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.currentName = new System.Windows.Forms.TextBox();
            this.currentAge = new System.Windows.Forms.TextBox();
            this.currentTown = new System.Windows.Forms.TextBox();
            this.showCurrentPhoto = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.onlineTab = new System.Windows.Forms.TabPage();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chatUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToFavouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAllPhotosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.preMessage = new System.Windows.Forms.ToolStripComboBox();
            this.favTab = new System.Windows.Forms.TabPage();
            this.favListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagesCount)).BeginInit();
            this.trayMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.onlineTab.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.favTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(12, 119);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(427, 247);
            this.textBox1.TabIndex = 0;
            // 
            // userImage
            // 
            this.userImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userImage.Location = new System.Drawing.Point(563, 12);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(75, 75);
            this.userImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.userImage.TabIndex = 4;
            this.userImage.TabStop = false;
            this.toolTip1.SetToolTip(this.userImage, "Double click on image to view profile in web browser");
            this.userImage.Click += new System.EventHandler(this.userImage_Click);
            this.userImage.DoubleClick += new System.EventHandler(this.userImage_DoubleClick);
            // 
            // newMsgTxtBox
            // 
            this.newMsgTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newMsgTxtBox.Location = new System.Drawing.Point(12, 372);
            this.newMsgTxtBox.Name = "newMsgTxtBox";
            this.newMsgTxtBox.Size = new System.Drawing.Size(427, 20);
            this.newMsgTxtBox.TabIndex = 6;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Location = new System.Drawing.Point(448, 372);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(194, 20);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // timerUpdateData
            // 
            this.timerUpdateData.Enabled = true;
            this.timerUpdateData.Interval = 2000;
            this.timerUpdateData.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBar,
            this.MSLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 398);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(650, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusBar
            // 
            this.statusBar.AutoSize = false;
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(100, 17);
            // 
            // MSLabel
            // 
            this.MSLabel.Name = "MSLabel";
            this.MSLabel.Size = new System.Drawing.Size(36, 17);
            this.MSLabel.Text = "MS: 0";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.searcherButton);
            this.panel1.Controls.Add(this.logoutButton);
            this.panel1.Controls.Add(this.loginButton);
            this.panel1.Controls.Add(this.S1Label);
            this.panel1.Controls.Add(this.RTLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pagesCount);
            this.panel1.Controls.Add(this.refreshCheck);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 75);
            this.panel1.TabIndex = 10;
            // 
            // searcherButton
            // 
            this.searcherButton.Enabled = false;
            this.searcherButton.Location = new System.Drawing.Point(206, 9);
            this.searcherButton.Name = "searcherButton";
            this.searcherButton.Size = new System.Drawing.Size(99, 19);
            this.searcherButton.TabIndex = 8;
            this.searcherButton.Text = "searcher";
            this.searcherButton.UseVisualStyleBackColor = true;
            this.searcherButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // logoutButton
            // 
            this.logoutButton.Enabled = false;
            this.logoutButton.Location = new System.Drawing.Point(85, 9);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(71, 30);
            this.logoutButton.TabIndex = 7;
            this.logoutButton.Text = "Log out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(8, 9);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(71, 30);
            this.loginButton.TabIndex = 6;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // S1Label
            // 
            this.S1Label.AutoSize = true;
            this.S1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S1Label.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.S1Label.Location = new System.Drawing.Point(99, 52);
            this.S1Label.Name = "S1Label";
            this.S1Label.Size = new System.Drawing.Size(23, 13);
            this.S1Label.TabIndex = 5;
            this.S1Label.Text = "S1:";
            // 
            // RTLabel
            // 
            this.RTLabel.AutoSize = true;
            this.RTLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTLabel.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.RTLabel.Location = new System.Drawing.Point(3, 52);
            this.RTLabel.Name = "RTLabel";
            this.RTLabel.Size = new System.Drawing.Size(22, 13);
            this.RTLabel.TabIndex = 4;
            this.RTLabel.Text = "RT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "users in list:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(393, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x 20";
            // 
            // pagesCount
            // 
            this.pagesCount.Location = new System.Drawing.Point(339, 24);
            this.pagesCount.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.pagesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pagesCount.Name = "pagesCount";
            this.pagesCount.Size = new System.Drawing.Size(33, 20);
            this.pagesCount.TabIndex = 1;
            this.pagesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pagesCount.ValueChanged += new System.EventHandler(this.pagesCount_ValueChanged);
            // 
            // refreshCheck
            // 
            this.refreshCheck.AutoSize = true;
            this.refreshCheck.Checked = true;
            this.refreshCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.refreshCheck.Location = new System.Drawing.Point(339, 50);
            this.refreshCheck.Name = "refreshCheck";
            this.refreshCheck.Size = new System.Drawing.Size(86, 17);
            this.refreshCheck.TabIndex = 0;
            this.refreshCheck.Text = "refresh users";
            this.refreshCheck.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 39);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hint:\r\ndouble click to\r\nselect for chat\r\n";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.trayMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(166, 76);
            // 
            // showApplicationToolStripMenuItem
            // 
            this.showApplicationToolStripMenuItem.Name = "showApplicationToolStripMenuItem";
            this.showApplicationToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.showApplicationToolStripMenuItem.Text = "Show application";
            this.showApplicationToolStripMenuItem.Click += new System.EventHandler(this.showApplicationToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerForTrayIcon
            // 
            this.timerForTrayIcon.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerRedrawAll
            // 
            this.timerRedrawAll.Interval = 1000;
            this.timerRedrawAll.Tick += new System.EventHandler(this.timerUpdateInfo_Tick);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(501, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 24);
            this.button2.TabIndex = 17;
            this.button2.Text = "?";
            this.toolTip1.SetToolTip(this.button2, "Show help");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // currentName
            // 
            this.currentName.Enabled = false;
            this.currentName.Location = new System.Drawing.Point(12, 93);
            this.currentName.Name = "currentName";
            this.currentName.Size = new System.Drawing.Size(145, 20);
            this.currentName.TabIndex = 12;
            // 
            // currentAge
            // 
            this.currentAge.Enabled = false;
            this.currentAge.Location = new System.Drawing.Point(163, 93);
            this.currentAge.Name = "currentAge";
            this.currentAge.Size = new System.Drawing.Size(51, 20);
            this.currentAge.TabIndex = 13;
            // 
            // currentTown
            // 
            this.currentTown.Enabled = false;
            this.currentTown.Location = new System.Drawing.Point(220, 93);
            this.currentTown.Name = "currentTown";
            this.currentTown.Size = new System.Drawing.Size(144, 20);
            this.currentTown.TabIndex = 14;
            // 
            // showCurrentPhoto
            // 
            this.showCurrentPhoto.AutoSize = true;
            this.showCurrentPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showCurrentPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.showCurrentPhoto.Location = new System.Drawing.Point(370, 96);
            this.showCurrentPhoto.Name = "showCurrentPhoto";
            this.showCurrentPhoto.Size = new System.Drawing.Size(40, 13);
            this.showCurrentPhoto.TabIndex = 15;
            this.showCurrentPhoto.Text = "Photo";
            this.showCurrentPhoto.Click += new System.EventHandler(this.showCurrentPhoto_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.onlineTab);
            this.tabControl1.Controls.Add(this.favTab);
            this.tabControl1.Location = new System.Drawing.Point(448, 93);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(194, 272);
            this.tabControl1.TabIndex = 16;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // onlineTab
            // 
            this.onlineTab.Controls.Add(this.usersListBox);
            this.onlineTab.Location = new System.Drawing.Point(4, 22);
            this.onlineTab.Name = "onlineTab";
            this.onlineTab.Padding = new System.Windows.Forms.Padding(3);
            this.onlineTab.Size = new System.Drawing.Size(186, 246);
            this.onlineTab.TabIndex = 0;
            this.onlineTab.Text = "online";
            this.onlineTab.UseVisualStyleBackColor = true;
            // 
            // usersListBox
            // 
            this.usersListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.usersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.Location = new System.Drawing.Point(3, 3);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(180, 240);
            this.usersListBox.TabIndex = 4;
            this.usersListBox.SelectedIndexChanged += new System.EventHandler(this.usersListBox_SelectedIndexChanged_1);
            this.usersListBox.DoubleClick += new System.EventHandler(this.usersListBox_DoubleClick_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatUserToolStripMenuItem,
            this.openInBrowserToolStripMenuItem,
            this.addToFavouritesToolStripMenuItem,
            this.removeFromListToolStripMenuItem,
            this.blockToolStripMenuItem,
            this.downloadAllPhotosToolStripMenuItem,
            this.toolStripSeparator1,
            this.preMessage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 169);
            // 
            // chatUserToolStripMenuItem
            // 
            this.chatUserToolStripMenuItem.Name = "chatUserToolStripMenuItem";
            this.chatUserToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.chatUserToolStripMenuItem.Text = "chat user";
            this.chatUserToolStripMenuItem.Click += new System.EventHandler(this.chatUserToolStripMenuItem_Click);
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openInBrowserToolStripMenuItem.Text = "open in browser";
            this.openInBrowserToolStripMenuItem.Click += new System.EventHandler(this.openInBrowserToolStripMenuItem_Click);
            // 
            // addToFavouritesToolStripMenuItem
            // 
            this.addToFavouritesToolStripMenuItem.Name = "addToFavouritesToolStripMenuItem";
            this.addToFavouritesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addToFavouritesToolStripMenuItem.Text = "add to favourites";
            this.addToFavouritesToolStripMenuItem.Click += new System.EventHandler(this.addToFavouritesToolStripMenuItem_Click);
            // 
            // removeFromListToolStripMenuItem
            // 
            this.removeFromListToolStripMenuItem.Name = "removeFromListToolStripMenuItem";
            this.removeFromListToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.removeFromListToolStripMenuItem.Text = "remove from list";
            this.removeFromListToolStripMenuItem.Click += new System.EventHandler(this.removeFromListToolStripMenuItem_Click);
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.blockToolStripMenuItem.Text = "block";
            this.blockToolStripMenuItem.Click += new System.EventHandler(this.blockToolStripMenuItem_Click);
            // 
            // downloadAllPhotosToolStripMenuItem
            // 
            this.downloadAllPhotosToolStripMenuItem.Name = "downloadAllPhotosToolStripMenuItem";
            this.downloadAllPhotosToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.downloadAllPhotosToolStripMenuItem.Text = "download all photos";
            this.downloadAllPhotosToolStripMenuItem.Click += new System.EventHandler(this.downloadAllPhotosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // preMessage
            // 
            this.preMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.preMessage.Items.AddRange(new object[] {
            "Pre-messages"});
            this.preMessage.MaxDropDownItems = 100;
            this.preMessage.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.preMessage.Name = "preMessage";
            this.preMessage.Size = new System.Drawing.Size(121, 23);
            this.preMessage.SelectedIndexChanged += new System.EventHandler(this.preMessage_SelectedIndexChanged);
            this.preMessage.Click += new System.EventHandler(this.preMessage_Click);
            // 
            // favTab
            // 
            this.favTab.Controls.Add(this.favListBox);
            this.favTab.Location = new System.Drawing.Point(4, 22);
            this.favTab.Name = "favTab";
            this.favTab.Padding = new System.Windows.Forms.Padding(3);
            this.favTab.Size = new System.Drawing.Size(186, 246);
            this.favTab.TabIndex = 1;
            this.favTab.Text = "favourite";
            this.favTab.UseVisualStyleBackColor = true;
            // 
            // favListBox
            // 
            this.favListBox.ContextMenuStrip = this.contextMenuStrip1;
            this.favListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.favListBox.FormattingEnabled = true;
            this.favListBox.Location = new System.Drawing.Point(3, 3);
            this.favListBox.Name = "favListBox";
            this.favListBox.Size = new System.Drawing.Size(180, 240);
            this.favListBox.TabIndex = 0;
            this.favListBox.SelectedIndexChanged += new System.EventHandler(this.favListBox_SelectedIndexChanged);
            this.favListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.favListBox_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(445, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Help:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 420);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.showCurrentPhoto);
            this.Controls.Add(this.currentTown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.currentAge);
            this.Controls.Add(this.currentName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.newMsgTxtBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.userImage);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "Form1";
            this.Text = "BadooChat";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagesCount)).EndInit();
            this.trayMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.onlineTab.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.favTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox userImage;
        private System.Windows.Forms.TextBox newMsgTxtBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Timer timerUpdateData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown pagesCount;
        private System.Windows.Forms.CheckBox refreshCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label S1Label;
        private System.Windows.Forms.Label RTLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timerForTrayIcon;
        private System.Windows.Forms.Button searcherButton;
        private System.Windows.Forms.Timer timerRedrawAll;
        private System.Windows.Forms.ToolStripStatusLabel MSLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox currentName;
        private System.Windows.Forms.TextBox currentAge;
        private System.Windows.Forms.TextBox currentTown;
        private System.Windows.Forms.Label showCurrentPhoto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage onlineTab;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.TabPage favTab;
        private System.Windows.Forms.ListBox favListBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chatUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToFavouritesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromListToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox preMessage;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem downloadAllPhotosToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

