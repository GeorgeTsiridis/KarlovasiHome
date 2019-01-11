using System;
using System.Globalization;
using Xamarin.Forms;

namespace KarlovasiHome.Converters
{
    public class IndicatorToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? 0.7 : 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}