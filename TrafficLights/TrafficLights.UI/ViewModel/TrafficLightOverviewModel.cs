using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficLights.UI.Model;
using TrafficLights.UI.Services;

namespace TrafficLights.UI.ViewModel {


    public class TrafficLightOverviewModel : ViewModelBase {
        private ICommand _addTrafficLightToCluster;
        public ICommand AddTrafficLightToCluster {
            get { return _addTrafficLightToCluster ?? ( _addTrafficLightToCluster = new RelayCommand(AddTrafficLightWithCluster) ); }
        }

        private ICommand _addTrafficLight;
        public ICommand AddTrafficLight {
            get { return _addTrafficLight ?? ( _addTrafficLight = new RelayCommand(AddNewTrafficLight) ); }
        }

        private ObservableCollection<Cluster> _clusters;

        public ObservableCollection<Cluster> Clusters {
            get { return _clusters; }
            set { Set(ref _clusters,value); }
        }

        private readonly ITrafficLightService _trafficService;
        public TrafficLightOverviewModel( ITrafficLightService trafficService ) {

            _trafficService = trafficService;

            InitializeProperties();

        }

        private void InitializeProperties() {
            Clusters = new ObservableCollection<Cluster>(_trafficService.GetAllClusters());
        }

        public void AddTrafficLightWithCluster() {

        }
        public void AddNewTrafficLight() {

        }
    }
}
