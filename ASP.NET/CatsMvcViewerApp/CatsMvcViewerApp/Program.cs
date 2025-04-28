using CatsMvcViewerApp.Data;
using CatsMvcViewerApp.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//string connStr = builder.Configuration.GetConnectionString("MSSqlCatsDb") ??
string connStr = builder.Configuration.GetConnectionString("SomeeCatsLibraryDb") ??
    throw new InvalidOperationException("You should provide conn string!");
builder.Services.AddDbContext<CatsContext>(options =>
options.UseSqlServer(connStr)
);
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(CatProfile), typeof(BreedProfile));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = scope.ServiceProvider;
    await CatsSeeder.SeedData(serviceProvider, app.Environment);
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
