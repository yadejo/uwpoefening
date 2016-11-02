using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.Model {
    public class Maintenance :ObservableObject{

        private Guid _maintenanceId;

        public Guid MaintenanceId {
            get { return _maintenanceId; }
            set { Set(ref _maintenanceId,value); }
        }

        private Guid _trafficLightId;

        public Guid TrafficLightId {
            get { return _trafficLightId; }
            set { Set(ref _trafficLightId ,value); }
        }

        private string _reason;

        public string Reason {
            get { return _reason; }
            set { Set(ref _reason,value); }
        }

        private string _description;

        public string Description {
            get { return _description; }
            set { Set(ref _description,value); }
        }


        private decimal _price;

        public decimal Price {
            get { return _price; }
            set { Set(ref _price,value); }
        }


        private DateTimeOffset _date;

        public DateTimeOffset Date {
            get { return _date; }
            set { Set(ref _date,value); }
        }



    }
}
