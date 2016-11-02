using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLights.UI.Messages
{
    public class ClusterGuidMessage
    {
        public Guid ClusterId { get; set; }

        public ClusterGuidMessage(Guid clusterId)
        {
            this.ClusterId = clusterId;
        }
    }
}
