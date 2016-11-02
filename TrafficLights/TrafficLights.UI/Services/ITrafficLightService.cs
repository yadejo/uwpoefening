using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;

namespace TrafficLights.UI.Services {
   public  interface ITrafficLightService {

        TrafficLight GetTrafficLightById( Guid trafficLightId );

        TrafficLight UpdateTrafficLight( TrafficLight trafficLight );

        void DeleteTrafficLight( Guid trafficLightId );

        TrafficLight InsertTrafficLight(Guid clusterId,TrafficLight trafficLight);

        IEnumerable<Cluster> GetAllClusters();

    }
}
