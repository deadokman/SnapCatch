using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MahApps.Metro.Controls;
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
                _initialWidth = ActualWidth;
                foreach (var item in ListBoxTarget.Items)
                {
                    ListBoxItem container = ListBoxTarget.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                    if (container != null)
                    {
                        _expandWidth += container.ActualWidth;
                    }
                }

                _widthExpandAnimation.To = _expandWidth > _widthExpandAnimation.From ? _expandWidth + 5 : _initialWidth;
                _widthExpandAnimation.From = _initialWidth;
                _widthExpandAnimation.Freeze();
            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                BeginAnimation(WidthProperty, _widthExpandAnimation);
            }));


        }

        public void InvokeCollapse()
        {
            if (_widthCollapseAnimation.From != _expandWidth)
            {
                _widthCollapseAnimation.From = _expandWidth;
                _widthCollapseAnimation.To = _initialWidth;
                _widthCollapseAnimation.Freeze();
            }

            BeginAnimation(WidthProperty, _widthCollapseAnimation);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Expanded = !Expanded;
        }

        #region Button expand width

        public static readonly DependencyProperty ExpandButtonWidthProperty = DependencyProperty.Register(
            "ExpandButtonWidth", typeof(double), typeof(ExpandableButton), new PropertyMetadata((double)5));

        public double ExpandButtonWidth
        {
            get { return (double) GetValue(ExpandButtonWidthProperty); }
            set { SetValue(ExpandButtonWidthProperty, value); }
        }

        #endregion

        #region ItemTemplate property

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(ExpandableButton), new UIPropertyMetadata(null));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        #endregion

        #region Items Property

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", typeof(IEnumerable<object>), typeof(ExpandableButton), 
            new PropertyMetadata(default(IEnumerable<object>), PropertyChangedCallback));

        private static void PropertyChangedCallback(DependencyObject dobj, DependencyPropertyChangedEventArgs dp)
        {

            
        }

        public IEnumerable<object> Items
        {
            get { return (IEnumerable<object>) GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        #endregion

        #region Expanded property

        /// <summary>
        /// Control expanded dependency property
        /// </summary>
        public static readonly DependencyProperty ExpandedProperty = DependencyProperty.Register(
            "Expanded", typeof(bool), typeof(ExpandableButton), new PropertyMetadata(default(bool)));

        public bool Expanded
        {
            get { return (bool)GetValue(ExpandedProperty); }
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

        #endregion

        #region AdditionalContent Property

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

        #endregion

        private void ExpandableButton_OnMouseEnter(object sender, MouseEventArgs e)
        {
            Expanded = true;
        }

        private void ExpandableButton_OnMouseLeave(object sender, MouseEventArgs e)
        {
            Expanded = false;
        }
    }
}
