using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Tableware.Services
{
    public class BackgroundConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            Brush grayBrush = (Brush)(new BrushConverter().ConvertFrom("#D3D3D3")!);
            Brush greenBrush = (Brush)(new BrushConverter().ConvertFrom("#258C51")!);
            return (int)value == 0 ? grayBrush: greenBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
