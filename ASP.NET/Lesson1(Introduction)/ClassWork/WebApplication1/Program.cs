using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.OutputEncoding = Encoding.UTF8;
app.MapGet("/", () => "Hello World!");
app.MapGet("/name", () => app.Environment.ApplicationName);
app.MapGet("/log", () => {
    string message = $"Оримано HTTP запит о {DateTime.Now.ToLongTimeString()}";
    Console.WriteLine(message);
    return message;
});
app.MapGet("/auto/car", () => {
    var car = new { Manufacturer = "Aidu", Model = "Q7", Year = 2017, Price = 35999.9 };
    return car;
});

app.MapGet("/index", GetIndexPage);
//app.MapGet("/moto", async (HttpContext context) => { });
app.MapGet("/auto/moto", async context => {
    var moto = new
    {
        Manufacturer = "Harley Davidson",
        Model = "Low Rider S 2025",
        Engine = "Milwaukee-Eight® 117 High-Output"
    };
    await context.Response.WriteAsJsonAsync(moto);
});
app.Run();


async Task GetIndexPage(HttpContext context)
{
    StringBuilder sb = new StringBuilder();
    sb.Append("<h1>Перше знайомство з ASP.NET</h1>");
    sb.Append("<h2 style='color:cadetblue'>Підтримувані моделі додатку</h2>");
    sb.Append("<ul>");
    sb.Append("<li>Razor pages</li>");
    sb.Append("<li>MVC</li>");
    sb.Append("<li>Web API</li>");
    sb.Append("</ul>");
    sb.Append("<hr>");
    context.Response.Headers.Append("Content-Type", "text/html;charset=utf-8");
    context.Response.Headers.Append("Developer", "Serhii Ruban");
    await context.Response.WriteAsync(sb.ToString());
}