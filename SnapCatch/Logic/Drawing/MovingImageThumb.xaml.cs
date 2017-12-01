using System.Windows;
using System.Windows.Media;

namespace SnapCatch.Logic.Drawing
{
    /// <summary>
    /// Interaction logic for MovingImageThumb.xaml
    /// </summary>
    public partial class MovingImageThumb : MovingThumb
    {
        public MovingImageThumb()
        {
            InitializeComponent();
            IsLocked = true;
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource),
                typeof(MovingImageThumb),
                new UIPropertyMetadata(null,
                    new PropertyChangedCallback(ImageSourceChanged)));

        private static void ImageSourceChanged(DependencyObject depObj,
            DependencyPropertyChangedEventArgs args)
        {
            var s = (MovingImageThumb)depObj;
            var value = (ImageSource)args.NewValue;
            s.Width = value.Width;
            s.Height = value.Height;
        }

        public ImageSource Source
        {
            get
            {
                return (ImageSource)GetValue(ImageSourceProperty);
            }
            set
            {
                SetValue(ImageSourceProperty, value);
                //OnPropertyChanged("Source");
            }
        }

        private static bool ValidateValueCallback(object value)
        {
            var src = value as ImageSource;
            return src != null;
        }
    }
}
