namespace Vanilla.DependencyInjection.Unity.Sample
{
    public class Addition : ICalculator
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}