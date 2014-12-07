using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
