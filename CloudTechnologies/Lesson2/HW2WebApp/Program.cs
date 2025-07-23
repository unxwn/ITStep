using Azure.Storage.Blobs;
using Azure.Storage.Queues;
using HW2WebApp.Data;
using HW2WebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSingleton(
    new BlobServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage"))
    );

builder.Services.AddSingleton(sp =>
    new QueueServiceClient(builder.Configuration.GetConnectionString("AzureBlobStorage"))
    );

builder.Services.AddScoped<BlobStorageService>();
builder.Services.AddScoped<QueueService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    //db.Files.RemoveRange(db.Files);
    //await db.SaveChangesAsync();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
