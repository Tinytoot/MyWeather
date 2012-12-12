using System;


namespace MyWeather.Converters
{
    public class StringVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                bool Value = (bool)value;

                if (parameter != null)
                {
                    if (parameter > 0)
                        return Value ? Visibility.Collapsed : Visibility.Visible;
                }
                else
                    return Value ? Visibility.Visible : Visibility.Collapsed;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}