using WebApplication1.Middlewares;

namespace WebApplication1.Extensions.MiddlewareExtensions
{
    public static class CalculationMiddlewareExtension
    {
        public static IApplicationBuilder UseCalculationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CalculationMiddleware>();
        }
    }
}
