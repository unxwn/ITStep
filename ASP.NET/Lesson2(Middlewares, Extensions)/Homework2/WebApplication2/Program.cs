using WebApplication2.Extensions;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

string userSecret = "Qwerty1234";

app.Use(async (context, next) =>
{
    await next();
    switch (context.Response.StatusCode)
    {
        case 401:
            await context.Response.WriteAsync("You need to be authenticated! Insert token (?token=Qwerty1234)!");
            break;
        case 404:
            await context.Response.WriteAsync("Page not found!");
            break;
    }
});

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseMyAuthorization(userSecret);

app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/index.html");
});

app.MapGet("/home", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.SendFileAsync("html/home.html");
});

app.MapGet("/fibonacci", async context =>
{
    var query = context.Request.Query;
    if (query.ContainsKey("index"))
    {
        if (!int.TryParse(query["index"], out int index))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid 'index' parameter.");
            return;
        }

        long FibonacciRecursive(int n)
        {
            if (n <= 0)
                return 0;
            if (n == 1)
                return 1;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        long fibResult = FibonacciRecursive(index);
        await context.Response.WriteAsync($"Fibonacci number at index {index} is {fibResult}");
    }
    else if (query.ContainsKey("value"))
    {
        if (!long.TryParse(query["value"], out long value))
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid 'value' parameter.");
            return;
        }

        List<long> sequence = new List<long>();
        long a = 0, b = 1;
        sequence.Add(a);
        if (value > 0)
            sequence.Add(b);

        while (true)
        {
            long next = a + b;
            if (next >= value)
                break;
            sequence.Add(next);
            a = b;
            b = next;
        }
        string resultSequence = string.Join(", ", sequence);
        await context.Response.WriteAsync($"Fibonacci sequence with numbers less than {value}: {resultSequence}");
    }
    else
    {
        context.Response.ContentType = "text/html; charset=utf-8";
        await context.Response.SendFileAsync("html/fibonacciForm.html");
    }
});

//app.MapPost("/fibonacci", async context =>
//{
//    var form = await context.Request.ReadFormAsync();
//    string mode = form["mode"];

//    if (mode == "index")
//    {
//        string indexStr = form["index"];
//        if (!string.IsNullOrWhiteSpace(indexStr))
//        {
//            context.Response.Redirect($"/fibonacci?index={indexStr}");
//            return;
//        }
//    }
//    else if (mode == "value")
//    {
//        string valueStr = form["value"];
//        if (!string.IsNullOrWhiteSpace(valueStr))
//        {
//            context.Response.Redirect($"/fibonacci?value={valueStr}");
//            return;
//        }
//    }

//    context.Response.StatusCode = 400;
//    await context.Response.WriteAsync("Please provide a valid input value.");
//});


app.MapGet("/name", async context =>
{
    await context.Response.WriteAsync("Polishchuk Myroslav Igoryovych");
});

app.MapGet("/app", async context =>
{
    string appInfo = $"{app.Environment.ApplicationName} - {DateTime.Now.ToLongDateString()}";
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(appInfo);
});

app.MapGet("/todo", async context =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    StringBuilder sb = new StringBuilder();
    sb.Append("<h1>Today's Tasks</h1>");
    sb.Append("<ul>");
    sb.Append("<li>Write code</li>");
    sb.Append("<li>Test the application</li>");
    sb.Append("<li>Deploy to server</li>");
    sb.Append("</ul>");
    await context.Response.WriteAsync(sb.ToString());
});

app.Run();
