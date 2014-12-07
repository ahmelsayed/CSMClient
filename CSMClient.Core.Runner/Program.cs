using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMClient.Authentication;
using CSMClient.Authentication.AAD;
using Newtonsoft.Json.Linq;

namespace CSMClient.Core.Runner
{
    class Program
    {
        private static void Main(string[] args)
        {
            dynamic csmClient = new DynamicClient(apiVersion: "2014-04-01", authHelper: new PersistentAuthHelper(AzureEnvironments.Prod));
            var sites = (JArray) csmClient.Subscriptions["{subscriptionId}"].ResourceGroups["{resourceGroupName}"].Providers["Microsoft.Web"].Sites.Get();

            Func<object, bool> p = s => s.ToString().Equals("West US", StringComparison.OrdinalIgnoreCase);

            foreach (var site in sites.Where(t => p(t["location"])))
            {
                Console.WriteLine(site);
            }
        }
    }
}
