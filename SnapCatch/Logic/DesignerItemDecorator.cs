﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using SnapCatch.Logic.Adorners;

namespace SnapCatch.Logic
{
    public class DesignerItemDecorator : Control
    {
        private Adorner adorner;

        public bool ShowDecorator
        {
            get { return (bool)GetValue(ShowDecoratorProperty); }
            set { SetValue(ShowDecoratorProperty, value); }
        }

        public static readonly DependencyProperty ShowDecoratorProperty =
            DependencyProperty.Register("ShowDecorator", typeof(bool), typeof(DesignerItemDecorator),
                new FrameworkPropertyMetadata(false, ShowDecoratorProperty_Changed));

        public DesignerItemDecorator()
        {
            Unloaded += DesignerItemDecorator_Unloaded;
        }

        private void HideAdorner()
        {
            if (adorner != null)
            {
                adorner.Visibility = Visibility.Hidden;
            }
        }

        private void ShowAdorner()
        {
            if (adorner == null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);

                if (adornerLayer != null)
                {
                    ContentControl designerItem = DataContext as ContentControl;
                    Canvas canvas = VisualTreeHelper.GetParent(designerItem) as Canvas;
                    adorner = new ResizeRotateAdorner(designerItem);
                    adornerLayer.Add(adorner);

                    if (ShowDecorator)
                    {
                        adorner.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        adorner.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                adorner.Visibility = Visibility.Visible;
            }
        }

        private void DesignerItemDecorator_Unloaded(object sender, RoutedEventArgs e)
        {
            if (adorner != null)
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
                if (adornerLayer != null)
                {
                    adornerLayer.Remove(adorner);
                }

                adorner = null;
            }
        }

        private static void ShowDecoratorProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DesignerItemDecorator decorator = (DesignerItemDecorator)d;
            bool showDecorator = (bool)e.NewValue;

            if (showDecorator)
            {
                decorator.ShowAdorner();
            }
            else
            {
                decorator.HideAdorner();
            }
        }
    }
}
