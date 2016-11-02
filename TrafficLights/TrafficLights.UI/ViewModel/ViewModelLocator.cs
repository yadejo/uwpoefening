using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Services;
using TrafficLights.UI.View;

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
            var navigationService = this.CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            SimpleIoc.Default.Register<TrafficLightOverviewModel>();

            SimpleIoc.Default.Register<TrafficLightDetailViewModel>();
            SimpleIoc.Default.Register<TrafficLightCreateVM>();
            SimpleIoc.Default.Register<MaintenanceCreateViewModel>();

         
            SimpleIoc.Default.Register<TrafficLightDetailViewModel>();
            SimpleIoc.Default.Register<TrafficLightCreateVM>();
            SimpleIoc.Default.Register<TempTrafficLightCreateVM>();

        }

        public MaintenanceCreateViewModel MaintenanceCreateViewModel {
            get {
                return ServiceLocator.Current.GetInstance<MaintenanceCreateViewModel>();
            }
        }


        public TrafficLightOverviewModel TrafficLightOverviewViewModel {
            get {
                return ServiceLocator.Current.GetInstance<TrafficLightOverviewModel>();
            }
        }

        public TrafficLightCreateVM TrafficLightVM {
            get
            {
                return ServiceLocator.Current.GetInstance<TrafficLightCreateVM>();
            }
        }

        public TempTrafficLightCreateVM TempTrafficLightCreateVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TempTrafficLightCreateVM>();
            }
        }

        public TrafficLightDetailViewModel TrafficLightDetailViewModel {
            get {
                return ServiceLocator.Current.GetInstance<TrafficLightDetailViewModel>();
            }
        }
        private INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Create", typeof(TrafficLightCreatePage));
            navigationService.Configure("Overview", typeof(TrafficLightOverviewPage));
            navigationService.Configure("Detail", typeof(TrafficLightDetailPage));
            return navigationService;
        }
        public static void Cleanup() {
            // TODO Clear the ViewModels
        }
    }

}
