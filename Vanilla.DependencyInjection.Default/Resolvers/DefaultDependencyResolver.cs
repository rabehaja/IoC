using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web.Mvc;
using Sitecore.DependencyInjection;

namespace Vanilla.DependencyInjection.Default.Resolvers
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        private readonly IDependencyResolver _resolver;
     
        public DefaultDependencyResolver(IDependencyResolver resolver)
        {
            _resolver = resolver;
            
        }
        public object GetService(Type serviceType)
        {
            return ServiceLocator.ServiceProvider.GetService(serviceType) ?? _resolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var source = (IEnumerable<object>)ServiceLocator.ServiceProvider.GetService(typeof(IEnumerable<>).MakeGenericType(serviceType));
            object[] objArray = source as object[] ?? source.ToArray<object>();
            if (source != null && ((IEnumerable<object>)objArray).Any<object>())
                return (IEnumerable<object>)objArray;
            return this._resolver.GetServices(serviceType);
        }
    }
}
