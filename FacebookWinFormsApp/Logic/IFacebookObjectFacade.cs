using System.Drawing;

namespace BasicFacebookFeatures.Logic
{
    internal interface IFacebookObjectFacade
    {
        string PictureNormalURL { get; }
        string PictureLargeURL { get; }
        string PictureSmallURL { get; }
        string PictureSqaureURL { get; }
        Image ImageSmall { get; }
        Image ImageNormal { get; }
        Image ImageLarge { get; }
        Image ImageSquare { get; }
    }
}