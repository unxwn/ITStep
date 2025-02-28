using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Console.OutputEncoding = Encoding.UTF8;

app.MapGet("/home/{task?}", async (HttpContext context, string? task) =>
{
    
    
    if (string.IsNullOrEmpty(task))
    {
        await context.Response.WriteAsync("No task specified. Use:\n/home/fibonacci?index={indexValue},\n/home/fibonacci?value={value},\n/home/name,\n/home/app,\n/home/todo.");
        return;
    }

    switch (task.ToLower())
    {
        case "name":
            await context.Response.WriteAsync("Polishchuk Myroslav Igoryovych");
            break;

        case "app":
            string appInfo = $"{app.Environment.ApplicationName} - {DateTime.Now.ToLongDateString()}";
            await context.Response.WriteAsync(appInfo);
            break;

        case "todo":
            StringBuilder sb = new StringBuilder();
            sb.Append("<h1>Today's taskssss</h1>");
            sb.Append("<ul>");
            sb.Append("<li>Write code</li>");
            sb.Append("<li>Test application</li>");
            sb.Append("<li>Deploy to server</li>");
            sb.Append("</ul>");
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync(sb.ToString());
            break;

        case "fibonacci":
            var query = context.Request.Query;
            if (query.ContainsKey("index"))
            {
                if (!int.TryParse(query["index"], out int index))
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid index parameter.");
                    break;
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
                    await context.Response.WriteAsync("Invalid value parameter.");
                    break;
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
                await context.Response.WriteAsync($"Fibonacci sequence up to last number less than {value}: {resultSequence}");
            }
            else
            {
                await context.Response.WriteAsync("Please specify either 'index' or 'value' query parameter.");
            }
            break;

        default:
            await context.Response.WriteAsync("Invalid route. Use:\n/home/fibonacci?index={indexValue},\n/home/fibonacci?value={value},\n/home/name,\n/home/app,\n/home/todo.");
            break;
    }
});

app.MapGet("/", () => "Welcome to the ASP.NET Core app. Try:\n/home/fibonacci?index={indexValue},\n/home/fibonacci?value={value},\n/home/name,\n/home/app,\n/home/todo.");

app.Run();
