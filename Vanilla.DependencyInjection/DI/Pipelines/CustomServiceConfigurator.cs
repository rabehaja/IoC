using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Vanilla.DependencyInjection.Default.Resolvers;
using Vanilla.DependencyInjection.Unity.Sample;

namespace Vanilla.DependencyInjection.Unity.DI.Pipelines
{
    /// <summary>
    /// Register services the way sitecore does i.e. using the servicecollection
    /// </summary>
    public class CustomServiceConfigurator : Sitecore.DependencyInjection.IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            // Register the addition implementation in the service collection
            serviceCollection.AddTransient<ICalculator, Addition>();
        }
    }
}