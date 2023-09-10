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
    public class PageProxy : IFacebookObjectProxy
    {
        private Page m_Page;
        private FacebookObjectCollection<Checkin> m_SavedCheckins;
        private FacebookObjectCollection<Post> m_SavedPosts;
        private int m_NumOfCheckinsFetches = -1;
        private int m_NumOfPostsFetches = -1;

        public PageProxy(Page i_Page)
        {
            m_Page = i_Page;
            m_SavedCheckins = new FacebookObjectCollection<Checkin>();
            m_SavedPosts = new FacebookObjectCollection<Post>();
        }

        public FacebookObjectCollection<Checkin> Checkins
        {
            get
            {
                if (++m_NumOfCheckinsFetches % 5 == 0)
                {
                    m_SavedCheckins = m_Page.Checkins;
                }

                return m_SavedCheckins;
            }
        }

        public FacebookObjectCollection<Post> Posts
        {
            get
            {
                if (++m_NumOfPostsFetches % 5 == 0)
                {
                    m_SavedPosts = m_Page.Posts;
                }

                return m_SavedPosts;
            }
        }

        public string Description { get => m_Page.Description; }

        public string Id { get => m_Page.Id; }

        public bool? IsCommunityPage { get => m_Page.IsCommunityPage; }

        public bool? IsPublished { get => m_Page.IsPublished; }

        public long? CheckinsCount { get => m_Page.CheckinsCount; }

        public string Name { get => m_Page.Name; }

        public string AccessToken { get => m_Page.AccessToken; }

        public string Category { get => m_Page.Category; }

        public string URL { get => m_Page.URL; }

        public long? LikesCount { get => m_Page.LikesCount; }

        public Location Location { get => m_Page.Location; }

        public string PictureNormalURL { get => m_Page.PictureNormalURL; }

        public string PictureLargeURL { get => m_Page.PictureLargeURL; }

        public string PictureSmallURL { get => m_Page.PictureSmallURL; }

        public string PictureSqaureURL { get => m_Page.PictureSqaureURL; }

        public Image ImageSmall { get => m_Page.ImageSmall; }

        public Image ImageNormal { get => m_Page.ImageNormal; }

        public Image ImageLarge { get => m_Page.ImageLarge; }

        public Image ImageSquare { get => m_Page.ImageSquare; }
    }
}
