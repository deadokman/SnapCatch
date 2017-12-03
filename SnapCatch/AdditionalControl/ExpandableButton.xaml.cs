using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using MahApps.Metro.SimpleChildWindow.Utils;

namespace SnapCatch.AdditionalControl
{
    /// <summary>
    /// Interaction logic for ExpandableButton.xaml
    /// </summary>
    public partial class ExpandableButton : UserControl
    {
        private DoubleAnimation _widthExpandAnimation;
        private DoubleAnimation _widthCollapseAnimation;

   
        private double _expandWidth = 0;
        private double _initialWidth = 0;

        public UIElement InternalUiElement;


        public ExpandableButton()
        {
            InitializeComponent();
            Panel.SetZIndex(this, 9999);
            _expandWidth = this.ActualWidth;
            _widthExpandAnimation = new DoubleAnimation()
            {
                From = ActualWidth,
                To = 200,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 250)),
                EasingFunction = new ExponentialEase() { }
            };

            _widthCollapseAnimation = new DoubleAnimation()
            {
                From = 200,
                To = ActualWidth,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 250)),
                EasingFunction = new ExponentialEase() { }
            };

            //Вычислить реальную ширину контейнера
       
        }

        /// <summary>
        /// Expand control
        /// </summary>
        public void InvokeExpand()
        {
            if (_expandWidth == 0)
            {
                _initialWidth = this.ActualWidth;
                foreach (var depObj in InternalUiElement.GetChildObjects())
                {
                    var uiEl = depObj as Control;
                    if (uiEl != null)
                    {
                        _expandWidth += uiEl.Width;
                    }
                }

                _widthExpandAnimation.To = _expandWidth > _widthExpandAnimation.From ? _expandWidth : _initialWidth;
                _widthExpandAnimation.From = _initialWidth;
            }

            BeginAnimation(WidthProperty, _widthExpandAnimation);
        }

        public void InvokeCollapse()
        {
            if (_widthCollapseAnimation.From != _expandWidth)
            {
                _widthCollapseAnimation.From = _expandWidth;
                _widthCollapseAnimation.To = _initialWidth;
            }

            BeginAnimation(WidthProperty, _widthCollapseAnimation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Expanded = !Expanded;
        }

        /// <summary>
        /// Control expanded dependency property
        /// </summary>
        public static readonly DependencyProperty ExpandedProperty = DependencyProperty.Register(
            "Expanded", typeof(bool), typeof(ExpandableButton), new PropertyMetadata(default(bool)));

        public bool Expanded
        {
            get { return (bool) GetValue(ExpandedProperty); }
            set
            {
                SetValue(ExpandedProperty, value);
                if (value)
                {
                    InvokeExpand();
                }
                else
                {
                    InvokeCollapse();
                }
            }
        }

        /// <summary>
        /// Control internal content
        /// </summary>
        public static readonly DependencyProperty AdditionalContentProperty =
            DependencyProperty.Register("AdditionalContent", typeof(object), typeof(ExpandableButton),
              new PropertyMetadata(null, PropertyContentChanged));

        /// <summary>
        /// Gets or sets additional content for the UserControl
        /// </summary>
        public object AdditionalContent
        {
            get { return (object)GetValue(AdditionalContentProperty); }
            set
            {
                SetValue(AdditionalContentProperty, value);
            }
        }

        private static void PropertyContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var exBtn = (ExpandableButton)d;
            exBtn.InternalUiElement = (UIElement)e.NewValue;
        }
    }
}
