﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using CSMClient.Authentication.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSMClient.Authentication.TenantStorage
{
    class FileTenantStorage : ITenantStorage
    {
        public void SaveCache(Dictionary<string, TenantCacheInfo> tenants)
        {
            var file = GetCacheFile();
            var json = JObject.FromObject(tenants);
            File.WriteAllText(file, json.ToString());
        }

        public Dictionary<string, TenantCacheInfo> GetCache()
        {
            var file = GetCacheFile();
            if (!File.Exists(file))
            {
                return new Dictionary<string, TenantCacheInfo>();
            }

            return JsonConvert.DeserializeObject<Dictionary<string, TenantCacheInfo>>(File.ReadAllText(file));
        }

        public bool IsCacheValid()
        {
            var cache = GetCache();
            return cache != null && cache.Count > 0;
        }

        public void ClearCache()
        {
            var filePath = GetCacheFile();
            if (File.Exists(filePath))
            {
                Trace.WriteLine(string.Format("Deleting {0} ... ", filePath));
                File.Delete(filePath);
                Trace.WriteLine("Done!");
            }
        }

        private static string GetCacheFile()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".csm");
            Directory.CreateDirectory(path);
            return Path.Combine(path, "cache_tenants.json");
        }
    }
}
