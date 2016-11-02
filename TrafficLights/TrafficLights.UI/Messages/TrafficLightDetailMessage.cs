using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.Messages
{
    public class TrafficLightDetailMessage
    {
        public Guid TrafficLightId { get; set; }

        public TrafficLightDetailMessage(Guid trafficLightId)
        {
            TrafficLightId = trafficLightId;
        }
    }
}
