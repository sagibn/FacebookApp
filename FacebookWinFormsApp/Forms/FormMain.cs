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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private User m_User;
        private Settings m_Settings;
        public FormMain(LoginResult i_loginResult, User i_user)
        {
            m_LoginResult = i_loginResult;
            m_User = i_user;
            m_Settings = Settings.Instance;
            InitializeComponent();
            this.Size = new Size(m_Settings.LastWindowSize.Width, m_Settings.LastWindowSize.Height);
            this.checkBoxRememberMe.Checked = m_Settings.RememberUser;
            applyFontByName(m_Settings.FontName);
        }

        private void applyFontByName(string i_FontName)
        {
            Font newFont = new Font(i_FontName, 11, FontStyle.Regular);

            applyFontToAllComponents(newFont);
        }

        private void completeUIFromFacebookData()
        {
            buttonLogout.Enabled = true;
            FacebookService.s_CollectionLimit = 25;
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
            fetchAlbums();
            fetchFriends();
            fetchPages();
            fetchGroups();
            fetchPersonalData();
            this.Text = $"Connected as {m_User.Name}";
        }

        private void fetchPersonalData()
        {
            string personalData = string.Format(@"About myself:
Name: {0}
Birthday: {1}
Gender: {2}
Hometown: {3}
Email: {4}
Relationship: {5}
Religion: {6}
My Location: {7}", m_User.Name, m_User.Birthday, m_User.Gender, m_User.Hometown, 
                    m_User.Email, m_User.RelationshipStatus, m_User.Religion, m_User.Location.Name);

            labelData.Text = personalData;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            completeUIFromFacebookData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m_Settings.RememberUser = checkBoxRememberMe.Checked;
            m_Settings.UserAccessToken = ((m_LoginResult != null) && (checkBoxRememberMe.Checked == true))
                ? m_LoginResult.AccessToken : null;
            m_Settings.LastWindowSize = this.Size;
            m_Settings.FontName = this.Font.Name;
            m_Settings.SaveSettingsToFile();
            base.OnFormClosing(e);
        }

        private void mustLoginMessage()
        {
            MessageBox.Show("Must login to use this feature", "Error", MessageBoxButtons.OK);
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
            fetchFriends();
        }

        private void fetchFriends()
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {
                    foreach (User friend in m_User.Friends)
                    {
                        listBoxFriends.Items.Add($"{friend.Name}");
                    }

                    if (listBoxFriends.Items.Count == 0)
                    {
                        MessageBox.Show("No friends available", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void emailButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(sendEmail);

            thread.Start();
        }

        private void sendEmail()
        {
            if (m_User != null)
            {
                string response = EmailSender.EmailSender.SendEmail(m_User.Email, textBoxEmailSubject.Text, textBoxEmailBody.Text);
                MessageBox.Show(response, "Message", MessageBoxButtons.OK);
                textBoxEmailSubject.Text = "--subject--";
                textBoxEmailBody.Text = "--write your message here--";
            }
            else
            {
                mustLoginMessage();
            }
        }

        private void buttonPages_Click(object sender, EventArgs e)
        {
            fetchPages();
        }

        private void fetchPages()
        {
            listBoxPages.Items.Clear();
            listBoxPages.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {
                    foreach (Page page in m_User.LikedPages)
                    {
                        listBoxPages.Items.Add(page);
                    }

                    if (listBoxPages.Items.Count == 0)
                    {
                        MessageBox.Show("No pages available", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPhotoOfSelectedPage();
        }

        private void showPhotoOfSelectedPage()
        {
            if (listBoxPages.SelectedItems.Count == 1)
            {
                Page selectedPage = listBoxPages.SelectedItem as Page;
                pictureBoxPages.LoadAsync(selectedPage.PictureNormalURL);
            }
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            fetchAlbums();
        }

        private void fetchAlbums()
        {
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {
                    foreach (Album album in m_User.Albums)
                    {
                        listBoxAlbums.Items.Add(album);
                    }

                    if (listBoxAlbums.Items.Count == 0)
                    {
                        MessageBox.Show("No Albums available", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void listBoxAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPhotoOfSelectedAlbum();
        }

        private void showPhotoOfSelectedAlbum()
        {
            if (listBoxAlbums.SelectedItems.Count == 1)
            {
                Album selectedAlbum = listBoxAlbums.SelectedItem as Album;
                if (selectedAlbum.PictureAlbumURL != null)
                {
                    pictureBoxAlbums.LoadAsync(selectedAlbum.PictureAlbumURL);
                }
            }
        }

        private void buttonSortAlbums_Click(object sender, EventArgs e)
        {
            sortAlbumsByCreatedDate();
        }

        private void sortAlbumsByCreatedDate()
        {
            listBoxAlbums.Items.Clear();
            listBoxAlbums.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {

                    List<Album> sortedAlbums = m_User.Albums.OrderBy(album => album.CreatedTime).ToList();

                    foreach (Album album in sortedAlbums)
                    {
                        listBoxAlbums.Items.Add(album);
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void fetchPosts()
        {
            listBoxPosts.Items.Clear();
            listBoxPosts.DisplayMember = "Name";
            try
            {
                if (m_User != null) 
                {
                    foreach (Post post in m_User.Posts)
                    {
                        if (post.Message != null)
                        {
                            listBoxPosts.Items.Add(post.Message);
                        }
                        else if (post.Caption != null)
                        {
                            listBoxPosts.Items.Add(post.Caption);
                        }
                        else
                        {
                            listBoxPosts.Items.Add(string.Format("[{0}]", post.Type));
                        }
                    }

                    if (listBoxPosts.Items.Count == 0)
                    {
                        MessageBox.Show("No Posts available");
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonPosts_Click(object sender, EventArgs e)
        {
            fetchPosts();
        }

        private Dictionary<User, int> getListOfMostLikedFriends()
        {
            Dictionary<User, int> userLikes = null;

            fetchPosts();

            try
            {
                if (listBoxPosts.Items.Count > 0)
                {
                    userLikes = new Dictionary<User, int>();

                    foreach (Post post in m_User.Posts)
                    {
                        foreach (User user in post.LikedBy)
                        {
                            if (userLikes.ContainsKey(user))
                            {
                                userLikes[user]++;
                            }
                            else
                            {
                                userLikes.Add(user, 1);
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
            Dictionary<User, int> userLikes = getListOfMostLikedFriends();
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

                applyFontToAllComponents(selectedFont);
            }
        }

        private void applyFontToAllComponents(Font i_ChosenFont)
        {
            foreach (Control control in Controls)
            {
                applyFontRecursively(control, i_ChosenFont);
            }

            this.Font = i_ChosenFont;
        }

        private void applyFontRecursively(Control i_Control, Font i_Font)
        {
            i_Control.Font = i_Font;

            foreach (Control childControl in i_Control.Controls)
            {
                applyFontRecursively(childControl, i_Font);
            }
        }

        private void buttonNewPost_Click(object sender, EventArgs e)
        {
            try
            {
                Status postedStatus = m_User.PostStatus(textBoxNewPost.Text);
                MessageBox.Show("Status posted successfully.\nID: " + postedStatus.Id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPhotoOfSelectedFriend();
        }

        private void showPhotoOfSelectedFriend()
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                User selectedFriend = listBoxFriends.SelectedItem as User;

                if (selectedFriend != null)
                {
                    if (selectedFriend.PictureNormalURL != null)
                    {
                        pictureBoxAlbums.LoadAsync(selectedFriend.PictureNormalURL);
                    }
                }
                else
                {
                    MessageBox.Show("Permission denied.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void buttonEvents_Click(object sender, EventArgs e)
        {
            fetchEvents();
        }

        private void fetchEvents()
        {
            listBoxEvents.Items.Clear();
            listBoxEvents.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {
                    foreach (Event @event in m_User.Events)
                    {
                        listBoxEvents.Items.Add(@event);
                    }

                    if (listBoxEvents.Items.Count == 0)
                    {
                        MessageBox.Show("No Events available", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            helpMessage();
        }

        private static void helpMessage()
        {
            string helpMessage = "Welcome to Our App - Help Guide\n\n" +
                            "Home Page:\n\n" +
                            "1. Remember Me Checkbox: Check this box if you'd like to be logged in automatically the next time you open the app. This will save you from having to enter your login credentials every time.\n" +
                            "2. Post Your Thoughts: Use the text box to write and share your thoughts. Click the \"Post\" button to publish your post online for others to see.\n" +
                            "3. Groups: Click this button to see a list of all your groups. By clicking on a group's name, you'll open the group in your browser.\n" +
                            "4. Liked Pages: Click this button to view a list of pages you've liked. By clicking on a page's name, you'll be able to see the page's picture.\n" +
                            "5. Friends: Explore your friend list by clicking this button. Click on a friend's name to see their picture.\n" +
                            "6. Albums: Discover your photo albums by clicking this button. Click on an album's name to view its picture. Additionally, there's a button to sort albums by their creation date.\n\n" +
                            "Profile Page:\n\n" +
                            "1. View Your Posts: Click this button to see a list of all your posts. This helps you keep track of your contributions and thoughts.\n" +
                            "2. Top Supporters: Find out who your most supportive friends are! This button will show a list of friends who have liked your posts the most.\n" +
                            "3. Events: Click here to see a list of upcoming events that you're a part of.\n" +
                            "4. Email Reminder: Use this feature to send yourself an email reminder. Enter a subject and click \"Send\" to receive an email in your inbox.\n\n" +
                            "We hope this guide helps you make the most of our app's features. Feel free to explore and enjoy a seamless experience!";

            MessageBox.Show(helpMessage, "Help Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string recipientEmail = "desigpatter57@gmail.com";
            string subject = $"Feedback from {m_User.Email}";
            string mailtoUri = $"mailto:{recipientEmail}?subject={Uri.EscapeDataString(subject)}";

            Process.Start(new ProcessStartInfo(mailtoUri));
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            fetchGroups();
        }

        private void fetchGroups()
        {
            listBoxGroups.Items.Clear();
            listBoxGroups.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {
                    foreach (Group group in m_User.Groups)
                    {
                        listBoxGroups.Items.Add(group);
                    }

                    if (listBoxGroups.Items.Count == 0)
                    {
                        MessageBox.Show("No groups available", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    mustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Can not get the ID of the selected group", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void linkLabelGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
