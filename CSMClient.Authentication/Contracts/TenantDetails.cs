using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMClient.Authentication.Contracts
{
    internal class TenantDetails
    {
        public string objectId { get; set; }
        public string displayName { get; set; }
        public VerifiedDomain[] verifiedDomains { get; set; }
    }
}
