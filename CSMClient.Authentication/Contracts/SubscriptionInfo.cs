using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMClient.Authentication.Contracts
{
    internal class SubscriptionInfo
    {
        public string id { get; set; }
        public string subscriptionId { get; set; }
        public string displayName { get; set; }
        public string state { get; set; }
    }
}
