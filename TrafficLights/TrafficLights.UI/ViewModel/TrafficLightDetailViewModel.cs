using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;
using TrafficLights.UI.Services;

namespace TrafficLights.UI.ViewModel {
    public class TrafficLightDetailViewModel : ViewModelBase {

        #region Services
        private readonly ITrafficLightService _trafficLightService;
        private INavigationService _navigationService;
        #endregion

        #region Bindable Properties
        private TrafficLight _trafficLight;

        public TrafficLight TrafficLight {
            get { return _trafficLight; }
            set {

                Set(ref _trafficLight,value);

                if(TrafficLightStatuses != null) {
                    _trafficLight.Status = TrafficLightStatuses.FirstOrDefault(s => s.ToString() == _trafficLight.Status.ToString());
                }

                if(Directions != null) {
                    _trafficLight.Direction = Directions.FirstOrDefault(s => s.ToString() == _trafficLight.Direction.ToString());
                }
            }
        }

        private ObservableCollection<TrafficLightStatus> _trafficLightStatuses;

        public ObservableCollection<TrafficLightStatus> TrafficLightStatuses {
            get { return _trafficLightStatuses; }
            set { Set(ref _trafficLightStatuses,value); }
        }

        private ObservableCollection<Direction> _directions;

        public ObservableCollection<Direction> Directions {
            get { return _directions; }
            set { Set(ref _directions,value); }
        }

        #endregion
        #region Commands

        private RelayCommand _saveChangesCommand;

        public RelayCommand SaveChangesCommand {
            get { return _saveChangesCommand; }
            set { Set(ref _saveChangesCommand,value); }
        }


        private RelayCommand _deleteCommand;

        public RelayCommand DeleteCommand {
            get { return _deleteCommand; }
            set { Set(ref _deleteCommand,value); }
        }


        #endregion


        public TrafficLightDetailViewModel( ITrafficLightService trafficLightService, INavigationService navigationService ) {
            _trafficLightService = trafficLightService;
            _navigationService = navigationService;

            InitializeProperties();
            InitializeCommands();
        }



        private void InitializeCommands() {

            SaveChangesCommand = new RelayCommand(Delete);
            DeleteCommand = new RelayCommand(Delete);
        }

        private void Delete() {
            _trafficLightService.DeleteTrafficLight(TrafficLight.TrafficLightId);
        }

        private void InitializeProperties() {

            TrafficLightStatuses = new ObservableCollection<TrafficLightStatus>();

            //Set status enum
            var statuses = Enum.GetValues(typeof(TrafficLightStatus));
            foreach(var status in statuses) {
                TrafficLightStatuses.Add((TrafficLightStatus) status);
            }

            Directions = new ObservableCollection<Direction>();

            ////Set direction enum
            var directions = Enum.GetValues(typeof(Direction));
            foreach(var direction in directions) {
                Directions.Add((Direction) direction);
            }

            //Set TrafficLight
            TrafficLight = _trafficLightService.GetTrafficLightById(Guid.NewGuid());

        }


    }
}
