using ASP_Meeting_7.Data;
using ASP_Meeting_7.Services.Abstract;
using ASP_Meeting_7.Services.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
string connStr = builder.Configuration
    .GetConnectionString("MSSQLLibrary") ??
    throw new InvalidOperationException("You should specify conn string!");

builder.Services.AddDbContext<LibraryContext>(optionsBuilder => { 
    optionsBuilder.UseSqlServer(connStr);
});
//builder.Services.AddSingleton<IAuthorRepository, MockAuthorRepository>();
builder.Services.AddScoped<IAuthorRepository, EFAuthorRepository>();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapRazorPages();

app.Run();
