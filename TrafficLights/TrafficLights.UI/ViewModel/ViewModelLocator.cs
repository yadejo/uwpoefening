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

            SimpleIoc.Default.Register<MainViewModel>();
         //    SimpleIoc.Default.Register<InventoryViewModel>();
        }

        public MainViewModel MainViewModel {
            get {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }

}
