using Vanilla.DependencyInjection.Unity.Tests.Interfaces;

namespace Vanilla.DependencyInjection.Unity.Tests.Implementations
{
    public class Multiplication : ICalculator
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }
    }
}