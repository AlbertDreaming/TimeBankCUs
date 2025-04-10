using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace TimeBankCU.Converters
{
    public class TabToColorConverter : IValueConverter
    {
        public Color SelectedColor { get; set; } = Colors.LightBlue;
        public Color UnselectedColor { get; set; } = Colors.LightGray;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string selectedTab && parameter is string tab)
                return selectedTab == tab ? SelectedColor : UnselectedColor;

            return UnselectedColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}