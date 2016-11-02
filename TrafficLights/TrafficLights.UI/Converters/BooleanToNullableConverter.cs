using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace TrafficLights.UI.Converters {
    public class BooleanToNullableConverter : IValueConverter {
        public object Convert( object value,Type targetType,object parameter,string language ) {


            var boo = (bool) value;

            return new Nullable<bool>(boo);


        }

        public object ConvertBack( object value,Type targetType,object parameter,string language ) {
            var x = (Nullable<bool>)value;

            if (x == null || x == false) return false;

            return true;
        }
    }
}
