using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;
using TrafficLights.UI.Services;

namespace TrafficLights.UI.ViewModel {
    public class MaintenanceCreateViewModel : ViewModelBase {

        private Maintenance _maintenance;

        public Maintenance Maintenance {
            get { return _maintenance; }
            set { Set(ref _maintenance,value); }
        }
        private readonly ITrafficLightService _trafficLightService;

        public MaintenanceCreateViewModel( ITrafficLightService trafficLightService ) {

            _trafficLightService = trafficLightService;
            InitializeProperties();
            InitializeCommands();
        }

        private void InitializeCommands() {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save() {
            _trafficLightService.CreateMaintenance(Maintenance);
            InitializeProperties();

            //@TODO navigate away
        }

        private void InitializeProperties() {
            Maintenance = new Maintenance {
                Date = DateTime.Now
            };
        }

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand {
            get { return _saveCommand; }
            set { Set(ref _saveCommand,value); }
        }

    }
}
