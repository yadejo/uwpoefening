﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Messages;
using TrafficLights.UI.Model;
using TrafficLights.UI.Services;

namespace TrafficLights.UI.ViewModel
{
    public class TempTrafficLightCreateVM : ViewModelBase
    {
        private readonly ITrafficLightService _trafficLightService;
        private Guid _clusterId;
        public TempTrafficLightCreateVM(ITrafficLightService trafficLightService)
        {
            _trafficLightService = trafficLightService;

            _newTrafficLight = new TemporaryTrafficLight();
            _directions = new Dictionary<Direction, string>();
            foreach (var d in Enum.GetValues(typeof(Direction)))
            {
                _directions.Add((Direction)d, Enum.GetName(typeof(Direction), d));
            }

            _statuses = new Dictionary<TrafficLightStatus, string>();
            foreach (var d in Enum.GetValues(typeof(TrafficLightStatus)))
            {
                _statuses.Add((TrafficLightStatus)d, Enum.GetName(typeof(TrafficLightStatus), d));
            }

            _addButtonClickCommand = new GalaSoft.MvvmLight.Command.RelayCommand(AddTrafficLight);

            MessengerInstance.Register<ClusterGuidMessage>(this, (msg) =>
            {
                this._clusterId = msg.ClusterId;
            });
        }

        private void AddTrafficLight()
        {
            if (_newTrafficLight.Placed) _newTrafficLight.PlacedOn = DateTimeOffset.Now;
            _trafficLightService.InsertTempTrafficLight(this._clusterId, _newTrafficLight);
        }

        private TemporaryTrafficLight _newTrafficLight;
        public TemporaryTrafficLight NewTrafficLight
        {
            get { return _newTrafficLight; }
            set { Set(ref _newTrafficLight, value); }
        }

        private Dictionary<Direction, string> _directions;

        public Dictionary<Direction, string> Directions
        {
            get
            {
                return _directions;
            }
        }

        private Dictionary<TrafficLightStatus, string> _statuses;

        public Dictionary<TrafficLightStatus, string> Statuses
        {
            get { return _statuses; }

        }

        private GalaSoft.MvvmLight.Command.RelayCommand _addButtonClickCommand;

        public GalaSoft.MvvmLight.Command.RelayCommand AddButtonClickCommand
        {
            get { return _addButtonClickCommand; }

        }

    }
}
