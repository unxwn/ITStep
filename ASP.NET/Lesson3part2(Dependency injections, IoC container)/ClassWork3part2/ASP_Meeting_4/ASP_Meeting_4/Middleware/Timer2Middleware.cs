using ASP_Meeting_4.Services.Abstract;
using ASP_Meeting_4.Services.Implementation;
using System.Text;

namespace ASP_Meeting_4.Middleware
{
    public class Timer2Middleware
    {
        private readonly RequestDelegate next;

        public Timer2Middleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IEnumerable<IMyTimer> timers, TimerService timerService)
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && path.ToLower() == "/time")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<h1>Services Lifetime</h1>");
                sb.Append("<h2>From timers</h2>");
                foreach (var timer in timers)
                    sb.Append($"<h3>From timer: {timer.CurrentTime}</h3>");
                sb.Append("<hr>");
                sb.Append($"<h2>From service: {timerService.Timer.CurrentTime}</h2>");
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(sb.ToString());
            }
            else
                await next(context);
        }
    }
}
