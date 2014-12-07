using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMClient.Authentication.EnvironmentStorage
{
    public interface IEnvironmentStorage
    {
        void SaveEnvironment(AzureEnvironments azureEnvironment);
        AzureEnvironments GetSavedEnvironment();
        bool IsCacheValid();
        void ClearSavedEnvironment();
    }
}
