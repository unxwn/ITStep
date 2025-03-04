using ASP_Meeting_3.Services.Abstract;
using ASP_Meeting_3.Services.Implementation;

namespace ASP_Meeting_3.Middleware
{
    public class AboutMiddleware
    {
        private readonly RequestDelegate next;

        public AboutMiddleware(RequestDelegate next) {
            this.next = next;
        }
        //3й спосіб - через параметр методу Invoke/InvokeAsync
        public async Task InvokeAsync(HttpContext context, 
            IMessageService messageService)
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && path.ToString() == "/about")
            {
                string message = "About page";
                //IMessageService messageService = new BasicHtmlMessageService();
                //IMessageService messageService = 
                //    context.RequestServices.GetRequiredService<IMessageService>();
                message = messageService.GetMessage(message);
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(message);
            }
            else
                await next(context);
        }
    }
}
