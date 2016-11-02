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

        Maintenance CreateMaintenance(Maintenance maintenance );
        Cluster CreateCluster(Cluster cluster);

        IEnumerable<Maintenance> GetMaintenancesByTrafficLightId( Guid trafficLightId );

        void DeleteTrafficLight( Guid trafficLightId );

        TrafficLight InsertTrafficLight(Guid clusterId,TrafficLight trafficLight);

        TrafficLight InsertTempTrafficLight(Guid clusterId, TemporaryTrafficLight trafficLight);

        IEnumerable<Cluster> GetAllClusters();

    }
}
