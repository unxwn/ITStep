using WebApplication1.Services.Abstraction;
using WebApplication1.Services.Implementation;

namespace WebApplication1.Extensions.ServicesExtensions
{
    public static class CalculationServicesExtension
    {
        public static IServiceCollection AddFibonacciCalculationService(
            this IServiceCollection services)
        {
            services.AddTransient<ICalculationService, FibonacciCalculationService>();
            return services;
        }

        public static IServiceCollection AddFactorialCalculationService(
            this IServiceCollection services)
        {
            services.AddTransient<ICalculationService, FactorialCalculationService>();
            return services;
        }
    }
}
