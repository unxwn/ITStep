using ASP_Meeting_4.Services.Abstract;
using ASP_Meeting_4.Services.Implementation;
using System.Text;

namespace ASP_Meeting_4.Middleware
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMyTimer timer;
        private readonly TimerService timerService;

        public TimerMiddleware(RequestDelegate next, IMyTimer timer, TimerService timerService)
        {
            this.next = next;
            this.timer = timer;
            this.timerService = timerService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && path.ToLower() == "/time")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<h1>Services Lifetime</h1>");
                sb.Append($"<h3>From timer: {timer.CurrentTime}</h3>");
                sb.Append($"<h3>From service: {timerService.Timer.CurrentTime}</h3>");
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            }
            else
                await next(context);
        }
    }
}
