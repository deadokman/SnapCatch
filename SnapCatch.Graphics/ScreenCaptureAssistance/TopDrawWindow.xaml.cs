using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using SnapCatch.Processing;

namespace SnapCatch.Graphics.ScreenCaptureAssistance
{
    /// <summary>
    /// Interaction logic for TopDrawWindow.xaml
    /// </summary>
    public partial class TopDrawWindow : Window
    {
        private ScreenSnapshot _screenSnapshot;

        private Point _startDragLoc;

        private Rect _currentRectangle;

        public event SnapSelectedDelegate ScreenAreaCaptured;

        #region Константы

        private const int MagnifyWidth= 50;

        private const int MagnifyHalfWidth = MagnifyWidth / 2;

        #endregion

        public delegate void SnapSelectedDelegate(ImageSource screenSnapshot);


        public TopDrawWindow(ScreenSnapshot screenSnap)
        {
            InitializeComponent();
            _screenSnapshot = screenSnap;
            this.Cursor = Cursors.Cross;
            MagnifyCtrl.Visibility = Visibility.Hidden;
            this.MouseRightButtonDown += OnMouseRightButtonDown;
            this.MouseRightButtonUp += OnMouseRightButtonUp;
            InternalImage.Source = _screenSnapshot.BitmapImage;
            SquareAreaSelect.Visibility = Visibility.Hidden;
            SquareAreaSelect.ImageRectangle = _screenSnapshot.BitmapImage;
            _currentRectangle = new Rect();
            //Обработка перетаскивания рами окна для выбора области скриншота
            DrawCanvas.MouseDown += DrawCanvasOnMouseDown;
            DrawCanvas.MouseUp += DrawCanvasOnMouseUp;
        }

        /// <summary>
        /// Закончено выделение области на канвасах 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawCanvasOnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                SquareAreaSelect.Visibility = Visibility.Collapsed;
                if (ScreenAreaCaptured != null)
                {
                    var display = ImgProc.CropImageSource(_screenSnapshot.BitmapImage, _currentRectangle);
                    display.Freeze();
                    ScreenAreaCaptured.Invoke(display);
                }
            }
        }

        /// <summary>
        /// Реакция на рачало выделения области
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawCanvasOnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //throw new NotImplementedException();
                var mousePos = e.GetPosition(this);
                _startDragLoc = mousePos;
                SquareAreaSelect.Visibility = Visibility.Visible;
            }
        }

        private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            MagnifyCtrl.Visibility = Visibility.Hidden;
        }

        private void OnMouseRightButtonDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            Mouse.Capture(this);
            MagnifyCtrl.Visibility = Visibility.Visible;
        }

        private void UpdateMagnifyCtrl(Point pos)
        {
            var yCoord = pos.Y >= MagnifyHalfWidth ? pos.Y - MagnifyHalfWidth : pos.Y - (MagnifyHalfWidth - (MagnifyHalfWidth - pos.Y));
            var xCoord = pos.X >= MagnifyHalfWidth ? pos.X - MagnifyHalfWidth : pos.X - (MagnifyHalfWidth - (MagnifyHalfWidth - pos.X));
            var rect = new Int32Rect((int)xCoord, (int)yCoord, MagnifyWidth, MagnifyWidth);
            MagnifyCtrl.ImageSource = ImgProc.CropImageSource(_screenSnapshot.BitmapImage, rect, 10);
        }

        private void UpdateRectangleLocation(Point pos)
        {
            var w = pos.X - _startDragLoc.X;
            var h = pos.Y - _startDragLoc.Y;

            if (w < 0)
            {
                _currentRectangle.X = pos.X;
                _currentRectangle.Width = Math.Abs(w);
            }
            else
            {
                _currentRectangle.X = _startDragLoc.X;
                _currentRectangle.Width = w;
            }

            if (h < 0)
            {
                _currentRectangle.Y = pos.Y;
                _currentRectangle.Height = Math.Abs(h);
            }
            else
            {
                _currentRectangle.Y = _startDragLoc.Y;
                _currentRectangle.Height = h;
            }

            SquareAreaSelect.DisplayRect = _currentRectangle;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var pos = e.GetPosition(this);
            if (MagnifyCtrl.Visibility == Visibility.Visible)
            {
                UpdateMagnifyCtrl(pos);
            }

            if (SquareAreaSelect.Visibility == Visibility.Visible)
            {
                UpdateRectangleLocation(pos);
            }

            base.OnMouseMove(e);
        }
    }
}
