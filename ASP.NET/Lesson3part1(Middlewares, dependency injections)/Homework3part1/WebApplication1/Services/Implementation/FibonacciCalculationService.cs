using WebApplication1.Services.Abstraction;

namespace WebApplication1.Services.Implementation
{
    public class FibonacciCalculationService : ICalculationService
    {
        public async Task<long> CalculateAsync(int index)
        {
            return await Task.Run(() => CalculateFibonacci(index));
        }

        private long CalculateFibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("Index must be non-negative");
            if (n == 0) return 0;
            if (n == 1) return 1;

            long a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                long temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }
    }
}
