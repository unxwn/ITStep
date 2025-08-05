// See https://aka.ms/new-console-template for more information
using CosmosUniversitiesApp;
using CosmosUniversitiesApp.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .Build();

var cosmosConfig = config.GetSection("CosmosDB");
string connStr = cosmosConfig["ConnectionString"]
    ?? throw new InvalidOperationException("You should provide CosmosDB:ConnectionString");
string dbId = cosmosConfig["DatabaseId"]
        ?? throw new InvalidOperationException("You should provide CosmosDB:DatabaseId");
string containerId = cosmosConfig["ContainerId"]!
        ?? throw new InvalidOperationException("You should provide CosmosDB:ContainerId");
string partitionPath = cosmosConfig["PartitionKeyPath"]!
        ?? throw new InvalidOperationException("You should provide CosmosDB:PartitionKeyPath");
int throughput = int.Parse(cosmosConfig["Throughput"]!);

CosmosClient cosmosClient = new CosmosClient(connStr);
var cosmosDatabase = await cosmosClient.CreateDatabaseIfNotExistsAsync(dbId);
var cosmosContainer = await cosmosDatabase.Database.CreateContainerIfNotExistsAsync(containerId, partitionPath, throughput);

UniversityService universityService = new UniversityService(cosmosContainer);

University uni = new University
{
    Id = Guid.NewGuid().ToString(),
    Name = "KPI",
    Faculty = new Faculty
    {
        Name = "FICT",
        Courses = {
            new Course { Name = "126 Test", Credits = 5 }
        }
    }
};

await universityService.UpsertUniversityAsync(uni);

var list = await universityService.QueryByFacultyAsync("FICT");
Console.WriteLine($"Found {list.Count} universities with FICT faculty:");
foreach (var u in list) Console.WriteLine(u);

//await universityService.DeleteUniversityAsync(uni.Id, uni.Faculty.Name);
//Console.WriteLine("Deleted sample university.");
