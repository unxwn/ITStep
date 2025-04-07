using Microsoft.EntityFrameworkCore;
using RestaurantsCatalog.Data;

var builder = WebApplication.CreateBuilder(args);

string connStr = builder.Configuration.GetConnectionString("MSSQLRestaurantsCatalogDB") ?? 
    throw new ArgumentException("Connection string you provided doesn't exist. Provide valid one.");

builder.Services.AddDbContext<RestaurantsCatalogContext>(options =>  options.UseSqlServer(connStr));
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Restaurants}/{action=Index}/{id?}");

app.Run();
