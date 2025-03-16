using Microsoft.Extensions.Options;

namespace ASP_Meeting_5.Middleware
{
    public class AcademyMiddleware
    {
        private readonly RequestDelegate next;

        public AcademyMiddleware(RequestDelegate next)
        {
            this.next = next;
        } 


        public async Task InvokeAsync(HttpContext context, IOptions<Education> options)
        {
            string path  = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && path.ToLower() == "/education3")
            {
                Education education = options.Value;
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync($"<h2>Освіта: {education!.Level}, " +
                    $"{education!.Institution}, " +
                    $"{education.GraduationYear} рік</h2>");
            }
            else
                await next(context);
        }
    }
}
