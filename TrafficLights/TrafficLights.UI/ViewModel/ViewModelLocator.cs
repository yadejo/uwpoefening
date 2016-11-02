using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Services;

namespace TrafficLights.UI.ViewModel {
    public class ViewModelLocator {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator() {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if(ViewModelBase.IsInDesignModeStatic) {
                // Create design time view services and models
                //SimpleIoc.Default.Register<IDataService,DesignDataService>();

            }
            else {
                // Create run time view services and models
                //SimpleIoc.Default.Register<IDataService,DataService>();

                SimpleIoc.Default.Register<ITrafficLightService,TrafficLightService>();
            }

<<<<<<< HEAD
            SimpleIoc.Default.Register<TrafficLightOverviewModel>();
         //    SimpleIoc.Default.Register<InventoryViewModel>();
=======
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TrafficLightDetailViewModel>();
>>>>>>> 0320773dad64142fa3c3560cafa280ba019024b5
        }

        public TrafficLightOverviewModel TrafficLightOverviewViewModel {
            get {
                return ServiceLocator.Current.GetInstance<TrafficLightOverviewModel>();
            }
        }

        public TrafficLightDetailViewModel TrafficLightDetailViewModel {
            get {
                return ServiceLocator.Current.GetInstance<TrafficLightDetailViewModel>();
            }
        }

        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }

}
