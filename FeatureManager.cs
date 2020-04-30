using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CustomActionFilterAttribute
{
    public interface IFeatureManager
    {
        Task<bool> IsEnabled(string featureName);
    }

    public class FeatureManager : IFeatureManager
    {
        private readonly IConfiguration _config;

        public FeatureManager(IConfiguration config)
        {
            _config = config;
        }

        public Task<bool> IsEnabled(string featureName)
        {
            var featureToggleValueStr = _config[$"FeatureToggles:{featureName}"];
            var conversionSuccessful = bool.TryParse(featureToggleValueStr, out var featureToggleValue);
            return Task.FromResult(conversionSuccessful && featureToggleValue);
        }
    }
}