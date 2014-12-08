using CSMClient.Authentication.EnvironmentStorage;
using CSMClient.Authentication.TenantStorage;
using CSMClient.Authentication.TokenStorage;

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
