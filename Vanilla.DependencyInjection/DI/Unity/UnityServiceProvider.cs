using System;
using Unity;

namespace Vanilla.DependencyInjection.Unity.DI.Unity
{
    public class UnityServiceProvider : IServiceProvider
    {
        private readonly UnityContainer _container;

        public UnityContainer Container => _container;

        public UnityServiceProvider()
        {
            _container = new UnityContainer();

        }

        public object GetService(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }
    }
}