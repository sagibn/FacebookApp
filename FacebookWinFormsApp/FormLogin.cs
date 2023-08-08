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
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns");
            login();
            
        }

        private void login()
        {
            LoginResult loginResult = FacebookService.Login(
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

            if (loginResult.AccessToken != null && string.IsNullOrEmpty(loginResult.ErrorMessage))
            {
                User user = loginResult.LoggedInUser;
                FormMain form = new FormMain(loginResult, user);

                //this.Hide();
                form.ShowDialog();
            }
        }
    }
}
