using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HotelReservation.Presentation.Wpf
{
    public class TabToBrushConverter : IValueConverter
    {
        public Brush ActiveBrush { get; set; } = Brushes.LightBlue;
        public Brush InactiveBrush { get; set; } = Brushes.Transparent;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedTab = value?.ToString();
            string buttonTab = parameter?.ToString();
            return selectedTab == buttonTab ? ActiveBrush : InactiveBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}