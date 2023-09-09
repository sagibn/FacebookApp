using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using BasicFacebookFeatures.Logic;

namespace BasicFacebookFeatures
{
    public static class FormHelper
    {
        public static void FetchFacebookItem<T>(ListBox i_ListBox, FacebookObjectCollection<T> i_Collection)
        {
            i_ListBox.Invoke(new Action(() => i_ListBox.Items.Clear()));
            i_ListBox.Invoke(new Action(() => i_ListBox.DisplayMember = "Name"));

            try
            {
                if (i_Collection != null)
                {
                    foreach (T item in i_Collection)
                    {
                        i_ListBox.Invoke(new Action(() => i_ListBox.Items.Add(item)));
                    }

                    if (i_ListBox.Items.Count == 0)
                    {
                        MessageBox.Show($"No items available", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MustLoginMessage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public static void MustLoginMessage()
        {
            MessageBox.Show("Must login to use this feature", "Error", MessageBoxButtons.OK);
        }

        public static void FetchPersonalData(UserProxy i_User, Control i_Control)
        {
            int? age = null;
            int? nextBirthday = null;
            string zodiacSign = string.Empty;
            try
            {
                BirthdayAdapter birthday = new BirthdayAdapter(i_User.Birthday);
                age = birthday.Age();
                nextBirthday = birthday.NextBirthdayInDays();
                zodiacSign = birthday.GetZodiacSign();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            string personalData = string.Format(@"About myself:
Name: {0}
Birthday: {1}
Age: {2}
Next birthday in: {3} days 
Gender: {4}
Email: {5}
Relationship: {6}
My location: {7}
Zodiac sign: {8}", i_User.Name, i_User.Birthday, age, nextBirthday, i_User.Gender,
                    i_User.Email, i_User.RelationshipStatus, i_User.Location.Name, zodiacSign);

            i_Control.Text = personalData;
        }

        public static void ShowPhotoOfSelectedItem(ListBox i_ListBox, PictureBox i_PictureBox)
        {
            if (i_ListBox.SelectedItems.Count == 1)
            {
                OwnerObject selectedObj = i_ListBox.SelectedItem as OwnerObject;

                if (selectedObj != null)
                {
                    i_PictureBox.LoadAsync(selectedObj.PictureNormalURL);
                }

                IFacebookObjectProxy selectedFacade = i_ListBox.SelectedItem as IFacebookObjectProxy;

                if (selectedFacade != null)
                {
                    i_PictureBox.LoadAsync(selectedFacade.PictureNormalURL);
                }

            }
        }

        public static void HelpMessage()
        {
            string helpMessage = "Welcome to Our App - Help Guide\n\n" +
                            "Home Page:\n\n" +
                            "1. Remember Me Checkbox: Check this box if you'd like to be logged in automatically the next time you open the app. This will save you from having to enter your login credentials every time.\n" +
                            "2. Post Your Thoughts: Use the text box to write and share your thoughts. Click the \"Post\" button to publish your post online for others to see.\n" +
                            "4. Liked Pages: Click this button to view a list of pages you've liked. By clicking on a page's name, you'll be able to see the page's picture.\n" +
                            "5. Friends: Explore your friend list by clicking this button. Click on a friend's name to see their picture.\n" +
                            "6. Albums: Discover your photo albums by clicking this button. Click on an album's name to view its data. Additionally, there's an option to edit some of the data.\n\n" +
                            "Profile Page:\n\n" +
                            "1. View Your Posts: Click this button to see a list of all your posts. This helps you keep track of your contributions and thoughts.\n" +
                            "2. Top Supporters: Find out who your most supportive friends are! This button will show a list of friends who have liked your posts the most.\n" +
                            "3. Groups: Click this button to see a list of all your groups. Click on an group's name to view its data.\n" +
                            "4. Email Reminder: Use this feature to send yourself an email reminder. Enter a subject and click \"Send\" to receive an email in your inbox.\n\n" +
                            "We hope this guide helps you make the most of our app's features. Feel free to explore and enjoy a seamless experience!";

            MessageBox.Show(helpMessage, "Help Guide", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
