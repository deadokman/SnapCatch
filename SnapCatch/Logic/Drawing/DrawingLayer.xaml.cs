using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using SnapCatch.Annotations;

namespace SnapCatch.Logic.Drawing
{
    /// <summary>
    /// Interaction logic for DrawingLayer.xaml
    /// </summary>
    public partial class DrawingLayer : UserControl, INotifyPropertyChanged
    {
        public DrawingLayer()
        {
            InitializeComponent();
        }

        public void AddItem(MovingThumb canvasItem)
        {
            CanvasDisplay.Children.Add(canvasItem);
        }

        /// <summary>
        /// Left side offset inside canvas
        /// </summary>
        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set
            {
                    Canvas.SetLeft(this, value);
                    OnPropertyChanged();
            }
        }

        /// <summary>
        /// Top offset inside canvas
        /// </summary>
        public double Top
        {
            get { return Canvas.GetTop(this); }
            set
            {
                    Canvas.SetTop(this, value);
                    OnPropertyChanged();
            }
        }

        public int ZIndex
        {
            get { return Panel.GetZIndex(this); }
            set
            {
                Panel.SetZIndex(this, value);
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
