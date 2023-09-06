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
    public class PageFacade : IFacebookObjectFacade
    {
        private Page m_Page;

        public PageFacade(Page i_Page)
        {
            m_Page = i_Page;
        }

        public string Description { get => m_Page.Description; }

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
