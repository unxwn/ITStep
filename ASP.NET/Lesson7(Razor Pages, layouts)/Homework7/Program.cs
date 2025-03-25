using FilmLibrary.Services.Abstraction;
using FilmLibrary.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IFilmRepository, FilmRepository>();
var app = builder.Build();

app.UseStaticFiles();

app.MapRazorPages();

app.Run();
