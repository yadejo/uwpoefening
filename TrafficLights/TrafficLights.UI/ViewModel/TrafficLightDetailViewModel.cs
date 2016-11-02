using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        #endregion

        #region Bindable Properties
        private TrafficLight _trafficLight;

        public TrafficLight TrafficLight {
            get { return _trafficLight; }
            set {

                Set(ref _trafficLight,value);

                //_trafficLight.Status = TrafficLightStatuses.FirstOrDefault(s => s.ToString() == _trafficLight.Status.ToString());
                //_trafficLight.Direction = Directions.FirstOrDefault(s => s.ToString() == _trafficLight.Direction.ToString());
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


        #endregion


        public TrafficLightDetailViewModel( ITrafficLightService trafficLightService ) {
            _trafficLightService = trafficLightService;

            InitializeProperties();
            InitializeCommands();
        }



        private void InitializeCommands() {

            SaveChangesCommand = new RelayCommand(SaveChanges);

        }

        private void SaveChanges() {
            _trafficLightService.UpdateTrafficLight(TrafficLight);
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

            this.TrafficLight = _trafficLightService.GetTrafficLightById(Guid.NewGuid());

        }


    }
}
