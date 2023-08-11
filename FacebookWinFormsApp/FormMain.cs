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
            this.Size = m_Settings.LastWindowSize;
            InitializeComponent();
            this.checkBoxRememberMe.Checked = m_Settings.RememberUser;
        }

        private void completeUIFromFacebookData()
        {
            buttonLogout.Enabled = true;
            FacebookService.s_CollectionLimit = 25;
            this.Text = $"Connected as { m_User.Name}";
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
            fetchAlbums();
            fetchFriends();
            fetchGroups();
            fetchPersonalData();
        }

        private void fetchPersonalData()
        {
            string personalData = string.Format(@"About myself:
Name: {0}
Birthday: {1}
Gender: {2}
City: {3}
Email: {4}", m_User.Name, m_User.Birthday, m_User.Gender, m_User.Hometown, m_User.Email);

            labelData.Text = personalData;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //Thread serverCallsThread = new Thread(completeUIFromFacebookData);

            //serverCallsThread.Start();
            completeUIFromFacebookData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            m_Settings.RememberUser = checkBoxRememberMe.Checked;
            m_Settings.UserAccessToken = checkBoxRememberMe.Checked == true ? m_LoginResult.AccessToken : null;
            m_Settings.LastWindowSize = this.Size;
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
            sendEmail();
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
            showPhotoOfSelectedGroup();
        }

        private void showPhotoOfSelectedGroup()
        {
            if (listBoxGroups.SelectedItems.Count == 1)
            {
                Group selectedGroup = listBoxGroups.SelectedItem as Group;
                pictureBoxGroups.LoadAsync(selectedGroup.PictureNormalURL);
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
    }
}
