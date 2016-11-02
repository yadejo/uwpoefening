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

using TrafficLights.UI.View;

using TrafficLights.UI.Services;
using GalaSoft.MvvmLight.Views;
using TrafficLights.UI.Messages;

namespace TrafficLights.UI.ViewModel {


    public class TrafficLightOverviewModel : ViewModelBase {
        private ICommand _addTrafficLightToCluster;
        public ICommand AddTrafficLightToCluster {
            get { return _addTrafficLightToCluster ?? ( _addTrafficLightToCluster = new RelayCommand<Guid>((id) => AddTrafficLightWithCluster(id)) ); }
        }


        private ICommand _addCluster;

        public ICommand AddCluster {
           
            get { return _addCluster ?? ( _addCluster = new RelayCommand(() => AddNewCluster())); }
        }


        private ICommand _goToDetailView;

        public ICommand GoToDetailView
        {
            get { return _goToDetailView ?? (_goToDetailView = new RelayCommand<Guid>((id) => NavigateToDetail(id))); }
        }

        private void NavigateToDetail(Guid id)
        {
            //MessengerInstance.Send<TrafficLightDetailMessage>(new TrafficLightDetailMessage(id));
            _navigationService.NavigateTo("Detail");
        }

        private ObservableCollection<Cluster> _clusters;

        public ObservableCollection<Cluster> Clusters {
            get { return _clusters; }
            set { Set(ref _clusters,value); }
        }
        private readonly ITrafficLightService _trafficService;
        private INavigationService _navigationService;
        public TrafficLightOverviewModel( ITrafficLightService trafficService, INavigationService navigationService ) {

            _trafficService = trafficService;
            _navigationService = navigationService;

            InitializeProperties();

        }

        private void InitializeProperties() {
            Clusters = new ObservableCollection<Cluster>(_trafficService.GetAllClusters());

        }

        public void AddTrafficLightWithCluster(Guid clusterId) {
            MessengerInstance.Send<ClusterGuidMessage>(new ClusterGuidMessage(clusterId));
            _navigationService.NavigateTo("Create");
            
        }
        public void AddNewCluster() {
            _navigationService.NavigateTo("CreateCluster");
        }
    }
}
