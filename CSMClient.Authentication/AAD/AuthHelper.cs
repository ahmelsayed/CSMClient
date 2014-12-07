using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMClient.Authentication.EnvironmentStorage;
using CSMClient.Authentication.TenantStorage;
using CSMClient.Authentication.TokenStorage;

namespace CSMClient.Authentication.AAD
{
    public class AuthHelper: BaseAuthHelper, IAuthHelper
    {
        public AuthHelper(AzureEnvironments azureEnvironment = AzureEnvironments.Null)
            : base(azureEnvironment, new MemoryTokenStorage(), new MemoryTenantStorage(), new MemoryEnvironmentStorage()
                )
        {

        }
    }
}
