using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;

namespace TrafficLights.UI.Services {
    public class TrafficLightService : ITrafficLightService {

        public TrafficLightService() {
                
        }

        public TrafficLight GetTrafficLightById( Guid trafficLightId ) {
            return new TrafficLight {
                ActivatedOn = DateTime.Now,
                Placed = true,
                Direction = Direction.East,
                TimeGreen = 10,
                TimeOrange = 10,
                TimeRed = 10,
                PlacedOn = DateTime.Now.AddDays(-10),
                Status = TrafficLightStatus.Active,
                TrafficLightId = Guid.NewGuid()
            };

        }

        public TrafficLight UpdateTrafficLight( TrafficLight trafficLight ) {
            return trafficLight;
        }
    }
}
