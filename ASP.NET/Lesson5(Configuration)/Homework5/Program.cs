using Homework5.Middlewares;
using Homework5.Models;
using System.Drawing;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("student.json");
builder.Configuration.AddCommandLine(args);

builder.Services.Configure<Student>(builder.Configuration.GetSection("Student"));

var app = builder.Build();

app.UseMiddleware<StudentMiddleware>();

app.MapGet("/", async (IConfiguration configuration, HttpContext context) =>
{
    string color = configuration["color"] ?? "black";
    string bgColor = configuration["bgColor"] ?? "black";

    context.Response.ContentType = "text/html; charset=utf-8";

    var sb = new StringBuilder();
    sb.Append($"<body style='color:{color}; background-color:{bgColor};'>");
    await context.Response.WriteAsync($"<h1 style='color:{color};'>Try <a href='/home'>/home</a> or <a href='/academy'>/academy</a></h1>");
    sb.Append($"</body>");
    await context.Response.WriteAsync(sb.ToString());
});

app.Run();