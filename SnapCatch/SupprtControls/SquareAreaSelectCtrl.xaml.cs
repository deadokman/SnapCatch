using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnapCatch.SupprtControls
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
