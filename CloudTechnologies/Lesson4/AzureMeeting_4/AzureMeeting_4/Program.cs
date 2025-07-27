// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");
HostBuilder builder = new HostBuilder();
builder.ConfigureWebJobs(configure => {
    configure.AddAzureStorageBlobs();
    configure.AddAzureStorageQueues();
});
builder.ConfigureLogging((context, configure) =>
{
    configure.AddConsole();
    string? instrumentationKey = context.Configuration.GetValue<string>("AppInsightInstrumentationKey");
    if (!string.IsNullOrEmpty(instrumentationKey))
    {
        configure.AddApplicationInsightsWebJobs(options => {
            options.InstrumentationKey = instrumentationKey;
        });
    }
});
var host  = builder.Build();
using (host)
{
    host.Run();
}