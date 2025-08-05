using CosmosUniversitiesApp.Models;
using Microsoft.Azure.Cosmos;

namespace CosmosUniversitiesApp
{
    public class UniversityService(Container cosmosContainer)
    {
        public async Task UpsertUniversityAsync(University uni)
        {
            if (cosmosContainer == null) throw new InvalidOperationException("Container not initialized.");
            try
            {
                //Console.WriteLine($"PartitionKey from uni.Faculty.Name: '{uni.Faculty.Name}'");
                //Console.WriteLine($"uni: '{uni}'");

                var response = await cosmosContainer.CreateItemAsync(uni, new PartitionKey(uni.Faculty.Name));
                Console.WriteLine($"Upsert succeeded: {response.StatusCode}");
                Console.WriteLine($"Upserted item with RU charge: {response.RequestCharge}");

            }
            catch (CosmosException ex)
            {
                Console.WriteLine("CosmosException:");
                Console.WriteLine($"StatusCode: {ex.StatusCode}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"ActivityId: {ex.ActivityId}");
                Console.WriteLine($"RequestCharge: {ex.RequestCharge}");
                Console.WriteLine($"InnerException: {ex.InnerException}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception:");
                Console.WriteLine(ex);
            }
        }

        public async Task<List<University>> QueryByFacultyAsync(string faculty)
        {
            if (cosmosContainer == null) throw new InvalidOperationException("Container not initialized.");
            var sql = "SELECT * FROM c WHERE c.faculty.name = @faculty";
            var query = new QueryDefinition(sql).WithParameter("@faculty", faculty);
            var results = new List<University>();
            var iterator = cosmosContainer.GetItemQueryIterator<University>(query);
            while (iterator.HasMoreResults)
            {
                var batch = await iterator.ReadNextAsync();
                Console.WriteLine($"Query RU charge: {batch.RequestCharge}");
                results.AddRange(batch);
            }
            return results;
        }

        public async Task DeleteUniversityAsync(string id, string facultyName)
        {
            if (cosmosContainer == null) throw new InvalidOperationException("Container not initialized.");
            var response = await cosmosContainer.DeleteItemAsync<University>(id, new PartitionKey(facultyName));
            Console.WriteLine($"Deleted id={id} with RU charge: {response.RequestCharge}");
        }
    }
}