using WebApplication1.Services.Abstraction;

namespace WebApplication1.Services.Implementation
{
    public class FactorialCalculationService : ICalculationService
    {
        public async Task<long> CalculateAsync(int index)
        {
            return await Task.Run(() => CalculateFactorial(index));
        }

        private long CalculateFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Index must be non-negative");
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }

}
