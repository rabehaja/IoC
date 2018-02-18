using System.Web.Mvc;
using Sitecore.Pipelines;
using Unity;
using Vanilla.DependencyInjection.Unity.Sample;

namespace Vanilla.DependencyInjection.Unity.DI.Pipelines
{
    /// <summary>
    /// Register my services in unity and consume it when I need a another type of the same interface.
    /// </summary>
    public class ConfigureUnity
    {
        public void Process(PipelineArgs args)
        {
            var unity = DependencyResolver.Current.GetService<IUnityContainer>();

            //register the multiplication in unity with a specific name so I can use both Addition and multiplication
            unity.RegisterType<ICalculator, Multiplication>("Multiplication");
        }
    }
}