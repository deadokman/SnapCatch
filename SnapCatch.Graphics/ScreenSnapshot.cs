using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace SnapCatch.Processing
{
    public class ScreenSnapshot
    {
        public ScreenSnapshot(Screen screen, BitmapSource imageBitmap)
        {
            ScreenItem = screen;
            BitmapImage = imageBitmap;
        }

        /// <summary>
        /// Экземпляр экрана
        /// </summary>
        public Screen ScreenItem { get; private set; }

        /// <summary>
        /// Битовое изображение снимка экрана
        /// </summary>
        public BitmapSource BitmapImage { get; private set; }
    }
}
