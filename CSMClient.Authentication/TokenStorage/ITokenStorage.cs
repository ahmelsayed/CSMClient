using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace CSMClient.Authentication.TokenStorage
{
    public interface ITokenStorage
    {
        Dictionary<TokenCacheKey, string> GetCache();
        bool TryGetRecentToken(out AuthenticationResult recentToken);
        void SaveCache(Dictionary<TokenCacheKey, string> tokens);
        void SaveRecentToken(AuthenticationResult authResult);
        bool IsCacheValid();
        void ClearCache();
    }
}
