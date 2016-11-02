using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace TrafficLights.UI.Converters {
    public class DecimalToStringConverter : IValueConverter {
        public object Convert( object value,Type targetType,object parameter,string language ) {

            try {
                var dec = (decimal) value;

                return dec.ToString();
            }
            catch(Exception) {

                return 0;
            }
        }

        public object ConvertBack( object value,Type targetType,object parameter,string language ) {

            string s = (string) value;

            try {
                var dec = decimal.Parse(s);
                return dec;
            }

            catch(Exception) {

                return 0;
            }





        }
    }
}
