using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using SnapCatch.Annotations;

namespace SnapCatch.Logic
{
    /// <summary>
    /// Controlls ViewPort scale and converts ViewPort coordinates to Image coordinates
    /// </summary>
    public class ViewportManager : INotifyPropertyChanged
    {
        private double _sliderValue;
        private double _layoutScaleTransformValue;
        private double _imageCenterX;
        private double _imageCenterY;
        private double _workAreaWidth;
        private double _workAreaHeight;
        private double _verticalScrollOffset;
        private double _horizontalScrollOffset;

        public ViewportManager()
        {
            _sliderValue = 0;
            _workAreaWidth = 300;
            _workAreaHeight = 300;
            _imageCenterX = 0;
            _imageCenterY = 0;
            _sliderValue = 0;
            _layoutScaleTransformValue = 1;
        }


        /// <summary>
        /// Slider value of scale factor
        /// </summary>
        public double SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                LayoutScaleTransformValue = TranslateScale(value);
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Scale transform for canvas layer
        /// </summary>
        public double LayoutScaleTransformValue
        {
            get { return _layoutScaleTransformValue; }
            set
            {
                _layoutScaleTransformValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Center of image X coordinate
        /// </summary>
        public double ImageCenterX
        {
            get { return _imageCenterX; }
            set
            {
                _imageCenterX = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Center of image X coordinate
        /// </summary>
        public double ImageCenterY
        {
            get { return _imageCenterY; }
            set
            {
                _imageCenterY = value; 
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Work area width, initially sets to first loaded image
        /// </summary>
        public double WorkAreaWidth
        {
            get { return _workAreaWidth; }
            set
            {
                _workAreaWidth = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Work area height, initially sets to first loaded image
        /// </summary>
        public double WorkAreaHeight
        {
            get { return _workAreaHeight; }
            set
            {
                _workAreaHeight = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Update view port controller when image changed
        /// </summary>
        /// <param name="image"></param>
        public void ImageChanged(ImageSource image)
        {
            WorkAreaWidth = image.Width;
            WorkAreaHeight = image.Height;
            ImageCenterX = image.Width / 2;
            ImageCenterY = image.Height / 2;
        }

        /// <summary>
        /// ViewPort horizontall scroll offset
        /// </summary>
        public double HorizontalScrollOffset
        {
            get { return _horizontalScrollOffset; }
            set
            {
                _horizontalScrollOffset = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ViwerPort vertical scroll ofset
        /// </summary>
        public double VerticalScrollOffset
        {
            get { return _verticalScrollOffset; }
            set
            {
                _verticalScrollOffset = value;
                OnPropertyChanged();
            }
        }

        private double TranslateScale(double val)
        {
            return 1 + val / 10;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
