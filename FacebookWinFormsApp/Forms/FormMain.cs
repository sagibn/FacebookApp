using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading;
using System.Diagnostics;
using BasicFacebookFeatures.Logic;
using System.Xml;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private UserProxy m_User;
        private Settings m_Settings;
        private ILanguageStrategy m_LanguageStrategy;
        public FormMain(LoginResult i_loginResult, User i_User)
        {
            m_LoginResult = i_loginResult;
            m_User = new UserProxy(i_User);
            m_Settings = Settings.Instance;
            InitializeComponent();
            this.checkBoxRememberMe.Checked = m_Settings.RememberUser;
            applyFontByName(m_Settings.FontName);
            m_LanguageStrategy = LanguageFactory.Create(m_Settings.Language);
            this.Size = new Size(m_Settings.LastWindowSize.Width, m_Settings.LastWindowSize.Height);
        }

        private void applyFontByName(string i_FontName)
        {
            Font newFont = new Font(i_FontName, 10, FontStyle.Regular);

            applyFontToAllComponents(newFont, false);
        }

        private void completeUIFromFacebookData()
        {
            FacebookService.s_CollectionLimit = 25;
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
            new Thread(fetchAlbums).Start();
            new Thread(fetchGroups).Start();
            new Thread(() => FormHelper.FetchFacebookItem(listBoxFriends,
                                                (m_User != null) ? m_User.Friends : null)).Start();
            new Thread(() => FormHelper.FetchFacebookItem(listBoxPages,
                                                (m_User != null) ? m_User.LikedPages : null)).Start();
            new Thread(() => FormHelper.FetchPersonalData(m_User, labelData, m_LanguageStrategy.Execute())).Start();
            this.Invoke(new Action(() => this.Text = $"Connected as {m_User.Name}"));
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            new Thread(() =>
            {
                completeUIFromFacebookData();
                loadLanguage(m_LanguageStrategy.Execute());
            }).Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m_Settings.RememberUser = checkBoxRememberMe.Checked;
            m_Settings.UserAccessToken = ((m_LoginResult != null) && (checkBoxRememberMe.Checked == true))
                ? m_LoginResult.AccessToken : null;
            m_Settings.LastWindowSize = this.Size;
            m_Settings.FontName = this.Font.Name;
            m_Settings.Language = m_LanguageStrategy.Execute();
            m_Settings.SaveSettingsToFile();
            base.OnFormClosing(e);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            m_LoginResult = null;
            m_User = null;
            buttonLogout.Enabled = false;
            this.Close();

        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            new Thread(() => FormHelper.FetchFacebookItem(listBoxFriends,
                                                (m_User != null) ? m_User.Friends : null)).Start();
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                sendEmail();
                textBoxEmailSubject.Invoke(new Action(() => textBoxEmailSubject.Text = "--subject--"));
                textBoxEmailBody.Invoke(new Action(() => textBoxEmailBody.Text = "--write your message here--"));
            });

            thread.Start();
        }

        private void sendEmail()
        {
            if (m_User != null)
            {
                EmailSender emailSender = EmailSender.Instance;

                emailSender.RecipientEmail = m_User.Email;
                emailSender.Subject = textBoxEmailSubject.Text;
                string response = emailSender.SendEmail(textBoxEmailBody.Text);

                MessageBox.Show(response, "Message", MessageBoxButtons.OK);
            }
            else
            {
                FormHelper.MustLoginMessage();
            }
        }

        private void buttonPages_Click(object sender, EventArgs e)
        {
            new Thread(() => FormHelper.FetchFacebookItem(listBoxPages,
                                                (m_User != null) ? m_User.LikedPages : null)).Start();
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHelper.ShowPhotoOfSelectedItem(listBoxPages, pictureBoxPages);
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            new Thread(fetchAlbums).Start();
        }

        private void fetchAlbums()
        {
            this.Invoke(new Action(() => albumBindingSource.DataSource = m_User.Albums));
        }

        private void fetchPosts()
        {
            listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Clear()));
            listBoxPosts.Invoke(new Action(() => listBoxPosts.DisplayMember = "Name"));

            try
            {
                if (m_User != null)
                {
                    foreach (Post post in m_User.Posts)
                    {
                        if (post.Message != null)
                        {
                            listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Message)));
                        }
                        else if (post.Caption != null)
                        {
                            listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(post.Caption)));
                        }
                        else
                        {
                            listBoxPosts.Invoke(new Action(() => listBoxPosts.Items.Add(string.Format("[{0}]", post.Type))));
                        }
                    }

                    if (listBoxPosts.Items.Count == 0)
                    {
                        MessageBox.Show("No Posts available");
                    }
                }
                else
                {
                    FormHelper.MustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            new Thread(fetchPosts).Start();
        }

        private Dictionary<IFacebookObjectProxy, int> getListOfMostLikedFriends()
        {
            Dictionary<IFacebookObjectProxy, int> userLikes = null;

            fetchPosts();

            try
            {
                if (listBoxPosts.Items.Count > 0)
                {
                    userLikes = new Dictionary<IFacebookObjectProxy, int>();

                    foreach (Post post in m_User.Posts)
                    {
                        foreach (User user in post.LikedBy)
                        {
                            if (userLikes.ContainsKey(new UserProxy(user)))
                            {
                                userLikes[new UserProxy(user)]++;
                            }
                            else
                            {
                                userLikes.Add(new UserProxy(user), 1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            return userLikes;
        }

        private void buttonLikedFriends_Click(object sender, EventArgs e)
        {
            Dictionary<IFacebookObjectProxy, int> userLikes = getListOfMostLikedFriends();
            if (userLikes == null)
            {
                MessageBox.Show("Empty list");
            }
            else
            {
                var userLikesByOrder = userLikes.OrderByDescending(pair => pair.Value).ToList();

                foreach (var item in userLikesByOrder)
                {
                    listBoxLikedFriends.Items.Add($"{item.Key.Name} - {item.Value} likes");
                }
            }
        }

        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeBackgroundColorOption();
        }

        private void changeBackgroundColorOption()
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.tabPageHome.BackColor = colorDialog.Color;
                this.tabPageProfile.BackColor = colorDialog.Color;
            }
        }

        private void darkmodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            darkmodeOption();
        }

        private void darkmodeOption()
        {
            if (darkmodeToolStripMenuItem.Text == "Enable Dark Mode")
            {
                darkmodeToolStripMenuItem.Text = "Disable Dark Mode";
                this.tabPageHome.BackColor = Color.FromArgb(30, 30, 30);
                this.tabPageHome.ForeColor = Color.White;
                this.tabPageProfile.BackColor = Color.FromArgb(30, 30, 30);
                this.tabPageProfile.ForeColor = Color.White;
                this.changeBackgroundColorToolStripMenuItem.Enabled = false;
            }
            else
            {
                darkmodeToolStripMenuItem.Text = "Enable Dark Mode";
                this.tabPageHome.BackColor = SystemColors.Control;
                this.tabPageHome.ForeColor = SystemColors.ControlText;
                this.tabPageProfile.BackColor = SystemColors.Control;
                this.tabPageProfile.ForeColor = SystemColors.ControlText;
                this.changeBackgroundColorToolStripMenuItem.Enabled = true;
            }
        }

        private void captureScreenshotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            captureScreenshot();
        }

        private void captureScreenshot()
        {
            Bitmap screenshot = new Bitmap(Width, Height);

            DrawToBitmap(screenshot, new Rectangle(0, 0, Width, Height));
            Settings.CreateFile($"{Settings.GetSolutionRoot()}\\FacebookWinFormsApp\\Screenshots");
            string fileName = $"{Settings.GetSolutionRoot()}\\FacebookWinFormsApp\\Screenshots\\Screenshot_{DateTime.Now:yyyyMMddHHmmss}.png";

            screenshot.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
            MessageBox.Show($"Screenshot saved as '{fileName}'.", "Screenshot Saved", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFontDialog();
        }

        private void openFontDialog()
        {
            FontDialog fontDialog = new FontDialog();

            fontDialog.MinSize = 8;
            fontDialog.MaxSize = 14;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = fontDialog.Font;

                applyFontToAllComponents(selectedFont, true);
            }
        }

        private void applyFontToAllComponents(Font i_ChosenFont, bool i_ChangeSize)
        {
            foreach (Control control in Controls)
            {
                applyFontRecursively(control, i_ChosenFont, i_ChangeSize);
            }

            this.Font = i_ChosenFont;
        }

        private void applyFontRecursively(Control i_Control, Font i_Font, bool i_ChangeSize)
        {
            if (i_ChangeSize)
            {
                i_Control.Font = i_Font;
            }
            else
            {
                i_Control.Font = new Font(i_Font.Name, i_Control.Font.Size, FontStyle.Regular);
            }

            foreach (Control childControl in i_Control.Controls)
            {
                applyFontRecursively(childControl, i_Font, i_ChangeSize);
            }
        }

        private void buttonNewPost_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_User.PostStatus(textBoxNewPost.Text);
                MessageBox.Show("Status posted successfully.\nID: " + postedStatus.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHelper.ShowPhotoOfSelectedItem(listBoxFriends, pictureBoxFriends);
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHelper.HelpMessage();
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string recipientEmail = "desigpatter57@gmail.com";
                string subject = $"Feedback from {m_User.Email}";
                string mailtoUri = $"mailto:{recipientEmail}?subject={Uri.EscapeDataString(subject)}";

                Process.Start(new ProcessStartInfo(mailtoUri));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            new Thread(fetchGroups).Start();
        }

        private void fetchGroups()
        {
            this.Invoke(new Action(() => groupBindingSource.DataSource = m_User.Groups));
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxGroups.SelectedItem as Group;

                if (selectedGroup.Id != null)
                {
                    linkGroup.Text = $"www.facebook.com/groups/{selectedGroup.Id}";
                }
            }
        }

        private void linkGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (listBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxGroups.SelectedItem as Group;
                if (selectedGroup.Id != null)
                {
                    try
                    {
                        Process.Start($"www.facebook.com/groups/{selectedGroup.Id}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void changeLanguage(Control i_Control, XmlDocument i_XmlDoc)
        {
            XmlNode node = i_XmlDoc.SelectSingleNode($"//Language/{i_Control.Name}");

            if (node != null)
            {
                i_Control.Invoke(new Action(() => i_Control.Text = node.InnerText));
            }

            foreach(Control childControl in i_Control.Controls)
            {
                changeLanguage(childControl, i_XmlDoc);
            }
        }

        private void loadLanguage(string i_LanguageCode)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load($"{Settings.GetSolutionRoot()}\\FacebookWinFormsApp\\Language\\{i_LanguageCode}.xml");

            foreach(Control control in Controls)
            {
                changeLanguage(control, xmlDoc);
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_LanguageStrategy = LanguageFactory.Create("en-US");
            markLanguageToolStrip(sender);
        }

        private void markLanguageToolStrip(object sender)
        {
            foreach (ToolStripMenuItem menuItem in languageToolStripMenuItem.DropDownItems)
            {
                if (menuItem == sender)
                {
                    menuItem.Checked = true;
                }
                else
                {
                    menuItem.Checked = false;
                }
            }

            applyToolStripMenuItem.Enabled = true;
        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLanguage(m_LanguageStrategy.Execute());
            FormHelper.FetchPersonalData(m_User, labelData, m_LanguageStrategy.Execute());
        }

        private void hebrewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_LanguageStrategy = LanguageFactory.Create("he-IL");
            markLanguageToolStrip(sender);
        }
    }
}
