var builder = WebApplication.CreateBuilder(args);
//// Найбільша кількість сервісів
//builder.Services.AddMvc();
//builder.Services.AddMvcCore();
builder.Services.AddControllersWithViews();
var app = builder.Build();


app.MapControllerRoute(name: "default", 
    //"{controller}/{action}/{id?}"
    "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
