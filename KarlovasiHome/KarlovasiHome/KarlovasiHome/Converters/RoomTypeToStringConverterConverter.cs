using System;
using System.Globalization;
using KarlovasiHome.Models;
using Xamarin.Forms;

namespace KarlovasiHome.Converters
{
    public class RoomTypeToStringConverterConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((RoomType) value)
            {
                case RoomType.Single:
                    return "Γκαρσονιέρα";
                case RoomType.Dual:
                    return "Διάρι";
                case RoomType.Triple:
                    return "Τριάρι";
                default:
                    return "Άλλο";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}