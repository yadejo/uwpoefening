using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrafficLights.UI.Model;
using TrafficLights.UI.Services;

namespace TrafficLights.UI.ViewModel
{
    public class ClusterCreateViewModel: ViewModelBase {
        private Cluster _cluster;
        private ICommand _addCluster;
        public ICommand AddCluster
        {
            get { return _addCluster ?? (_addCluster = new RelayCommand(() => AddNewCluster())); }
        }

        private void AddNewCluster()
        {
            Cluster.ClusterId = Guid.NewGuid();
            Cluster.TempTrafficLights = new System.Collections.ObjectModel.ObservableCollection<TemporaryTrafficLight>();
            Cluster.TrafficLights = new System.Collections.ObjectModel.ObservableCollection<TrafficLight>();
            _trafficLightService.CreateCluster(Cluster);
            _navigationService.NavigateTo("Overview");
        }

        public Cluster Cluster
        {
            get { return _cluster; }
            set { Set(ref _cluster, value); }
        }
        private readonly ITrafficLightService _trafficLightService;

        private readonly INavigationService _navigationService;
        public ClusterCreateViewModel(ITrafficLightService trafficLightService, INavigationService navigationService)
        {
            _trafficLightService = trafficLightService;
            _navigationService = navigationService;
            Cluster = new Cluster();
        }


        

    }
}
