using ASP_Meeting_3.Services.Abstract;
using System.Text;

namespace ASP_Meeting_3.Middleware
{
    public class ShowServicesMiddleware
    {
        private readonly RequestDelegate next;

        public ShowServicesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //string path = context.Request.Path;
            //if (!string.IsNullOrEmpty(path) && path.ToString() == "/services")
            //{
            //    StringBuilder sb = new StringBuilder();
            //    sb.Append("<table><thead><tr>");
            //    sb.Append("<th>Service</th><th>Impementation</th><th>Lifetime</th>");
            //    sb.Append("</tr></thead>");
            //    sb.Append("<tbody>");
            //    var services= context.RequestServices;
            //    foreach(var service in services.)
            //    context.Response.ContentType = "text/html;charset=utf-8";
            //    await context.Response.WriteAsync(message);
            //}
            //else
                await next(context);
        }
    }
}
