using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Unity;
using Unity.Lifetime;

namespace Vanilla.DependencyInjection.Unity.sitecore.admin
{
    /// <summary>
    /// Overriding Sitecore's default page to show in the page services registered in Unity.
    /// </summary>
    
    [AllowDependencyInjection]
    public partial class ShowServicesConfig : Sitecore.sitecore.admin.AdminPage
    {
        /// <summary>The configurator.</summary>
        private readonly BaseServiceProviderBuilder _configurator;
        private readonly IUnityContainer _container;

        public ShowServicesConfig()
        {

        }

        public ShowServicesConfig(BaseServiceProviderBuilder configurator, IUnityContainer container)
        {
            _configurator = configurator;
            _container = container;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var testing = this._configurator.ConfigureServiceCollection().Select(serviceDescriptor => new
            {
                serviceType = this.FormatType(serviceDescriptor.ServiceType),
                implementation = this.GetImplementation(serviceDescriptor),
                lifetime = serviceDescriptor.Lifetime
            });

            var unityServices = _container.Registrations.Select(_ => new
            {
                RegisteredType = FormatType(_.RegisteredType),
                MappedToType = FormatType(_.MappedToType),
                LifetimeManager = GetLifeTime(_.LifetimeManager),
                Name =GetName(_.Name) 
            }).OrderBy(t=>t.Name);

            FinalRepeater.DataSource = unityServices;
            FinalRepeater.DataBind();
            SitecoreConfiguration.DataSource = testing;
            SitecoreConfiguration.DataBind();

        }

        /// <summary>Gets and implementation from the service descriptor.</summary>
        /// <param name="serviceDescriptor">The service descriptor.</param>
        /// <returns>The service implementation details.</returns>
        protected virtual string GetImplementation(ServiceDescriptor serviceDescriptor)
        {
            Assert.ArgumentNotNull((object)serviceDescriptor, nameof(serviceDescriptor));
            if (serviceDescriptor.ImplementationType != (Type)null)
                return this.FormatType(serviceDescriptor.ImplementationType);
            if (serviceDescriptor.ImplementationFactory != null)
                return "implementation factory";
            if (serviceDescriptor.ImplementationInstance == null)
                return "not specified";
            return "instance: " + this.FormatType(serviceDescriptor.ImplementationInstance.GetType());
        }


        /// <summary>Formats type to "FullName, Assembly" representation.</summary>
        /// <param name="serviceType">The service type.</param>
        /// <returns>The string representation of the type.</returns>
        protected virtual string FormatType(Type serviceType)
        {
            Assert.ArgumentNotNull((object)serviceType, nameof(serviceType));
            if (serviceType.Assembly.IsDynamic)
                return serviceType.FullName + ", [dynamic assembly]";
            return serviceType.FullName + ", " + Path.GetFileNameWithoutExtension(serviceType.Assembly.Location);
        }

        private string GetLifeTime(LifetimeManager lifetimeManager)
        {
            if (lifetimeManager == null)
            {
                return "undefined";
            }

            switch (lifetimeManager)
            {
                case ExternallyControlledLifetimeManager externallyControlledLifetimeManager:
                    return "Externally Controlled - Weak reference";
                case ContainerControlledLifetimeManager containerControlledLifetimeManager:
                    return "Singleton";
                case HierarchicalLifetimeManager hierarchicalLifetimeManager:
                    break;
                case PerResolveLifetimeManager perResolveLifetimeManager:
                    return "Scoped";
                case PerThreadLifetimeManager perThreadLifetimeManager:
                    return "Singleton";
                case SynchronizedLifetimeManager synchronizedLifetimeManager:
                    break;
                case TransientLifetimeManager transientLifetimeManager:
                    return "Transient";
            }
            return "undefined";
        }

        private string GetName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) ? name : "Available Everywhere";
        }
    }
}