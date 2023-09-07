using System.Drawing;

namespace BasicFacebookFeatures.Logic
{
    internal interface IFacebookObjectProxy
    {
        string PictureNormalURL { get; }
        string PictureLargeURL { get; }
        string PictureSmallURL { get; }
        string PictureSqaureURL { get; }
        string Name { get; }
        Image ImageSmall { get; }
        Image ImageNormal { get; }
        Image ImageLarge { get; }
        Image ImageSquare { get; }
    }
}