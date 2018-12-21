using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Gldd.AdissParser
{
    public class Point2DValueConverter : IValueConverter
    {
        private Point2D cacheValue;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null)
            {
                return null;
            }
            else
            {
                Point2D point2D = ((Point2D)value);
                cacheValue = point2D;
                return $"{point2D.X}, {point2D.Y}";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string str = (string)value;
                string[] split = str.Split(',');
                return new Point2D(int.Parse(split[0]), int.Parse(split[1]));
            }
            catch
            {
                return cacheValue;
            }
        }
    }
}
