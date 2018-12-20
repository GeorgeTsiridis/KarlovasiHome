using System;
using System.Globalization;
using Xamarin.Forms;

namespace KarlovasiHome.Converters
{
    public class IsAvailableToBorderColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isAvailable = (bool) value;

            return !isAvailable ? Color.Red : Color.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}