using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Vanilla.DependencyInjection.Unity.DI.Unity;
using Vanilla.DependencyInjection.Unity.Tests.Implementations;
using Vanilla.DependencyInjection.Unity.Tests.Interfaces;
using ICalculator = Vanilla.DependencyInjection.Unity.Tests.Interfaces.ICalculator;

namespace Vanilla.DependencyInjection.Unity.Tests.Extensions
{
    [TestClass]
    public class UnityFallBackExtensionTests
    {
        private IServiceProvider _serviceProvider;
        private IUnityContainer _container;


        [TestInitialize]
        public void Setup()
        {
            Tests.Init.ServiceCollection.AddTransient<ICalculator, Multiplication>();
           
            _serviceProvider = Init.ServiceCollection.BuildServiceProvider();
            _container = new UnityContainer();
            _container.AddExtension(new UnityFallbackProviderExtension(_serviceProvider));


        }

        [TestMethod]
        public void UnityFallBackExtension_WithDefaultProvider_ShouldReturnMultiplicationEquals100()
        {
            var calculator = _container.Resolve<ICalculator>();

            var response = calculator.Calculate(10, 10);

            Assert.AreEqual(response, 100);
        }

        [TestMethod]
        public void UnityFallBackExtension_WithUnity_RegisterSameInterface_ShouldReturnAdditionEquals20()
        {

            _container.RegisterType<ICalculator, Addition>();
            var calculator = _container.Resolve<ICalculator>();

            var response = calculator.Calculate(10, 10);

            Assert.AreEqual(response, 20);
           
        }

        [TestMethod]
        public void UnityFallBackExtension_WithDefaultProvider_WhenUnityContainsSomething_ResolveServiceFromFallback_ReturnMultiplicationEquals100()
        {
            _container.RegisterType<IDummyInterface, DummyImplementation>();

            var calculator = _container.Resolve<ICalculator>();

            var response = calculator.Calculate(10, 10);

            Assert.AreEqual(response, 100);
        }
    }
}
