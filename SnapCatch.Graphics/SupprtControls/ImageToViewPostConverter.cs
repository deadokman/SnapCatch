using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace SnapCatch.Processing.SupprtControls
{
    public class ImageToViewPostConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isrc = value as ImageSource;
            if (isrc != null)
            { 
                return new Rect(0,0, isrc.Width, isrc.Height);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
