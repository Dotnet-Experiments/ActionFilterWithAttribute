using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomActionFilterAttribute
{
    public class FeatureToggleFilter : IAsyncActionFilter
    {
        private readonly IFeatureManager _featureManager;

        public FeatureToggleFilter(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // look for FeatureGateAttribute on the action
            var controllerActionDescriptor =
                context.ActionDescriptor as ControllerActionDescriptor;
            var featureGateAttributes = controllerActionDescriptor?.MethodInfo
                .GetCustomAttributes(typeof(FeatureGateAttribute), inherit : true) as FeatureGateAttribute[];
            if (featureGateAttributes?.Length > 0)
            {
                var featureName = featureGateAttributes[0].FeatureToggleName;
                if (!await _featureManager.IsEnabled(featureName))
                {
                    throw new NotImplementedException(
                        $"Feature {featureName} is disabled in this environment.");
                }
            }

            // move on to the next entry in the pipeline if we haven't explicitly exited above
            await next();
        }
    }
}