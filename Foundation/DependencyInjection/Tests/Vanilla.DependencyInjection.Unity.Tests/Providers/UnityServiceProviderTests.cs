using System;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Vanilla.DependencyInjection.Unity.DI.Provider;
using Vanilla.DependencyInjection.Unity.Sample;
using Addition = Vanilla.DependencyInjection.Unity.Tests.Implementations.Addition;
using ICalculator = Vanilla.DependencyInjection.Unity.Tests.Interfaces.ICalculator;
using Multiplication = Vanilla.DependencyInjection.Unity.Tests.Implementations.Multiplication;

namespace Vanilla.DependencyInjection.Unity.Tests.Providers
{
    [TestClass]
    public class UnityServiceProviderTests
    {
        [TestInitialize]
        public void Init()
        {
            RegisterServiceUsingServiceCollection(Tests.Init.ServiceCollection);
            var unityServiceProvider = new UnityServiceProviderBuilder();
            unityServiceProvider.SetServiceCollection(Tests.Init.ServiceCollection);
            Tests.Init.ServiceProvider = unityServiceProvider.BuildProvider();

        }

        private void RegisterServiceUsingServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICalculator, Addition>();
        }

        private void RegisterServiceUsingUnity()
        {
            var unity = DependencyResolver.Current.GetService<IUnityContainer>();
            unity.RegisterType<ICalculator, Multiplication>("Multiplication");
        }

        [TestMethod]
        public void ServiceProvider_OnProviderBuilt_UnityContainerNotNull()
        {
            var unity = DependencyResolver.Current.GetService<IUnityContainer>();
            Assert.IsNotNull(unity);
        }

        [TestMethod]
        public void ServiceProvider_OnProviderBuilt_ReturnsAdditionAsServiceType()
        {
            var implementation = DependencyResolver.Current.GetService<ICalculator>();

            Assert.AreEqual(implementation.GetType(), typeof(Addition));

        }

        [TestMethod]
        public void ServiceProvider_OnRegisteredService_CalculateSum()
        {
            var calculation = DependencyResolver.Current.GetService<ICalculator>();

            var result = calculation.Calculate(10, 10);

            Assert.AreEqual(result, 20);
        }


    }
}
