﻿using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.View;

namespace TrafficLights.UI.Services
{
    public static class NavigatorService
    {

        public static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Create", typeof(TrafficLightCreatePage));
            navigationService.Configure("Overview", typeof(TrafficLightOverviewPage));
            navigationService.Configure("Detail", typeof(TrafficLightDetailPage));
            //navigationService.Configure("CreateCluster", typeof(CreateClusterPage));
            //navigationService.Configure()
            return navigationService;
        }
    }
}