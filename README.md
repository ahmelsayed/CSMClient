CSMClient
=========

CSMClient facilitates getting token and CSM resource access.  The simplest use case is to acquire token `CSMClient.exe login` and http GET CSM resource such as `CSMClient.exe get https://management.azure.com/subscriptions?api-version=2014-04-01`

Check out [wiki](https://github.com/suwatch/CSMClient/wiki) for more details.

    Login and get tokens
        CSMClient.exe login ([Prod|Current|Dogfood|Next])
    
    Call CSM api
        CSMClient.exe [get|post|put|delete] [url] ([user])
    
    Copy token to clipboard
        CSMClient.exe token [tenant] ([user])
    
    List token cache
        CSMClient.exe listcache ([Prod|Current|Dogfood|Next])
    
    Clear token cache
        CSMClient.exe clearcache ([Prod|Current|Dogfood|Next])

Note: The tokens are cached at `%USERPROFILE%\.csm` folder.  


CSMClient.Authentication
========================

There are 2 main objects, `AAD.PersistentAuthHelper` and `AAD.AuthHelper`. They both use AAD for authentication. However, the `PersistentAuthHelper` keeps a cache under `%UserProfile%\.csm` for the credentials so you don't have to enter them everytime. `AuthHelper` on the other hand, keeps its cache in memory.


CSMClient.Core.DynamicClient
============================

DynamicClient is a library that facilitates getting tokens and doing CSM operations. The client is used through [Dynamic Typing in .NET](http://msdn.microsoft.com/en-us/library/dd264736.aspx)

[Example](https://github.com/ahmelsayed/CSMClient/tree/master/CSMClient.Core.Runner/Program.cs)
=========

```C#
private static void Main(string[] args)
{
    var csmClient = DynamicClient.GetDynamicClient(apiVersion: "2014-04-01", authHelper: new PersistentAuthHelper(AzureEnvironments.Prod));

    var sitesResponse = (HttpResponseMessage) csmClient.Subscriptions["{subscriptionId}"].ResourceGroups["{resourceGroupName}"].Providers["Microsoft.Web"].Sites.Get();

    if (sitesResponse.IsSuccessStatusCode)
    {
        var sites = sitesResponse.Content.ReadAsAsync<JArray>().Result;

        Func<object, bool> p = s => s.ToString().Equals("West US", StringComparison.OrdinalIgnoreCase);

        foreach (var site in sites.Where(t => p(t["location"])))
        {
            Console.WriteLine(site);
        }
    }
    else
    {
        Console.WriteLine(sitesResponse.Content.ReadAsStringAsync().Result);
    }
}
```

The make up of the call is similar to the way CSM Urls are constructed. For example if the Url looks like this
`https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{webSiteName}/slots/{slotName}/config/web`

then the `DynamicCsmClient` will be `.Subscriptions["{subscriptionId}"].ResourceGroups["{resourceGroupName}"].Providers["Microsoft.Web"].Sites["{webSiteName}"].Slots["{slotName}"].Config["web"]`

Note: Capitalization is optional `.Subscriptions[""]` == `.subscription[""]` also the distinction between `[]` and `.` is also optional  `.Config["web"]` == `.Config.Web`.
However, some names like subscription Ids which are usually GUIDs are not valid C# identifiers so you will have to use the indexer notation.

