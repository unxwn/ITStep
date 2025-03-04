using WebApplication1.Services.Abstraction;

namespace WebApplication1.Middlewares
{
    public class CalculationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ICalculationService calculationService;

        public CalculationMiddleware(RequestDelegate next, ICalculationService calculationService)
        {
            this.next = next;
            this.calculationService = calculationService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments("/calc"))
            {
                if (context.Request.Query.ContainsKey("index") &&
                    int.TryParse(context.Request.Query["index"], out int indexValue))
                {
                    try
                    {
                        long result = await calculationService.CalculateAsync(indexValue);
                        context.Response.StatusCode = 200;
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync(result.ToString());
                        return;
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync($"Error: {ex.Message}");
                        return;
                    }
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Query parameter 'index' is missing or invalid. For example insert: ?index=6 ");
                    return;
                }
            }

            await next(context);
        }
    }
}
