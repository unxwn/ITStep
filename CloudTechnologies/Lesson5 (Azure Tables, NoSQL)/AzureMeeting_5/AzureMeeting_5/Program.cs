using Azure.Data.Tables;
using AzureMeeting_5.Models;
using AzureMeeting_5.Services.Abstract;
using AzureMeeting_5.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<TableServiceClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    return new TableServiceClient(config.GetConnectionString("StorageAccount")!);
});

builder.Services.AddScoped<TableClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var serviceClient = sp.GetRequiredService<TableServiceClient>();
    string tableName = config.GetValue<string>("AzureTableStorage:TableName")!;
    return serviceClient.GetTableClient(tableName);
});

builder.Services.AddHostedService<StorageInitializerHostedService>();

builder.Services.AddScoped<ITableStorageService<Product>, ProductStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
