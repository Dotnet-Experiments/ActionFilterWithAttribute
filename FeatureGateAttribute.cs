using System;

namespace CustomActionFilterAttribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class FeatureGateAttribute : Attribute
    {
        public string FeatureToggleName { get; private set; }
        public FeatureGateAttribute(string featureToggleName)
        {
            FeatureToggleName = featureToggleName;
        }
    }
}