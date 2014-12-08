
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
