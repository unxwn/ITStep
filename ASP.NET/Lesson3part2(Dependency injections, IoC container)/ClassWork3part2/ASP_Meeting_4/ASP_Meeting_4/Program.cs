using ASP_Meeting_4.Middleware;
using ASP_Meeting_4.Services.Abstract;
using ASP_Meeting_4.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IMyTimer, MyDetailedTimer>();
builder.Services.AddTransient<IMyTimer, MyTimer>();
builder.Services.AddScoped<TimerService>();
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.Map("/time", (IMyTimer timer, TimerService timerService) => {
//    return $"Time from timer: {timer.CurrentTime}, Time from service: {timerService.Timer.CurrentTime}";
//});
app.UseMiddleware<Timer2Middleware>();
app.Run(async (context) =>
{
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("Not found");
});
app.Run();
