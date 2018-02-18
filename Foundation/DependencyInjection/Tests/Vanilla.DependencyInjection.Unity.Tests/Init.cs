using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vanilla.DependencyInjection.Unity.DI.Unity;

namespace Vanilla.DependencyInjection.Unity.Tests
{
    [TestClass]
    public class Init
    {
        public static IServiceCollection ServiceCollection;
        public static IServiceProvider ServiceProvider;

        [AssemblyInitialize]
        public static void ConfigureServices(TestContext context)
        {
            ServiceCollection = new ServiceCollection();
            ServiceProvider = new UnityServiceProvider();
        }

        [AssemblyCleanup]
        public static void Destroy()
        {
            ServiceCollection = null;
            ServiceProvider = null;
        }
    }
}
