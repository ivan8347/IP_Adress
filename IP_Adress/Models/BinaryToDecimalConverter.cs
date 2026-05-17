using System;
using System.Globalization;
using System.Windows.Data;

namespace IP_Adress
{
    public class BinaryToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "";

            string bits = value.ToString().Replace(" ", "");

            if (bits.Length != 8)
                return "";

            try
            {
                int dec = System.Convert.ToInt32(bits, 2);
                return dec.ToString();
            }
            catch
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
