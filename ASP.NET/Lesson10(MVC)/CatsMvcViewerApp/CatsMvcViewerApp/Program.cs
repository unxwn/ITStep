using CatsMvcViewerApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connStr = builder.Configuration.GetConnectionString("MSSqlCatsDb") ??
    throw new InvalidOperationException("You should provide conn string!");
builder.Services.AddDbContext<CatsContext>(options =>
options.UseSqlServer(connStr)
);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Breeds}/{action=Index}/{id?}");

app.Run();
