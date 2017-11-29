using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SnapCatch.Processing.SupprtControls
{
    /// <summary>
    /// Interaction logic for SquareAreaSelectCtrl.xaml
    /// </summary>
    public partial class SquareAreaSelectCtrl : UserControl
    {
        public SquareAreaSelectCtrl()
        {
            InitializeComponent();
        }

        public ImageSource ImageRectangle { set { this.ImageRect.Source = value; } }

        public Rect DisplayRect
        {
            set
            {
                this.VisualGeometry.Rect = value;
                this.ViewPort.Viewport = value;
                BorderRect.Width = value.Width;
                BorderRect.Height = value.Height;
                Canvas.SetLeft(BorderRect, value.X);
                Canvas.SetTop(BorderRect, value.Y);
            }
        }
    }
}
