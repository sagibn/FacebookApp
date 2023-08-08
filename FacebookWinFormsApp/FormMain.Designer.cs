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
            this.tabSortAlbums = new System.Windows.Forms.TabPage();
            this.buttonSortAlbums = new System.Windows.Forms.Button();
            this.buttonEmail = new System.Windows.Forms.Button();
            this.textBoxEmailBody = new System.Windows.Forms.TextBox();
            this.textBoxEmailSubject = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxAlbums = new System.Windows.Forms.PictureBox();
            this.pictureBoxGroups = new System.Windows.Forms.PictureBox();
            this.facebookLogo = new System.Windows.Forms.PictureBox();
            this.buttonFriends = new System.Windows.Forms.Button();
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.buttonAlbums = new System.Windows.Forms.Button();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.buttonGroups = new System.Windows.Forms.Button();
            this.listBoxGroups = new System.Windows.Forms.ListBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabSortAlbums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.Red;
            this.buttonLogout.Enabled = false;
            this.buttonLogout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLogout.Location = new System.Drawing.Point(1133, 0);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(99, 39);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSortAlbums);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1243, 697);
            this.tabControl1.TabIndex = 54;
            // 
            // tabSortAlbums
            // 
            this.tabSortAlbums.BackColor = System.Drawing.Color.Transparent;
            this.tabSortAlbums.Controls.Add(this.buttonSortAlbums);
            this.tabSortAlbums.Controls.Add(this.buttonEmail);
            this.tabSortAlbums.Controls.Add(this.textBoxEmailBody);
            this.tabSortAlbums.Controls.Add(this.textBoxEmailSubject);
            this.tabSortAlbums.Controls.Add(this.pictureBox3);
            this.tabSortAlbums.Controls.Add(this.pictureBoxAlbums);
            this.tabSortAlbums.Controls.Add(this.pictureBoxGroups);
            this.tabSortAlbums.Controls.Add(this.facebookLogo);
            this.tabSortAlbums.Controls.Add(this.buttonFriends);
            this.tabSortAlbums.Controls.Add(this.listBoxFriends);
            this.tabSortAlbums.Controls.Add(this.buttonAlbums);
            this.tabSortAlbums.Controls.Add(this.listBoxAlbums);
            this.tabSortAlbums.Controls.Add(this.buttonGroups);
            this.tabSortAlbums.Controls.Add(this.listBoxGroups);
            this.tabSortAlbums.Controls.Add(this.pictureBoxProfile);
            this.tabSortAlbums.Controls.Add(this.buttonLogout);
            this.tabSortAlbums.Location = new System.Drawing.Point(4, 35);
            this.tabSortAlbums.Name = "tabSortAlbums";
            this.tabSortAlbums.Padding = new System.Windows.Forms.Padding(3);
            this.tabSortAlbums.Size = new System.Drawing.Size(1235, 658);
            this.tabSortAlbums.TabIndex = 0;
            this.tabSortAlbums.Text = "tabPage1";
            this.tabSortAlbums.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // buttonSortAlbums
            // 
            this.buttonSortAlbums.BackColor = System.Drawing.Color.PowderBlue;
            this.buttonSortAlbums.Location = new System.Drawing.Point(500, 302);
            this.buttonSortAlbums.Name = "buttonSortAlbums";
            this.buttonSortAlbums.Size = new System.Drawing.Size(134, 35);
            this.buttonSortAlbums.TabIndex = 71;
            this.buttonSortAlbums.Text = "sort by date";
            this.buttonSortAlbums.UseVisualStyleBackColor = false;
            this.buttonSortAlbums.Click += new System.EventHandler(this.buttonSortAlbums_Click);
            // 
            // buttonEmail
            // 
            this.buttonEmail.Location = new System.Drawing.Point(594, 190);
            this.buttonEmail.Name = "buttonEmail";
            this.buttonEmail.Size = new System.Drawing.Size(367, 39);
            this.buttonEmail.TabIndex = 68;
            this.buttonEmail.Text = "click here to send Email to yourself";
            this.buttonEmail.UseVisualStyleBackColor = true;
            this.buttonEmail.Click += new System.EventHandler(this.emailButton_Click);
            // 
            // textBoxEmailBody
            // 
            this.textBoxEmailBody.Location = new System.Drawing.Point(305, 103);
            this.textBoxEmailBody.Multiline = true;
            this.textBoxEmailBody.Name = "textBoxEmailBody";
            this.textBoxEmailBody.Size = new System.Drawing.Size(656, 126);
            this.textBoxEmailBody.TabIndex = 70;
            this.textBoxEmailBody.Text = "--write your message here--";
            // 
            // textBoxEmailSubject
            // 
            this.textBoxEmailSubject.Location = new System.Drawing.Point(305, 65);
            this.textBoxEmailSubject.Name = "textBoxEmailSubject";
            this.textBoxEmailSubject.Size = new System.Drawing.Size(242, 32);
            this.textBoxEmailSubject.TabIndex = 69;
            this.textBoxEmailSubject.Text = "--subject--";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox3.Location = new System.Drawing.Point(907, 343);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(110, 110);
            this.pictureBox3.TabIndex = 67;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBoxAlbums
            // 
            this.pictureBoxAlbums.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxAlbums.Location = new System.Drawing.Point(524, 343);
            this.pictureBoxAlbums.Name = "pictureBoxAlbums";
            this.pictureBoxAlbums.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxAlbums.TabIndex = 66;
            this.pictureBoxAlbums.TabStop = false;
            // 
            // pictureBoxGroups
            // 
            this.pictureBoxGroups.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBoxGroups.Location = new System.Drawing.Point(176, 343);
            this.pictureBoxGroups.Name = "pictureBoxGroups";
            this.pictureBoxGroups.Size = new System.Drawing.Size(110, 110);
            this.pictureBoxGroups.TabIndex = 65;
            this.pictureBoxGroups.TabStop = false;
            // 
            // facebookLogo
            // 
            this.facebookLogo.Image = global::BasicFacebookFeatures.Properties.Resources.FacebookLogo;
            this.facebookLogo.Location = new System.Drawing.Point(1102, 86);
            this.facebookLogo.Name = "facebookLogo";
            this.facebookLogo.Size = new System.Drawing.Size(130, 130);
            this.facebookLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.facebookLogo.TabIndex = 64;
            this.facebookLogo.TabStop = false;
            // 
            // buttonFriends
            // 
            this.buttonFriends.Location = new System.Drawing.Point(722, 261);
            this.buttonFriends.Name = "buttonFriends";
            this.buttonFriends.Size = new System.Drawing.Size(153, 35);
            this.buttonFriends.TabIndex = 62;
            this.buttonFriends.Text = "Fetch Friends";
            this.buttonFriends.UseVisualStyleBackColor = true;
            this.buttonFriends.Click += new System.EventHandler(this.buttonFriends_Click);
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 26;
            this.listBoxFriends.Location = new System.Drawing.Point(722, 302);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(295, 160);
            this.listBoxFriends.TabIndex = 61;
            // 
            // buttonAlbums
            // 
            this.buttonAlbums.Location = new System.Drawing.Point(347, 261);
            this.buttonAlbums.Name = "buttonAlbums";
            this.buttonAlbums.Size = new System.Drawing.Size(160, 35);
            this.buttonAlbums.TabIndex = 60;
            this.buttonAlbums.Text = "Fetch Albums";
            this.buttonAlbums.UseVisualStyleBackColor = true;
            this.buttonAlbums.Click += new System.EventHandler(this.buttonAlbums_Click);
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 26;
            this.listBoxAlbums.Location = new System.Drawing.Point(347, 302);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(287, 160);
            this.listBoxAlbums.TabIndex = 59;
            this.listBoxAlbums.SelectedIndexChanged += new System.EventHandler(this.listBoxAlbums_SelectedIndexChanged);
            // 
            // buttonGroups
            // 
            this.buttonGroups.Location = new System.Drawing.Point(18, 261);
            this.buttonGroups.Name = "buttonGroups";
            this.buttonGroups.Size = new System.Drawing.Size(158, 35);
            this.buttonGroups.TabIndex = 58;
            this.buttonGroups.Text = "Fetch Groups";
            this.buttonGroups.UseVisualStyleBackColor = true;
            this.buttonGroups.Click += new System.EventHandler(this.buttonGroups_Click);
            // 
            // listBoxGroups
            // 
            this.listBoxGroups.FormattingEnabled = true;
            this.listBoxGroups.ItemHeight = 26;
            this.listBoxGroups.Location = new System.Drawing.Point(18, 302);
            this.listBoxGroups.Name = "listBoxGroups";
            this.listBoxGroups.Size = new System.Drawing.Size(268, 160);
            this.listBoxGroups.TabIndex = 57;
            this.listBoxGroups.SelectedIndexChanged += new System.EventHandler(this.listBoxGroups_SelectedIndexChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(45, 103);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(158, 126);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 697);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSortAlbums.ResumeLayout(false);
            this.tabSortAlbums.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbums)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facebookLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabSortAlbums;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonFriends;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.Button buttonAlbums;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.Button buttonGroups;
        private System.Windows.Forms.ListBox listBoxGroups;
        private System.Windows.Forms.PictureBox facebookLogo;
        private System.Windows.Forms.Button buttonEmail;
        private System.Windows.Forms.TextBox textBoxEmailBody;
        private System.Windows.Forms.TextBox textBoxEmailSubject;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBoxAlbums;
        private System.Windows.Forms.PictureBox pictureBoxGroups;
        private System.Windows.Forms.Button buttonSortAlbums;
    }
}

