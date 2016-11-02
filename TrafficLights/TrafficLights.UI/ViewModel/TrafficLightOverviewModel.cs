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

namespace TrafficLights.UI.ViewModel {


    public class TrafficLightOverviewModel : ViewModelBase {
        private ICommand _addTrafficLightToCluster;
        public ICommand AddTrafficLightToCluster
        {
            get { return _addTrafficLightToCluster ?? (_addTrafficLightToCluster = new RelayCommand(AddTrafficLightWithCluster)); }
        }

        private ICommand _addTrafficLight;
        public ICommand AddTrafficLight
        {
            get { return _addTrafficLight ?? (_addTrafficLight = new RelayCommand(AddNewTrafficLight)); }
        }

        private ObservableCollection<Cluster> _clusters;

        public ObservableCollection<Cluster> Clusters{
            get { return _clusters; }
            set { Set(ref _clusters, value); }
        }
        public TrafficLightOverviewModel() {
            Clusters = new ObservableCollection<Cluster>();
            List<TrafficLight> newtrafficLights = new List<TrafficLight>();
            newtrafficLights.Add(new TrafficLight { TrafficLightId=Guid.NewGuid(), ActivatedOn = DateTime.Now, Direction = Direction.East, Placed = true, PlacedOn = DateTime.Now, Status = TrafficLightStatus.Active, TimeGreen = 25, TimeOrange = 5, TimeRed = 25 });
            newtrafficLights.Add(new TrafficLight { TrafficLightId=Guid.NewGuid(), ActivatedOn = DateTime.Now, Direction = Direction.East, Placed = true, PlacedOn = DateTime.Now, Status = TrafficLightStatus.Active, TimeGreen = 25, TimeOrange = 5, TimeRed = 25 });
            Clusters.Add(new Cluster { ClusterId = Guid.NewGuid(), Location = "Test", TrafficLights = new ObservableCollection<TrafficLight>(newtrafficLights) });
        }

        public void AddTrafficLightWithCluster() {
            TrafficLightCreatePage createTL = new TrafficLightCreatePage();
            
            //Traf newProject = new AddProject();
            //newProject.Show();
        }
        public void AddNewTrafficLight()
        {

        }
    }
}
