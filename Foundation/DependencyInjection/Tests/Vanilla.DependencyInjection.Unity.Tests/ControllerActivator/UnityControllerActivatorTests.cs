using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using Vanilla.DependencyInjection.Unity.DI.Unity;
using Vanilla.DependencyInjection.Unity.Tests.Helpers;

namespace Vanilla.DependencyInjection.Unity.Tests.ControllerActivator
{
    [TestClass]
    public class UnityControllerActivatorTests
    {
        private IControllerActivator _unityControllerActivator;

        [TestInitialize]
        public void Setup()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<Controller, DummyController>();
            _unityControllerActivator = new UnityControllerActivator(unityContainer);

        }

        [TestMethod]
        public void ControllerActivator_Create_ShouldResolveDummyController()
        {
            //Arrange
            var context = MvcMockHelpers.MockHttpContext("~/dummy");

            //Act
            var response = _unityControllerActivator.Create(context.Request.RequestContext, typeof(DummyController));

            //Assert
            Assert.IsNotNull(response);

        }
    }
}
