using Azure;
using Azure.Data.Tables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using urlCutter.Models;

namespace urlCutter
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        //private readonly TableClient tableClient;
        //private readonly QueueClient queueClient;

        public Function1(ILogger<Function1> logger
            //IAzureClientFactory<TableServiceClient> tableServiceFactory,
            //IAzureClientFactory<QueueServiceClient> queueServiceFactory
            )
        {
            _logger = logger;
            //TableServiceClient tableServiceClient = tableServiceFactory.CreateClient("myTableClient");
            //tableClient = tableServiceClient.GetTableClient("shortUrls");
            //tableClient.CreateIfNotExists();
            //QueueServiceClient queueServiceClient = queueServiceFactory.CreateClient("myQueueClient");
            //queueClient = queueServiceClient.GetQueueClient("counts");
            //queueClient.CreateIfNotExists();
            //!!! DI замінене на Binding parameters в методах
        }

        [Function("Create")]
        public async Task<IActionResult> Create(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
           [TableInput("shortUrls")] TableClient inTableClient)
        {
            string redirectBaseUrl = "http://localhost:7058/api/GoTo/";
            string? href = req.Query["href"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody)!;
            href ??= data?.href;
            _logger.LogInformation("C# 'Create' HTTP Trigger Function processed a request.");
            if (href is null)
                //return new OkObjectResult($"You submit href: {href}");
                return new BadRequestObjectResult(new
                {
                    error = "You should submit href param either via query or via request body"
                });
            UrlKey? urlKey;
            NullableResponse<UrlKey> resp = await inTableClient.GetEntityIfExistsAsync<UrlKey>("1", "Key");
            if (!resp.HasValue)
            {
                urlKey = new UrlKey
                {
                    Id = 1024,
                    PartitionKey = "1",
                    RowKey = "Key"
                };
                await inTableClient.UpsertEntityAsync(urlKey);
            }
            else
            {
                urlKey = resp.Value;
            }

            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string? urlCode = string.Empty;
            int index = urlKey!.Id;

            while (index > 0)
            {
                urlCode += alphabet[index % alphabet.Length];
                index /= alphabet.Length;
            }

            urlCode = new string(urlCode.ToArray().Reverse().ToArray());
            UrlData urlData = new UrlData
            {
                RowKey = urlCode!,
                PartitionKey = urlCode![0].ToString(),
                Url = href,
                Count = 0,
            };

            await inTableClient.UpsertEntityAsync(urlData);

            urlKey.Id++;
            await inTableClient.UpsertEntityAsync(urlKey);

            return new OkObjectResult(
                new
                {
                    urlCode = urlData.RowKey,
                    shortUrl = $"{redirectBaseUrl}{urlData.RowKey}",
                    originalUrl = href
                });
        }

        [Function("GoTo")]
        public async Task<RedirectOutputType> GoTo(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "GoTo/{shortUrl}")] HttpRequest req,
           [TableInput("shortUrls")] TableClient innerTableClient,
           string shortUrl
           )
        {
            
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                return new RedirectOutputType
                {
                    Result = new BadRequestObjectResult(
                    new
                    {
                        error = "You must provide a short code in third route segment."
                    })
                };
            }

            shortUrl = shortUrl.ToUpper();

            NullableResponse<UrlData> resp = await innerTableClient
                .GetEntityIfExistsAsync<UrlData>($"{shortUrl[0]}", shortUrl);

            if (!(resp.HasValue && resp.Value is UrlData urlData))
            {
                return new RedirectOutputType
                {
                    Result = new BadRequestObjectResult(
                    new
                    {
                        error = "The provided short code does not exist."
                    })
                };
            }

            //string convertedCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlData.RowKey));
            //await queueClient.SendMessageAsync(convertedCode);
            return new RedirectOutputType
            {
                Message = urlData.RowKey,
                Result = new RedirectResult(urlData.Url)
            };
        }

        [Function("Count")]
        public async Task Count(
            [QueueTrigger("counts")] string shortCode,
            [TableInput("shortUrls")] TableClient inTableClient
            )
        {
            _logger.LogInformation($"C# 'Count' Queue Trigger Function processed a message. Short Code: {shortCode}");
            
            NullableResponse<UrlData> resp = await inTableClient
                .GetEntityIfExistsAsync<UrlData>($"{shortCode[0]}", shortCode);

            if (resp.HasValue && resp.Value is UrlData urlData)
            {
                urlData.Count++;
                await inTableClient.UpsertEntityAsync(urlData);
            }
        }
    }
}
