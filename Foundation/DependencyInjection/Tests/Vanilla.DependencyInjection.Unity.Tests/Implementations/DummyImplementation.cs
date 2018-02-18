using System;
using Vanilla.DependencyInjection.Unity.Tests.Interfaces;

namespace Vanilla.DependencyInjection.Unity.Tests.Implementations
{
    public class DummyImplementation : IDummyInterface
    {
        public void DoSomething()
        {
            Console.Write("Hello World");
        }
    }
}
