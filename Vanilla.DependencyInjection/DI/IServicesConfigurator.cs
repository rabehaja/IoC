using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace Vanilla.DependencyInjection.Unity.DI
{
  public  interface IServicesConfigurator
    {
        void Configure(IUnityContainer container);
    }
}
