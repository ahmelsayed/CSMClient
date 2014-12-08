using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace CSMClient.Authentication
{
    public interface IAuthHelper
    {
        Task AcquireTokens();
        Task<AuthenticationResult> GetTokenByTenant(string tenantId);
        Task<AuthenticationResult> GetTokenBySubscription(string subscriptionId);
        AuthenticationResult GetTokenBySpn(string tenantId, string appId, string appKey, AzureEnvironments env);
        Task<AuthenticationResult> GetRecentToken();
        bool IsCacheValid();
        void SetEnvironment(AzureEnvironments azureEnvironment);
        void ClearTokenCache();
        IEnumerable<string> DumpTokenCache();
    }
}
