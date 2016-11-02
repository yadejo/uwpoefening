using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.Model {
    public class Cluster : ObservableObject {

        private Guid _clusterId;

        public Guid ClusterId {
            get { return _clusterId; }
            set { Set(ref _clusterId,value); }
        }

        private string _location;

        public string Location {
            get { return _location; }
            set { Set(ref _location,value); }
        }


        private ObservableCollection<TrafficLight> _trafficLights;

        public ObservableCollection<TrafficLight> TrafficLights {
            get { return _trafficLights; }
            set { Set(ref _trafficLights,value); }
        }







    }
}
