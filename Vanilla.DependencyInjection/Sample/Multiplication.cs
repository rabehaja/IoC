namespace Vanilla.DependencyInjection.Unity.Sample
{
    public class Multiplication : ICalculator
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }
    }
}