using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Unity;
using Unity.Injection;
using Unity.ServiceLocation;
using Vanilla.DependencyInjection.Unity.DI.Unity;

namespace Vanilla.DependencyInjection.Unity.DI.Provider
{
    /// <summary>
    /// The unity service provider which will replace Sitecore's default service provider.
    /// </summary>
    public class UnityServiceProviderBuilder : DefaultServiceProviderBuilder
    {
        private IServiceCollection _serviceCollection;

        protected override IServiceProvider BuildServiceProvider(IServiceCollection serviceCollection)
        {
            var unityServiceProvider = new UnityServiceProvider();
            
        }

        //protected override IServiceProvider BuildServiceProvider(IServiceCollection serviceCollection)
        //{
        //    var unityServiceProvider = new UnityServiceProvider();

        //    IUnityContainer container = unityServiceProvider.Container;
        //    // Caution!!! Do this before you Build the ServiceProvider !!!
        //    //Register my unity container in the service collection so I can access it when really needed.
        //    serviceCollection.AddSingleton(container);
        //    // Adding the Controller Activator
        //    serviceCollection.AddSingleton<IControllerActivator>(new UnityControllerActivator(container));

        //    //Now build the Service Provider
        //    var defaultProvider = serviceCollection.BuildServiceProvider();
        //    // Configure UnityContainer
        //    // #region Unity
        //    container.RegisterType<HttpRequestBase>(new InjectionFactory(_ =>
        //        new HttpRequestWrapper(HttpContext.Current.Request)));
        //    container.RegisterType<HttpResponseBase>(new InjectionFactory(_ =>
        //        new HttpResponseWrapper(HttpContext.Current.Response)));
        //    container.RegisterType<HttpContextBase>(new InjectionFactory(_ =>
        //        new HttpContextWrapper(HttpContext.Current)));
        //    //Add the Fallback extension with the default provider
        //    container.AddExtension(new UnityFallbackProviderExtension(defaultProvider));
        //    DependencyResolver.SetResolver(new UnityServiceLocator(container));
        //    // #endregion
        //    return unityServiceProvider;
        //}


        public new IServiceCollection ConfigureServiceCollection()
        {
            var services = _serviceCollection ?? this.ConfigureServiceCollection();
            services.AddSingleton(typeof(BaseServiceProviderBuilder), (object)this);
            this.Configure((IServiceCollection)services);
            return (IServiceCollection)services;
        }

        public void SetServiceCollection(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection ?? new ServiceCollection();
        }

        public IServiceProvider BuildProvider()
        {
            return this.BuildServiceProvider(this.ConfigureServiceCollection());
        }
    }
}