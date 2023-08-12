namespace BasicFacebookFeatures
{
    partial class FormMain
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
            this.buttonLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.buttonNewPost = new System.Windows.Forms.Button();
            this.textBoxNewPost = new System.Windows.Forms.TextBox();
            this.labelNewPost = new System.Windows.Forms.Label();
            this.checkBoxRememberMe = new System.Windows.Forms.CheckBox();
            this.buttonSortAlbums = new System.Windows.Forms.Button();
            this.buttonFriends = new System.Windows.Forms.Button();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.buttonAlbums = new System.Windows.Forms.Button();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.buttonPages = new System.Windows.Forms.Button();
            this.listBoxPages = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureScreenshotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeBackgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkmodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendFeedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageProfile = new System.Windows.Forms.TabPage();
            this.listBoxPosts = new System.Windows.Forms.ListBox();
            this.buttonEvents = new System.Windows.Forms.Button();
            this.listBoxEvents = new System.Windows.Forms.ListBox();
            this.labelData = new System.Windows.Forms.Label();
            this.buttonLikedFriends = new System.Windows.Forms.Button();
            this.listBoxLikedFriends = new System.Windows.Forms.ListBox();
            this.buttonPosts = new System.Windows.Forms.Button();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.textBoxEmailBody = new System.Windows.Forms.TextBox();
            this.textBoxEmailSubject = new System.Windows.Forms.TextBox();
            this.textBoxEmailSender = new System.Windows.Forms.TextBox();
            this.pictureBoxPages = new System.Windows.Forms.PictureBox();
            this.pictureBoxAlbums = new System.Windows.Forms.PictureBox();
            this.pictureBoxFriends = new System.Windows.Forms.PictureBox();
            this.facebookLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Red;
            this.buttonLogout.Enabled = false;
            this.buttonLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLogout.Location = new System.Drawing.Point(1139, 0);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(96, 36);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHome);
            this.tabControl1.Controls.Add(this.tabPageProfile);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPageHome
            // 
            this.tabPageHome.BackColor = System.Drawing.Color.Transparent;
            this.tabPageHome.Controls.Add(this.buttonSortAlbums);
            this.tabPageHome.Controls.Add(this.buttonGroups);
            this.tabPageHome.Controls.Add(this.listBoxGroups);
            this.tabPageHome.Controls.Add(this.buttonNewPost);
            this.tabPageHome.Controls.Add(this.textBoxNewPost);
            this.tabPageHome.Controls.Add(this.labelNewPost);
            this.tabPageHome.Controls.Add(this.pictureBoxPages);
            this.tabPageHome.Controls.Add(this.pictureBoxAlbums);
            this.tabPageHome.Controls.Add(this.pictureBoxFriends);
            this.tabPageHome.Controls.Add(this.checkBoxRememberMe);
            this.tabPageHome.Controls.Add(this.facebookLogo);
            this.tabPageHome.Controls.Add(this.buttonFriends);
            this.tabPageHome.Controls.Add(this.buttonAlbums);
            this.tabPageHome.Controls.Add(this.buttonPages);
            this.tabPageHome.Controls.Add(this.pictureBoxProfile);
            this.tabPageHome.Controls.Add(this.buttonLogout);
            this.tabPageHome.Controls.Add(this.menuStrip1);
            this.tabPageHome.Controls.Add(this.listBoxPages);
            this.tabPageHome.Controls.Add(this.listBoxAlbums);
            this.tabPageHome.Controls.Add(this.listBoxFriends);
            this.tabPageHome.Location = new System.Drawing.Point(4, 35);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(1235, 658);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Home";
            // 
            // buttonGroups
            // 
            this.buttonGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGroups.Location = new System.Drawing.Point(772, 55);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(207, 35);
            this.buttonGroups.TabIndex = 79;
            this.buttonGroups.Text = "Show list of groups";
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 26;
            this.listBoxGroups.Location = new System.Drawing.Point(772, 96);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(268, 160);
            this.listBoxGroups.TabIndex = 78;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxGroups_SelectedIndexChanged);
            // 
            // buttonNewPost
            // 
            this.buttonNewPost.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonNewPost.Location = new System.Drawing.Point(538, 200);
            this.buttonNewPost.Name = "buttonNewPost";
            this.buttonNewPost.Size = new System.Drawing.Size(90, 32);
            this.buttonNewPost.TabIndex = 77;
            this.buttonNewPost.Text = "Post";
            this.buttonNewPost.UseVisualStyleBackColor = false;
            this.buttonNewPost.Click += new System.EventHandler(this.buttonNewPost_Click);
            // 
            // textBoxNewPost
            // 
            this.textBoxNewPost.Location = new System.Drawing.Point(334, 96);
            this.textBoxNewPost.Multiline = true;
            this.textBoxNewPost.Name = "textBoxNewPost";
            this.textBoxNewPost.Size = new System.Drawing.Size(295, 137);
            this.textBoxNewPost.TabIndex = 76;
            // 
            // labelNewPost
            // 
            this.labelNewPost.AutoSize = true;
            this.labelNewPost.Location = new System.Drawing.Point(329, 49);
            this.labelNewPost.Name = "labelNewPost";
            this.labelNewPost.Size = new System.Drawing.Size(262, 26);
            this.labelNewPost.TabIndex = 75;
            this.labelNewPost.Text = "Share your thoughts here:";
            // 
            // checkBoxRememberMe
            // 
            this.checkBoxRememberMe.AutoSize = true;
            this.checkBoxRememberMe.Location = new System.Drawing.Point(18, 45);
            this.checkBoxRememberMe.Name = "checkBoxRememberMe";
            this.checkBoxRememberMe.Size = new System.Drawing.Size(184, 30);
            this.checkBoxRememberMe.TabIndex = 72;
            this.checkBoxRememberMe.Text = "Remember me";
            this.checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // buttonSortAlbums
            // 
            this.buttonSortAlbums.BackColor = System.Drawing.Color.PowderBlue;
            this.buttonSortAlbums.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSortAlbums.Location = new System.Drawing.Point(538, 333);
            this.buttonSortAlbums.Name = "buttonSortAlbums";
            this.buttonSortAlbums.Size = new System.Drawing.Size(172, 35);
            this.buttonSortAlbums.TabIndex = 71;
            this.buttonSortAlbums.Text = "sort by created date";
            this.buttonSortAlbums.UseVisualStyleBackColor = false;
            this.buttonSortAlbums.Click += new System.EventHandler(this.buttonSortAlbums_Click);
            // 
            // buttonFriends
            // 
            this.buttonFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFriends.Location = new System.Drawing.Point(772, 292);
            this.buttonFriends.Name = "buttonFriends";
            this.buttonFriends.Size = new System.Drawing.Size(170, 35);
            this.buttonFriends.TabIndex = 62;
            this.buttonFriends.Text = "Show list of friends";
            this.buttonFriends.UseVisualStyleBackColor = true;
            this.buttonFriends.Click += new System.EventHandler(this.buttonFriends_Click);
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 26;
            this.listBoxFriends.Location = new System.Drawing.Point(772, 333);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(295, 160);
            this.listBoxFriends.TabIndex = 61;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // buttonAlbums
            // 
            this.buttonAlbums.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAlbums.Location = new System.Drawing.Point(382, 292);
            this.buttonAlbums.Name = "buttonAlbums";
            this.buttonAlbums.Size = new System.Drawing.Size(173, 35);
            this.buttonAlbums.TabIndex = 60;
            this.buttonAlbums.Text = "Show list of albums";
            this.buttonAlbums.UseVisualStyleBackColor = true;
            this.buttonAlbums.Click += new System.EventHandler(this.buttonAlbums_Click);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 26;
            this.listBoxAlbums.Location = new System.Drawing.Point(382, 333);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(287, 160);
            this.listBoxAlbums.TabIndex = 59;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // buttonPages
            // 
            this.buttonPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPages.Location = new System.Drawing.Point(18, 292);
            this.buttonPages.Name = "buttonPages";
            this.buttonPages.Size = new System.Drawing.Size(207, 35);
            this.buttonPages.TabIndex = 58;
            this.buttonPages.Text = "Show list of liked pages";
            this.buttonPages.UseVisualStyleBackColor = true;
            this.buttonPages.Click += new System.EventHandler(this.buttonPages_Click);
            // 
            // listBoxPages
            // 
            this.listBoxPages.FormattingEnabled = true;
            this.listBoxPages.ItemHeight = 26;
            this.listBoxPages.Location = new System.Drawing.Point(18, 333);
            this.listBoxPages.Name = "listBoxPages";
            this.listBoxPages.Size = new System.Drawing.Size(268, 160);
            this.listBoxPages.TabIndex = 57;
            this.listBoxPages.SelectedIndexChanged += new System.EventHandler(this.listBoxPages_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1229, 36);
            this.menuStrip1.TabIndex = 74;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFontToolStripMenuItem,
            this.captureScreenshotToolStripMenuItem,
            this.changeBackgroundColorToolStripMenuItem,
            this.darkmodeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(348, 34);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // captureScreenshotToolStripMenuItem
            // 
            this.captureScreenshotToolStripMenuItem.Name = "captureScreenshotToolStripMenuItem";
            this.captureScreenshotToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F10)));
            this.captureScreenshotToolStripMenuItem.Size = new System.Drawing.Size(348, 34);
            this.captureScreenshotToolStripMenuItem.Text = "Capture Screenshot";
            this.captureScreenshotToolStripMenuItem.Click += new System.EventHandler(this.captureScreenshotToolStripMenuItem_Click);
            // 
            // changeBackgroundColorToolStripMenuItem
            // 
            this.changeBackgroundColorToolStripMenuItem.Name = "changeBackgroundColorToolStripMenuItem";
            this.changeBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(348, 34);
            this.changeBackgroundColorToolStripMenuItem.Text = "Change Background Color";
            this.changeBackgroundColorToolStripMenuItem.Click += new System.EventHandler(this.changeBackgroundColorToolStripMenuItem_Click);
            // 
            // darkmodeToolStripMenuItem
            // 
            this.darkmodeToolStripMenuItem.Name = "darkmodeToolStripMenuItem";
            this.darkmodeToolStripMenuItem.Size = new System.Drawing.Size(348, 34);
            this.darkmodeToolStripMenuItem.Text = "Enable Dark Mode";
            this.darkmodeToolStripMenuItem.Click += new System.EventHandler(this.darkmodeToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.sendFeedbackToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            this.viewHelpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.viewHelpToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.viewHelpToolStripMenuItem.Text = "View Help";
            this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
            // 
            // sendFeedbackToolStripMenuItem
            // 
            this.sendFeedbackToolStripMenuItem.Name = "sendFeedbackToolStripMenuItem";
            this.sendFeedbackToolStripMenuItem.Size = new System.Drawing.Size(263, 34);
            this.sendFeedbackToolStripMenuItem.Text = "Send Feedback";
            this.sendFeedbackToolStripMenuItem.Click += new System.EventHandler(this.sendFeedbackToolStripMenuItem_Click);
            // 
            // tabPageProfile
            // 
            this.tabPageProfile.Controls.Add(this.listBoxPosts);
            this.tabPageProfile.Controls.Add(this.buttonEvents);
            this.tabPageProfile.Controls.Add(this.pictureBox1);
            this.tabPageProfile.Controls.Add(this.listBoxEvents);
            this.tabPageProfile.Controls.Add(this.labelData);
            this.tabPageProfile.Controls.Add(this.buttonLikedFriends);
            this.tabPageProfile.Controls.Add(this.listBoxLikedFriends);
            this.tabPageProfile.Controls.Add(this.buttonPosts);
            this.tabPageProfile.Controls.Add(this.buttonEmail);
            this.tabPageProfile.Controls.Add(this.textBoxEmailBody);
            this.tabPageProfile.Controls.Add(this.textBoxEmailSubject);
            this.tabPageProfile.Controls.Add(this.textBoxEmailSender);
            this.tabPageProfile.Location = new System.Drawing.Point(4, 35);
            this.tabPageProfile.Name = "tabPageProfile";
            this.tabPageProfile.Size = new System.Drawing.Size(1235, 658);
            this.tabPageProfile.TabIndex = 1;
            this.tabPageProfile.Text = "Profile";
            this.tabPageProfile.UseVisualStyleBackColor = true;
            // 
            // listBoxPosts
            // 
            this.listBoxPosts.FormattingEnabled = true;
            this.listBoxPosts.ItemHeight = 26;
            this.listBoxPosts.Location = new System.Drawing.Point(376, 82);
            this.listBoxPosts.Name = "listBoxPosts";
            this.listBoxPosts.Size = new System.Drawing.Size(443, 186);
            this.listBoxPosts.TabIndex = 0;
            // 
            // buttonEvents
            // 
            this.buttonEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEvents.Location = new System.Drawing.Point(20, 305);
            this.buttonEvents.Name = "buttonEvents";
            this.buttonEvents.Size = new System.Drawing.Size(212, 35);
            this.buttonEvents.TabIndex = 75;
            this.buttonEvents.Text = "Show list of your events";
            this.buttonEvents.UseVisualStyleBackColor = true;
            this.buttonEvents.Click += new System.EventHandler(this.buttonEvents_Click);
            // 
            // listBoxEvents
            // 
            this.listBoxEvents.FormattingEnabled = true;
            this.listBoxEvents.ItemHeight = 26;
            this.listBoxEvents.Location = new System.Drawing.Point(20, 346);
            this.listBoxEvents.Name = "listBoxEvents";
            this.listBoxEvents.Size = new System.Drawing.Size(268, 160);
            this.listBoxEvents.TabIndex = 74;
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(15, 42);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(194, 26);
            this.labelData.TabIndex = 64;
            this.labelData.Text = "Data about myself:";
            // 
            // buttonLikedFriends
            // 
            this.buttonLikedFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLikedFriends.Location = new System.Drawing.Point(847, 41);
            this.buttonLikedFriends.Name = "buttonLikedFriends";
            this.buttonLikedFriends.Size = new System.Drawing.Size(238, 35);
            this.buttonLikedFriends.TabIndex = 63;
            this.buttonLikedFriends.Text = "Show your most supporters";
            this.buttonLikedFriends.UseVisualStyleBackColor = true;
            this.buttonLikedFriends.Click += new System.EventHandler(this.buttonLikedFriends_Click);
            // 
            // listBoxLikedFriends
            // 
            this.listBoxLikedFriends.FormattingEnabled = true;
            this.listBoxLikedFriends.ItemHeight = 26;
            this.listBoxLikedFriends.Location = new System.Drawing.Point(847, 82);
            this.listBoxLikedFriends.Name = "listBoxLikedFriends";
            this.listBoxLikedFriends.Size = new System.Drawing.Size(238, 186);
            this.listBoxLikedFriends.TabIndex = 62;
            // 
            // buttonPosts
            // 
            this.buttonPosts.Location = new System.Drawing.Point(376, 41);
            this.buttonPosts.Name = "buttonPosts";
            this.buttonPosts.Size = new System.Drawing.Size(193, 35);
            this.buttonPosts.TabIndex = 61;
            this.buttonPosts.Text = "Show my posts";
            this.buttonPosts.UseVisualStyleBackColor = true;
            this.buttonPosts.Click += new System.EventHandler(this.buttonPosts_Click);
            // 
            // buttonEmail
            // 
            this.buttonEmail.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.buttonEmail.Location = new System.Drawing.Point(929, 467);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(103, 39);
            this.buttonEmail.TabIndex = 68;
            this.buttonEmail.Text = "Send\r\n";
            this.buttonEmail.UseVisualStyleBackColor = false;
            this.buttonEmail.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // textBoxEmailBody
            // 
            this.textBoxEmailBody.Location = new System.Drawing.Point(376, 380);
            this.textBoxEmailBody.Multiline = true;
            this.textBoxEmailBody.Name = "textBoxEmailBody";
            this.textBoxEmailBody.Size = new System.Drawing.Size(656, 126);
            this.textBoxEmailBody.TabIndex = 70;
            this.textBoxEmailBody.Text = "--write your message here--";
            // 
            // textBoxEmailSubject
            // 
            this.textBoxEmailSubject.Location = new System.Drawing.Point(376, 342);
            this.textBoxEmailSubject.Name = "textBoxEmailSubject";
            this.textBoxEmailSubject.Size = new System.Drawing.Size(242, 32);
            this.textBoxEmailSubject.TabIndex = 69;
            this.textBoxEmailSubject.Text = "--subject--";
            // 
            // textBoxEmailSender
            // 
            this.textBoxEmailSender.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBoxEmailSender.Location = new System.Drawing.Point(376, 291);
            this.textBoxEmailSender.Multiline = true;
            this.textBoxEmailSender.Name = "textBoxEmailSender";
            this.textBoxEmailSender.ReadOnly = true;
            this.textBoxEmailSender.Size = new System.Drawing.Size(656, 215);
            this.textBoxEmailSender.TabIndex = 73;
            this.textBoxEmailSender.Text = "Email Reminder";
            this.textBoxEmailSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxPages
            // 
            this.pictureBoxPages.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxPages.Location = new System.Drawing.Point(228, 434);
            this.pictureBoxPages.Name = "pictureBoxPages";
            this.pictureBoxPages.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxPages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPages.TabIndex = 65;
            this.pictureBoxPages.TabStop = false;
            // 
            // pictureBoxAlbums
            // 
            this.pictureBoxAlbums.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxAlbums.Location = new System.Drawing.Point(613, 434);
            this.pictureBoxAlbums.Name = "pictureBoxAlbums";
            this.pictureBoxAlbums.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxAlbums.TabIndex = 66;
            this.pictureBoxAlbums.TabStop = false;
            // 
            // pictureBoxFriends
            // 
            this.pictureBoxFriends.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxFriends.Location = new System.Drawing.Point(1013, 434);
            this.pictureBoxFriends.Name = "pictureBoxFriends";
            this.pictureBoxFriends.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxFriends.TabIndex = 67;
            this.pictureBoxFriends.TabStop = false;
            // 
            // facebookLogo
            // 
            this.facebookLogo.Image = global::BasicFacebookFeatures.Properties.Resources.FacebookLogo;
            this.facebookLogo.Location = new System.Drawing.Point(1105, 39);
            this.facebookLogo.Name = "facebookLogo";
            this.facebookLogo.Size = new System.Drawing.Size(130, 130);
            this.facebookLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.facebookLogo.TabIndex = 64;
            this.facebookLogo.TabStop = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(18, 96);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(185, 164);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BasicFacebookFeatures.Properties.Resources.FacebookLogo;
            this.pictureBox1.Location = new System.Drawing.Point(1105, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connecting...";
            this.tabControl1.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageHome.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPageProfile.ResumeLayout(false);
            this.tabPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonFriends;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.Button buttonAlbums;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Button buttonPages;
        private System.Windows.Forms.ListBox listBoxPages;
        private System.Windows.Forms.PictureBox facebookLogo;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.TextBox textBoxEmailBody;
        private System.Windows.Forms.TextBox textBoxEmailSubject;
        private System.Windows.Forms.PictureBox pictureBoxFriends;
        private System.Windows.Forms.PictureBox pictureBoxAlbums;
        private System.Windows.Forms.PictureBox pictureBoxPages;
        private System.Windows.Forms.Button buttonSortAlbums;
        private System.Windows.Forms.CheckBox checkBoxRememberMe;
        private System.Windows.Forms.TextBox textBoxEmailSender;
        private System.Windows.Forms.TabPage tabPageProfile;
        private System.Windows.Forms.Button buttonPosts;
        private System.Windows.Forms.ListBox listBoxPosts;
        private System.Windows.Forms.Button buttonLikedFriends;
        private System.Windows.Forms.ListBox listBoxLikedFriends;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeBackgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkmodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureScreenshotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.Button buttonNewPost;
        private System.Windows.Forms.TextBox textBoxNewPost;
        private System.Windows.Forms.Label labelNewPost;
        private System.Windows.Forms.Button buttonEvents;
        private System.Windows.Forms.ListBox listBoxEvents;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem sendFeedbackToolStripMenuItem;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.ListBox listBoxGroups;
    }
}

