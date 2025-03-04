using ASP_Meeting_3.Middleware;
using ASP_Meeting_3.Services.Abstract;
using ASP_Meeting_3.Services.Implementation;
using ASP_Meeting_3.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<IMessageService, ModalMessageService>();
builder.Services.AddMyMessageService();
var app = builder.Build();

// index.html -> / 
// team/index.html -> /team
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseMiddleware<AboutMiddleware>();
app.UseMiddleware<ContactsMiddleware>();
app.Use(async (context, next) => {
    string path = context.Request.Path;
    if (!string.IsNullOrEmpty(path) && path.ToString() == "/services")
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<h1 style='text-align:center'>Зареєстровані сервіси</h1>");
        sb.Append("<table><thead><tr>");
        sb.Append($"<th>№</th>");
        sb.Append("<th>Service Type</th><th>Impementation</th><th>Lifetime</th>");
        sb.Append("</tr></thead>");
        sb.Append("<tbody>");
        var services = builder.Services;
        int count = 0;
        foreach(var service in services)
        {
            sb.Append("<tr>");
            sb.Append($"<td>{++count}</td>");
            sb.Append($"<td>{service.ServiceType.Name}</td>");
            sb.Append($"<td>{service.ImplementationType?.Name}</td>");
            sb.Append($"<td>{service.Lifetime}</td>");
            sb.Append("</tr>");
        }
        sb.Append("</tbody></table>");
        context.Response.ContentType = "text/html;charset=utf-8";
        await context.Response.WriteAsync(sb.ToString());
    }
    else
        await next(context);
});

app.Run(async context =>
{
    string message = "Not found!";
    context.Response.ContentType = "text/html;charset=utf-8";
    //IMessageService messageService = new BasicHtmlMessageService();
    //1. Service Locator - сервіс-локатор
    IMessageService messageService = context.RequestServices.GetRequiredService<IMessageService>();
    message = messageService.GetMessage(message);
    await context.Response.WriteAsync(message);
});
app.Run();
