using WebApplication1.Extensions.MiddlewareExtensions;
using WebApplication1.Extensions.ServicesExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFibonacciCalculationService();
builder.Services.AddFactorialCalculationService();
var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/calc"); return;
    }

    await next();
});

app.UseCalculationMiddleware();

app.MapGet("/{*any}", context =>
{
    context.Response.Redirect("/calc"); 
    return Task.CompletedTask;
});

app.Run();
