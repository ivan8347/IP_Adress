using System;
using System.Globalization;
using System.Windows.Data;

namespace IP_Adress
{
    public class NetworkBitsMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return "";

            string bits = values[0]?.ToString() ?? "";
            if (!int.TryParse(values[1]?.ToString(), out int networkBits))
                return bits;

            // Возвращаем обычную строку (WPF это любит)
            return bits;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
