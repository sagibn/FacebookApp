using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormLogin : Form
    {
        private LoginResult m_LoginResult;
        private User m_User;
        public FormLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Settings settings = Settings.Instance;

            if (settings.RememberUser && !string.IsNullOrEmpty(settings.UserAccessToken))
            {
                try
                {
                    m_LoginResult = FacebookService.Connect(settings.UserAccessToken);
                    activateMainForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}.\nPlease login manually.", "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            login();
        }

        private void login()
        {
            m_LoginResult = FacebookService.Login(
                "855104489457424",
                /// requested permissions:
                "email",
                "public_profile",
                "user_age_range",
                "user_birthday",
                "user_events",
                "user_friends",
                "user_gender",
                "user_hometown",
                "user_likes",
                "user_link",
                "user_location",
                "user_photos",
                "user_posts",
                "user_videos");

            activateMainForm();
        }

        private void activateMainForm()
        {
            if (m_LoginResult.AccessToken != null && string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_User = m_LoginResult.LoggedInUser;
                FormMain form = new FormMain(m_LoginResult, m_User);

                //this.Hide();
                form.ShowDialog();
            }
        }
    }
}
