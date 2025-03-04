using ASP_Meeting_3.Services.Abstract;
using ASP_Meeting_3.Services.Implementation;

namespace ASP_Meeting_3.Middleware
{
    public class ContactsMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IMessageService messageService;
        
        //Dependency Injection - впровадження залежностей (сервісів)
        //IoC Containers - Inversion of Control Containers
        //2 спосіб - впровадження через конструктор
        public ContactsMiddleware(RequestDelegate next, IMessageService messageService)
        {
            this.next = next;
            this.messageService = messageService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            if (!string.IsNullOrEmpty(path) && path.ToString() == "/contacts")
            {
                string message = "Contacts page";
                //IMessageService messageService = new BasicHtmlMessageService();
                //IMessageService messageService = new ModalMessageService();
                message = messageService.GetMessage(message);
                context.Response.ContentType = "text/html;charset=utf-8";
                await context.Response.WriteAsync(message);
            }
            else
                await next(context);
        }
    }
}
