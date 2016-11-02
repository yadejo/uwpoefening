using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLights.UI.Model;

namespace TrafficLights.UI.Services {
    public class TrafficLightService : ITrafficLightService {

        private readonly ICollection<Cluster> _clusters;



        public TrafficLightService() {
            _clusters = new List<Cluster>();
            


            var cluster1 = new Cluster {
                ClusterId = Guid.NewGuid(),
                Location = "Ghent",
                TrafficLights = new ObservableCollection<TrafficLight>(),
                TempTrafficLights = new ObservableCollection<TemporaryTrafficLight>()
            };

            for(int i=0 ;i<4 ; i++) {
                cluster1.TrafficLights.Add(new TrafficLight {
                    ActivatedOn = DateTime.Now,
                    Placed = true,
                    Direction = Direction.East,
                    TimeGreen = 10+i,
                    TimeOrange = 10+i,
                    TimeRed = 10+i,
                    PlacedOn = DateTime.Now.AddDays(-10+i),
                    Status = TrafficLightStatus.Active,
                    TrafficLightId = Guid.NewGuid()
                });
            }

            var cluster2 = new Cluster {
                ClusterId = Guid.NewGuid(),

                Location = "Brussel",
                TrafficLights = new ObservableCollection<TrafficLight>(),
                TempTrafficLights = new ObservableCollection<TemporaryTrafficLight>()
            };

            for(int i = 0 ; i < 4 ; i++) {
                cluster1.TrafficLights.Add(new TrafficLight {
                    ActivatedOn = DateTime.Now,
                    Placed = true,
                    Direction = Direction.West,
                    TimeGreen = 10,
                    TimeOrange = 10,
                    TimeRed = 10,
                    PlacedOn = DateTime.Now.AddDays(-10+i),
                    Status = TrafficLightStatus.Active,
                    TrafficLightId = Guid.NewGuid()
                });
            }

            _clusters.Add(cluster1);
            _clusters.Add(cluster2);

        }

        public void DeleteTrafficLight( Guid trafficLightId ) {
            var cluster = _clusters.FirstOrDefault(c => c.TrafficLights.Any(t => t.TrafficLightId == trafficLightId));

            var tl = cluster.TrafficLights.FirstOrDefault(tli => tli.TrafficLightId == trafficLightId);

            cluster.TrafficLights.Remove(tl);
        }

        public IEnumerable<Cluster> GetAllClusters() {
            return _clusters.ToList();
        }

        public TrafficLight GetTrafficLightById( Guid trafficLightId ) {

            return _clusters.SelectMany(c => c.TrafficLights).FirstOrDefault(tl => tl.TrafficLightId == trafficLightId);

        }

        public TrafficLight InsertTempTrafficLight(Guid clusterId, TemporaryTrafficLight trafficLight)
        {
            var cluster = _clusters.FirstOrDefault(c => c.ClusterId == clusterId);
            cluster.TempTrafficLights.Add(trafficLight);
            return trafficLight;
        }

        public TrafficLight InsertTrafficLight(Guid clusterId,TrafficLight trafficLight)
        {
            var cluster = _clusters.FirstOrDefault(c => c.ClusterId == clusterId);
            cluster.TrafficLights.Add(trafficLight);
            return trafficLight;
        }

        public TrafficLight UpdateTrafficLight( TrafficLight updatedTrafficLight ) {

          var tlStorage=  _clusters.SelectMany(c => c.TrafficLights).FirstOrDefault(tlInDb => tlInDb.TrafficLightId == updatedTrafficLight.TrafficLightId);

            tlStorage.Direction = updatedTrafficLight.Direction;
            tlStorage.Status = updatedTrafficLight.Status;
            tlStorage.TimeGreen = updatedTrafficLight.TimeGreen;
            tlStorage.TimeOrange = updatedTrafficLight.TimeOrange;
            tlStorage.TimeRed = updatedTrafficLight.TimeRed;

            return tlStorage;
        }
    }
}
