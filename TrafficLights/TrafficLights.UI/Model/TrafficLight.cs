using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.Model {
   public class TrafficLight :ObservableObject {

        private Guid _trafficLightId;

        public Guid TrafficLightId {
            get { return _trafficLightId; }
            set { Set(ref _trafficLightId,value); }
        }


        private DateTimeOffset _placedOn;

        public DateTimeOffset PlacedOn {
            get { return _placedOn; }
            set { Set(ref _placedOn , value); }
        }

        private TrafficLightStatus _status;

        public TrafficLightStatus Status {
            get { return _status; }
            set { Set(ref _status,value); }
        }

        private bool _placed;

        public bool Placed {
            get { return _placed; }
            set { Set(ref _placed,value); }
        }


        private int _timeGreen;

        public int TimeGreen {
            get { return _timeGreen; }
            set { Set(ref _timeGreen,value); }
        }

        private int _timeRed;

        public int TimeRed {
            get { return _timeRed; }
            set { Set(ref _timeRed,value); }
        }


        private int _timeOrange;

        public int TimeOrange {
            get { return _timeOrange; }
            set { Set(ref _timeOrange,value); }
        }

        private DateTimeOffset _activatedOn;

        public DateTimeOffset ActivatedOn {
            get { return _activatedOn; }
            set { Set(ref _activatedOn,value); }
        }


        private Direction _direction;

        public Direction Direction {
            get { return _direction; }
            set { Set(ref _direction,value); }
        }

    }

    public enum TrafficLightStatus {

        Active,Inactive,Defect
    }
}
