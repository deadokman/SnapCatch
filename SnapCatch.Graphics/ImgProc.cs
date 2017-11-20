using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Size = System.Drawing.Size;

namespace SnapCatch.Processing
{
    public class ImgProc
    {
        public static ImageSource CropImageSource(BitmapSource img, Int32Rect rect, double scale = 1)
        {
            rect.Width = 1;
            rect.Height = 1;
            var cropped = new CroppedBitmap(img, rect);
            var tb = new TransformedBitmap(cropped, new ScaleTransform(scale, scale, rect.Width/2, rect.Height/2));
            return tb;
        }

        public static ImageSource CropImageSource(BitmapSource img, Rect rect, double scale = 1)
        {
            return CropImageSource(img, new Int32Rect((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height), scale);
        }
    }
}
