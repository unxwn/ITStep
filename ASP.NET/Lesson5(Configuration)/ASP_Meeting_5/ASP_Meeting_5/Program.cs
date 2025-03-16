using ASP_Meeting_5;
using ASP_Meeting_5.Middleware;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string?> {
    {"city", "Київ" },
    {"country", "Україна" }
});
builder.Configuration.AddJsonFile("education.json");
var educationSection = builder.Configuration.GetSection("Employee:Education");
builder.Services.Configure<Education>(educationSection);
var configurationManager = builder.Configuration;
var app = builder.Build();
var configuration= app.Configuration;

//IConfigurationSection loggingSection = configuration.GetSection("Logging");
//IConfigurationSection logLevelSection = loggingSection.GetSection("LogLevel");
//IConfigurationSection defaultSection = logLevelSection.GetSection("Microsoft.AspNetCore");
IConfigurationSection defaultSection = configuration.GetSection("Logging:LogLevel:Default");
string defaultLogginLevelSectionValue = defaultSection.Value ??
    throw new InvalidOperationException("You should provide config section!");
IConfigurationSection employeeSection = app.Configuration.GetSection("Employee");
string? company = employeeSection.GetSection("Company").Value;
//string? position = employeeSection["Position"];
string? position = configuration["Employee:Position"];
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseMiddleware<AcademyMiddleware>();
app.MapGet("/employee", async (HttpContext context) => {
    string institution = app.Configuration["Education:institution"] ?? "Невідомий ЗВО";
    string level = app.Configuration["education:Level"] ?? "Невідомий рівень освіти";
    int graduationYear = app.Configuration.GetValue<int>("Education:GraduationYear");

    context.Response.ContentType = "text/html;charset=utf-8";
    StringBuilder sb  = new StringBuilder();
    sb.Append($"<h1>Company: {company}, Position: {position}</h1>");
    sb.Append($"<h2>Освіта: {level}, {institution}, {graduationYear} рік</h2>");
    await context.Response.WriteAsync(sb.ToString());
});
app.MapGet("/home", async (HttpContext context) => {
    int fontSize = configuration.GetValue<int>("fontSize");
    string? color = configuration["color"];
    string city = configuration["city"] ?? "Kryvyi Rih";
    string country = configuration["country"] ?? "Ukraine";
    context.Response.ContentType = "text/html;charset=utf-8";
    string finalColor = string.IsNullOrEmpty(color) ? "magenta" : color;
    if (fontSize <= 0)
        fontSize = 14;
    await context.Response.WriteAsync($"<p style='color: {finalColor};font-size: {fontSize}px'>" +
        $"{city}, {country}</p>");
});
app.MapGet("/proc", () => {
    string procName = configuration["PROCESSOR_IDENTIFIER"] ?? "Unknown Processor";
    return procName;
});
app.MapGet("/divide", async (HttpContext context) => {
    int.TryParse(context.Request.Query["x"], out int x);
    int.TryParse(context.Request.Query["y"], out int y);
    int res = x / y;
    await context.Response.WriteAsync($"{x} / {y} = {res}");

});
//pv312
app.MapGet("/group", () => {
    string groupName = configuration["pv312"] ?? "Unknown Group";
    return groupName;
});
app.MapGet("/envir", () => {
    return app.Environment.EnvironmentName;
});
app.MapGet("/education", async (HttpContext context) => {
    
    //Education? education = null;
    var educationSection = app.Configuration.GetSection("Employee:Education");
    //educationSection.Bind(education);
    Education? education = educationSection.Get<Education>();
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"<h2>Освіта: {education!.Level}, " +
        $"{education!.Institution}, " +
        $"{education.GraduationYear} рік</h2>");
});
app.MapGet("/employee2", async (HttpContext context) => {
    IConfiguration employeeSection = app.Configuration.GetSection("Employee"); 
    Employee? employee = employeeSection.Get<Employee>();
    context.Response.ContentType = "text/html;charset=utf-8";
    StringBuilder sb = new StringBuilder();
    sb.Append($"<h1>Company: {employee!.Company}, Position: {employee!.Position}</h1>");
    sb.Append($"<h2>Освіта: {employee.Education.Level}, " +
        $"{employee.Education.Institution}, " +
        $"{employee.Education.GraduationYear} рік</h2>");
    await context.Response.WriteAsync(sb.ToString());
});

app.MapGet("/education2", async (HttpContext context, IOptions<Education> options) => {
   
    Education education = options.Value;
    context.Response.ContentType = "text/html;charset=utf-8";
    await context.Response.WriteAsync($"<h2>Освіта: {education!.Level}, " +
        $"{education!.Institution}, " +
        $"{education.GraduationYear} рік</h2>");
});

app.MapGet("/", () => $"Logging:LogLevel:Default->{defaultLogginLevelSectionValue}");
app.Run();
