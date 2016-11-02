using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace TrafficLights.UI.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var status = (TrafficLightStatus)value;

            switch(status) {
                case TrafficLightStatus.Active:
                    return new SolidColorBrush(Colors.Green);
                case TrafficLightStatus.Inactive:
                    return new SolidColorBrush(Colors.Gray);
                case TrafficLightStatus.Defect:
                    return new SolidColorBrush(Colors.Red);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
