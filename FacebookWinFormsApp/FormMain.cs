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

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private LoginResult m_LoginResult;
        private User m_User;
        public FormMain(LoginResult i_loginResult, User i_user)
        {
            m_LoginResult = i_loginResult;
            m_User = i_user;
            InitializeComponent();
            pictureBoxProfile.ImageLocation = m_LoginResult.LoggedInUser.PictureNormalURL;
            buttonLogout.Enabled = true;
            FacebookService.s_CollectionLimit = 25;
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonFriends_Click(object sender, EventArgs e)
        {
            listBoxFriends.Items.Clear();
            listBoxFriends.DisplayMember = "Name";

            try
            {
                if (m_User != null)
                {
                    foreach (User friend in m_User.Friends)
                    {
                        listBoxGroups.Items.Add(friend.FirstName);
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
            if(m_User != null)
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
            listBoxGroups.Items.Clear();
            listBoxGroups.DisplayMember = "Name";

            try
            {
                if(m_User != null)
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
                pictureBoxGroups.LoadAsync(selectedGroup.PictureNormalURL);
            }
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
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
    }
}
