using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.Model {
    public class TemporaryTrafficLight : TrafficLight {

        private string _reason;

        public string Reason {
            get { return _reason; }
            set { Set(ref _reason , value); }
        }

        private DateTimeOffset _endDate;

        public DateTimeOffset EndDate {
            get { return _endDate; }
            set { Set(ref _endDate,value); }
        }

        private bool _isExtended;

        public bool IsExtended {
            get { return _isExtended; }
            set { Set(ref _isExtended,value); }
        }

        private string _extensionReason;

        public string ExtensionReason {
            get { return _extensionReason; }
            set { Set(ref _extensionReason,value); }
        }





    }
}
