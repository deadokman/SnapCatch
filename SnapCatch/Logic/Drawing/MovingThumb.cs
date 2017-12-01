using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using SnapCatch.Annotations;

namespace SnapCatch.Logic.Drawing
{
    public class MovingThumb : Thumb, INotifyPropertyChanged
    {
        public bool IsLocked { get; set; }

        /// <summary>
        /// Left side offset inside canvas
        /// </summary>
        public double Left
        {
            get { return Canvas.GetLeft(this); }
            set
            {
                if (!IsLocked)
                {
                    Canvas.SetLeft(this, value);
                    OnPropertyChanged();
                }
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
                if (!IsLocked)
                {
                    Canvas.SetTop(this, value);
                    OnPropertyChanged();
                }
            }
        }

        public MovingThumb()
        {
            DragDelta += OnDragDelta;
            DragStarted += OnDragStarted;
            DragCompleted += OnDragCompleted;
        }

        private void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {

        }

        private void OnDragStarted(object sender, DragStartedEventArgs e)
        {

        }

        /// <summary>
        /// Вызывается при перетаскивании элемента
        /// </summary>
        /// <param name="verticalChange"></param>
        /// <param name="horizontalChange"></param>
        public virtual void DragChanged(double verticalChange, double horizontalChange)
        {
            var newLeft = Left + horizontalChange;
            var newTop = Top + verticalChange;
            Left = newLeft;
            Top = newTop;
        }

        private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            DragChanged(e.VerticalChange, e.HorizontalChange);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
