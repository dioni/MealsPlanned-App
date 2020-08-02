using System;
using System.Globalization;
using Xamarin.Forms;

namespace MealsPlanned_App.Helpers
{
    class NonNullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
