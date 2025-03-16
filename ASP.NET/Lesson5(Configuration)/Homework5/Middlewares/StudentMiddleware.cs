using Homework5.Models;
using Microsoft.Extensions.Options;
using System.Text;

namespace Homework5.Middlewares
{
    public class StudentMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<Student> _studentOptions;
        private readonly IConfiguration _configuration;

        public StudentMiddleware(RequestDelegate next, IOptions<Student> studentOptions, IConfiguration configuration)
        {
            _next = next;
            _studentOptions = studentOptions;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var student = _studentOptions.Value;
            string path = context.Request.Path.Value?.ToLower() ?? "";

            string color = _configuration["color"] ?? "black";
            string bgColor = _configuration["bgColor"] ?? "black";

            if (path == "/home")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                var sb = new StringBuilder();
                sb.Append($"<body style='color:{color}; background-color:{bgColor};'>");
                sb.Append($"<h1>Student`s name: {student.FirstName} {student.LastName}</h1>");
                sb.Append($"<h2>Age: {student.Age}</h2>");
                sb.Append($"</body>");
                await context.Response.WriteAsync(sb.ToString());
            }
            else if (path == "/academy")
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                var sb = new StringBuilder();
                sb.Append($"<body style='color:{color}; background-color:{bgColor};'>");
                sb.Append($"<h1>{student.FirstName} {student.LastName}</h1>");
                sb.Append($"<h2>Subjects:</h2>");
                foreach (var subject in student.Subjects)
                {
                    sb.Append($"<li>{subject}</li>");
                }
                sb.Append("</ul>");
                sb.Append($"</body>");
                await context.Response.WriteAsync(sb.ToString());
            }
            else
            {
                await _next(context);
            }
        }
    }
}
