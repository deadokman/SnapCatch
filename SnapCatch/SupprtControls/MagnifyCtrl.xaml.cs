using System.Windows.Controls;
using System.Windows.Media;

namespace SnapCatch.SupprtControls
{
    /// <summary>
    /// Interaction logic for MagnifyCtrl.xaml
    /// </summary>
    public partial class MagnifyCtrl : UserControl
    {
        public MagnifyCtrl()
        {
            InitializeComponent();
        }

        public ImageSource ImageSource
        {
            set
            {
                magnifyImg.Source = value;
            }
        }
    }
}
