using System.Collections.Generic;
using CSMClient.Authentication.Contracts;

namespace CSMClient.Authentication.TenantStorage
{
    public interface ITenantStorage
    {
        void SaveCache(Dictionary<string, TenantCacheInfo> tenants);
        Dictionary<string, TenantCacheInfo> GetCache();
        bool IsCacheValid();
        void ClearCache();
    }
}
