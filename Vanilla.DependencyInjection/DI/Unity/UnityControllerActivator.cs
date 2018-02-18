using System;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace Vanilla.DependencyInjection.Unity.DI.Unity
{
    /// <summary>
    /// My unity controller activator. Used to instantiate my controllers and inject the dependencies.
    /// </summary>
    public class UnityControllerActivator : IControllerActivator
    {
        private IUnityContainer _unityContainer;

        public UnityControllerActivator(IUnityContainer container)
        {
            _unityContainer = container;
        }

        #region Implementation of IControllerActivator

        public void Release(ControllerContext context, object controller)
        {
            //ignored
        }

        #endregion

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return _unityContainer.Resolve(controllerType) as IController;
        }
    }
}