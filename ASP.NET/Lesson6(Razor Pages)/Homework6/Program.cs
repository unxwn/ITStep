var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<List<Homework6.Pages.Country>>(builder.Configuration.GetSection("Countries"));
builder.Services.AddRazorPages();
var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();

app.Run();
