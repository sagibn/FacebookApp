using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Drawing;

namespace BasicFacebookFeatures.Logic
{
    public class UserProxy : IFacebookObjectProxy
    {
        private User m_User;
        private FacebookObjectCollection<Post> m_SavedPosts;
        private FacebookObjectCollection<UserProxy> m_SavedFriends;
        private FacebookObjectCollection<PageProxy> m_SavedLikedPages;
        private FacebookObjectCollection<Album> m_SavedAlbums;
        private FacebookObjectCollection<Group> m_SavedGroups;
        private FacebookObjectCollection<Event> m_SavedEvents;
        private PageProxy[] m_SavedFavoriteTeams;
        private int m_NumOfPostsFetches = -1;
        private int m_NumOfFriendsFetches = -1;
        private int m_NumOfLikedPagesFetches = -1;
        private int m_NumOfAlbumsFetches = -1;
        private int m_NumOfGroupsFetches = -1;
        private int m_NumOfEventsFetches = -1;
        private int m_NumOfFavoriteTeamsFetches = -1;

        public UserProxy(User i_User)
        {
            m_User = i_User;
            m_SavedPosts = new FacebookObjectCollection<Post>();
            m_SavedFriends = new FacebookObjectCollection<UserProxy>();
            m_SavedLikedPages = new FacebookObjectCollection<PageProxy>();
            m_SavedAlbums = new FacebookObjectCollection<Album>();
            m_SavedGroups = new FacebookObjectCollection<Group>();
            m_SavedEvents = new FacebookObjectCollection<Event>();
            m_SavedFavoriteTeams = new PageProxy[0];
        }

        public string About
        {
            get
            {
                return m_User.About;
            }
            set
            {
                m_User.About = value;
            }
        }

        public string Birthday
        {
            get
            {
                return m_User.Birthday;
            }
            set
            {
                m_User.Birthday = value;
            }
        }

        public string Religion
        {
            get
            {
                return m_User.Religion;
            }
            set
            {
                m_User.Religion = value;
            }
        }

        public string Name
        {
            get
            {
                return m_User.Name;
            }
            set
            {
                m_User.Name = value;
            }
        }

        public string FirstName
        {
            get
            {
                return m_User.FirstName;
            }
            set
            {
                m_User.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return m_User.LastName;
            }
            set
            {
                m_User.LastName = value;
            }
        }

        public User.eGender? Gender
        {
            get
            {
                return m_User.Gender;
            }
            set
            {
                m_User.Gender = value;
            }
        }

        public string Email
        {
            get
            {
                return m_User.Email;
            }
            set
            {
                m_User.Email = value;
            }
        }

        public User.eRelationshipStatus? RelationshipStatus
        {
            get
            {
                return m_User.RelationshipStatus;
            }
            set
            {
                m_User.RelationshipStatus = value;
            }
        }

        public City Location
        {
            get
            {
                return m_User.Location;
            }
            set
            {
                m_User.Location = value;
            }
        }

        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                if (++m_NumOfPostsFetches % 5 == 0)
                {
                    m_SavedPosts = m_User.Posts;
                }

                return m_SavedPosts;
            }
        }

        public FacebookObjectCollection<UserProxy> Friends
        {
            get
            {
                if(++m_NumOfFriendsFetches % 5 == 0)
                {
                    m_SavedFriends.Clear();
                    foreach (User friend in m_User.Friends)
                    {
                        m_SavedFriends.Add(new UserProxy(friend));
                    }
                }

                return m_SavedFriends;
            }
        }

        public FacebookObjectCollection<PageProxy> LikedPages
        {
            get
            {
                if (++m_NumOfLikedPagesFetches % 5 == 0)
                {
                    m_SavedLikedPages.Clear();
                    foreach(Page page in m_User.LikedPages)
                    {
                        m_SavedLikedPages.Add(new PageProxy(page));
                    }
                }

                return m_SavedLikedPages;
            }
        }

        public FacebookObjectCollection<Album> Albums
        {
            get
            {
                if (++m_NumOfAlbumsFetches % 5 == 0)
                {
                    m_SavedAlbums = m_User.Albums;
                }

                return m_SavedAlbums;
            }
        }

        public FacebookObjectCollection<Group> Groups
        {
            get
            {
                if (++m_NumOfGroupsFetches % 5 == 0)
                {
                    m_SavedGroups = m_User.Groups;
                }

                return m_SavedGroups;
            }
        }

        public FacebookObjectCollection<Event> Events
        {
            get
            {
                if (++m_NumOfEventsFetches % 5 == 0)
                {
                    m_SavedEvents = m_User.Events;
                }

                return m_SavedEvents;
            }
        }

        public PageProxy[] FavofriteTeams
        {
            get
            {
                if (++m_NumOfFavoriteTeamsFetches % 5 == 0)
                {
                    m_SavedFavoriteTeams = new PageProxy[m_User.FavofriteTeams.Length];
                    for(int i = 0; i < m_User.FavofriteTeams.Length; i++)
                    {
                        m_SavedFavoriteTeams[i] = new PageProxy(m_User.FavofriteTeams[i]);
                    }
                }

                return m_SavedFavoriteTeams;
            }
        }

        public string PictureNormalURL { get => m_User.PictureNormalURL; }

        public string PictureLargeURL { get => m_User.PictureLargeURL; }

        public string PictureSmallURL { get => m_User.PictureSmallURL; }

        public string PictureSqaureURL { get => m_User.PictureSqaureURL; }

        public Image ImageSmall { get => m_User.ImageSmall; }

        public Image ImageNormal { get => m_User.ImageNormal; }

        public Image ImageLarge { get => m_User.ImageLarge; }

        public Image ImageSquare { get => m_User.ImageSquare; }

        public Status PostStatus(string i_StatusText, string i_PaceID = null, string i_PictureURL = null, string i_TaggedFriendIDs = null, string i_Link = null, string i_PrivacyParameterValue = null)
        {
            Status status = m_User.PostStatus(i_StatusText, i_PaceID, i_PictureURL, i_TaggedFriendIDs, i_Link, i_PrivacyParameterValue);

            return status;
        }

    }
}
