using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);
string connStr = builder.Configuration.GetSection("AzureWebJobsStorage").Value ??
    throw new InvalidOperationException("You should provide storage connection string!");
builder.ConfigureFunctionsWebApplication()
    //.Services.AddAzureClients(configure => {
    //    configure.AddQueueServiceClient(connStr).WithName("myQueueClient");
    //   // configure.AddTableServiceClient(connStr).WithName("myTableClient");
    //})
    ;

// Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
builder//.AzureWebJobsStorage
    .Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Build().Run();
