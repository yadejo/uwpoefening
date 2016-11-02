using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;

namespace TrafficLights.UI.ViewModel {
    public class MaintenanceCreateViewModel : ViewModelBase {

        private Maintenance _maintenance;

        public Maintenance Maintenance {
            get { return _maintenance; }
            set { Set(ref _maintenance,value); }
        }


        public MaintenanceCreateViewModel() {
            InitializeProperties();
        }

        private void InitializeProperties() {
            Maintenance = new Maintenance();
        }

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand {
            get { return _saveCommand; }
            set { Set(ref _saveCommand,value); }
        }

    }
}
