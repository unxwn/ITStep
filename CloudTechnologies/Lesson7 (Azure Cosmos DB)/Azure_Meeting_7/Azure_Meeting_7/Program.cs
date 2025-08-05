// See https://aka.ms/new-console-template for more information
using Azure_Meeting_7.Models;
using Microsoft.Azure.Cosmos;
using System.Text;
Console.OutputEncoding = Encoding.UTF8;
string connStr = "AccountEndpoint=https://localhost:6500/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
string databaseId = "authorsDb";
string containerId = "authors";
CosmosClient cosmosClient = new CosmosClient(connStr);
Database database =  await cosmosClient.CreateDatabaseIfNotExistsAsync(id: databaseId);
Container container = await database.CreateContainerIfNotExistsAsync(id: containerId, partitionKeyPath: "/Surname");
Author author = new Author
{
    //Id = Guid.NewGuid().ToString(),
    Id = "abc7139f-621c-4902-96c9-ca689ff23b1c",
    Name = "Кліфорд",
    Surname = "Саймак",
    Country = new Country
    {
        Name = " США",
        PhoneCode = "+1",
    },
    YearOfBirth = 1903,
    Books = new List<Book>
    {
        new Book
        {
            Title = "Пересадочна станція",
            Pages = 345,
            YearOfPublish = 1956
        },
        new Book
        {
            Title = "Заповідник гоблінів",
            Pages = 412,
            YearOfPublish = 1962
        }
    }
};
//Author author = new Author
//{
//    Id = Guid.NewGuid().ToString(),
//    Name = "Джордж",
//    Surname = "Оруелл",
//    Country = new Country
//    {
//        Name = " США",
//        PhoneCode = "+1",
//    },
//    YearOfBirth = 1902,
//    Books = new List<Book>
//    {
//        new Book
//        {
//            Title = "1984",
//            Pages = 389,
//            YearOfPublish = 1949
//        },
//        new Book
//        {
//            Title = "Колгосп тварин",
//            Pages = 438,
//            YearOfPublish = 1956
//        }
//    }
//};
try
{
    ItemResponse<Author> itemResponse = await container.CreateItemAsync(author, new PartitionKey(author.Surname));
    Console.WriteLine($"Request Charge = ${itemResponse.RequestCharge} RU");
    Console.WriteLine($"Created item Id: {itemResponse.Resource.Id}");
}
catch (CosmosException cex)
when (cex.StatusCode == System.Net.HttpStatusCode.Conflict)
{
    Console.WriteLine("Такий елемент вже є у БД!");
}

//string query = "SELECT * FROM c WHERE c.Surname = 'Саймак'";
//string query = "SELECT * FROM c";
//QueryDefinition queryDefinition = new QueryDefinition(query);
//FeedIterator<Author>  feedIterator =  container.GetItemQueryIterator<Author>(queryDefinition);
//List<Author> authors = new List<Author>();
//while (feedIterator.HasMoreResults)
//{
//    FeedResponse<Author> feedResponse = await feedIterator.ReadNextAsync();
//    Console.WriteLine($"Request Charge:  {feedResponse.RequestCharge} RU");
//    foreach(var res in feedResponse)
//    {
//        authors.Add(res);
//    }
//}
//foreach(var author in authors)
//{
//    Console.WriteLine(author);
//    Console.WriteLine("-----------");
//}