using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CSMClient.Authentication.Contracts;
using CSMClient.Authentication.EnvironmentStorage;
using CSMClient.Authentication.TenantStorage;
using CSMClient.Authentication.TokenStorage;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace CSMClient.Authentication.AAD
{
    public class PersistentAuthHelper : BaseAuthHelper, IAuthHelper
    {
        public PersistentAuthHelper(AzureEnvironments azureEnvironment = AzureEnvironments.Null)
            : base(azureEnvironment, new FileTokenStorage(), new FileTenantStorage(), new FileEnvironmentStorage())
        {

        }
    }
}
