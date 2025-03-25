using ASP_Meeting_7.Services.Abstract;
using ASP_Meeting_7.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IAuthorRepository, MockAuthorRepository>();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
