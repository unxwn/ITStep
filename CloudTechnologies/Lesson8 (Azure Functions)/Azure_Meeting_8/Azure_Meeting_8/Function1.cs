using Azure;
using Azure.Data.Tables;
using Azure.Storage.Queues;
using Azure_Meeting_8.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using System.Text.Json;

namespace Azure_Meeting_8
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
        }
        //api/go?href=https://learn.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-guide?tabs=ihostapplicationbuilder%2Cwindows
        //[Function("Set")]
        //public async Task<IActionResult> Run(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        //{
        //    string redirectBaseUrl = "http://localhost:7058/api/Go/";
        //    string? href = req.Query["href"];
        //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    dynamic data = JsonConvert.DeserializeObject(requestBody)!;
        //    href = href ?? data?.href;
        //    _logger.LogInformation("C# HTTP trigger function processed a request.");
        //    if (href is null)
        //        //return new OkObjectResult($"You submit href: {href}");
        //        return new BadRequestObjectResult(new
        //        {
        //            error = "You should submit href param either via query or via request body"
        //        });
        //    UrlKey? urlKey;
        //    NullableResponse<UrlKey> resp = await tableClient.GetEntityIfExistsAsync<UrlKey>("1", "Key");
        //    if (!resp.HasValue)
        //    {
        //        urlKey = new UrlKey
        //        {
        //            Id = 1024,
        //            PartitionKey = "1",
        //            RowKey = "Key"
        //        };
        //        await tableClient.UpsertEntityAsync<UrlKey>(urlKey);
        //    }
        //    else
        //        urlKey = resp.Value;
        //    const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    string? code = string.Empty;
        //    int index = urlKey!.Id;
        //    while (index > 0)
        //    {
        //        code += alphabet[index % alphabet.Length];
        //        index = index / alphabet.Length;
        //    }
        //    code = new string(code.ToArray().Reverse().ToArray());
        //    UrlData urlData = new UrlData
        //    {
        //        RowKey = code!,
        //        PartitionKey = code![0].ToString(),
        //        Url = href,
        //        Count = 0,
        //    };
        //    await tableClient.UpsertEntityAsync(urlData);
        //    urlKey.Id++;
        //    await tableClient.UpsertEntityAsync(urlKey);
        //    return new OkObjectResult(
        //        new
        //        {
        //            code = urlData.RowKey,
        //            shortUrl = $"{redirectBaseUrl}{urlData.RowKey}",
        //            Url = href
        //        });
        //}

        [Function("Create")]
        public async Task<IActionResult> Create(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
           [TableInput("shortUrls")]TableClient inTableClient)
        {
            string redirectBaseUrl = "http://localhost:7058/api/Go/";
            string? href = req.Query["href"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody)!;
            href = href ?? data?.href;
            _logger.LogInformation("C# HTTP trigger function processed a request.");
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
                urlKey = resp.Value;
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string? code = string.Empty;
            int index = urlKey!.Id;
            while (index > 0)
            {
                code += alphabet[index % alphabet.Length];
                index = index / alphabet.Length;
            }
            code = new string(code.ToArray().Reverse().ToArray());
            UrlData urlData = new UrlData
            {
                RowKey = code!,
                PartitionKey = code![0].ToString(),
                Url = href,
                Count = 0,
            };
            await inTableClient.UpsertEntityAsync(urlData);
            urlKey.Id++;
            await inTableClient.UpsertEntityAsync(urlKey);
            return new OkObjectResult(
                new
                {
                    code = urlData.RowKey,
                    shortUrl = $"{redirectBaseUrl}{urlData.RowKey}",
                    Url = href
                });
        }


        // /api/go/bnk
        //[Function("Go")]
        //public async Task<IActionResult> Go(
        //    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "go/{shortUrl}")] HttpRequest req,
        //    [TableInput("shortUrls")] TableClient innerTableClient,
        //    string shortUrl
        //    )
        //{
        //    if (string.IsNullOrWhiteSpace(shortUrl))
        //    {
        //        return new BadRequestObjectResult(
        //            new
        //            {
        //                error = "You should provide short code in third route segment"
        //            });
        //    };
        //    shortUrl = shortUrl.ToUpper();
        //    string url = "https://lb.itstep.org/attendance";

        //    //// Version without input binding
        //    //NullableResponse<UrlData> resp = await tableClient
        //    //    .GetEntityIfExistsAsync<UrlData>($"{shortUrl[0]}", shortUrl);

        //    //if (resp.HasValue && resp.Value is UrlData urlData)
        //    //{
        //    //    url = urlData.Url;
        //    //    string convertedCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlData.RowKey));
        //    //    await queueClient.SendMessageAsync(convertedCode);          
        //    //}

        //    //// Version with input binding
        //    NullableResponse<UrlData> resp = await innerTableClient
        //        .GetEntityIfExistsAsync<UrlData>($"{shortUrl[0]}", shortUrl);

        //    if (resp.HasValue && resp.Value is UrlData urlData)
        //    {
        //        url = urlData.Url;
        //        string convertedCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlData.RowKey));
        //        await queueClient.SendMessageAsync(convertedCode);
        //    }
        //    return new RedirectResult(url);

        //}

        [Function("Go2")]
        public async Task<RedirectOutputType> Go2(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "go2/{shortUrl}")] HttpRequest req,
           [TableInput("shortUrls")] TableClient innerTableClient,
           string shortUrl
           )
        {
            RedirectOutputType outputType;
            if (string.IsNullOrWhiteSpace(shortUrl))
            {
                outputType = new RedirectOutputType
                {
                    Result = new BadRequestObjectResult(
                    new
                    {
                        error = "You should provide short code in third route segment"
                    })
                };
                return outputType;
            };
            shortUrl = shortUrl.ToUpper();
            string url = "https://lb.itstep.org/attendance";

            //// Version without input binding
            //NullableResponse<UrlData> resp = await tableClient
            //    .GetEntityIfExistsAsync<UrlData>($"{shortUrl[0]}", shortUrl);

            //if (resp.HasValue && resp.Value is UrlData urlData)
            //{
            //    url = urlData.Url;
            //    string convertedCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlData.RowKey));
            //    await queueClient.SendMessageAsync(convertedCode);          
            //}

            //// Version with input binding
            NullableResponse<UrlData> resp = await innerTableClient
                .GetEntityIfExistsAsync<UrlData>($"{shortUrl[0]}", shortUrl);
            outputType = new RedirectOutputType();
            if (resp.HasValue && resp.Value is UrlData urlData)
            {
                url = urlData.Url;
                //string convertedCode = Convert.ToBase64String(Encoding.UTF8.GetBytes(urlData.RowKey));
                //await queueClient.SendMessageAsync(convertedCode);
                outputType.Message = urlData.RowKey;
            }
            outputType.Result = new RedirectResult(url);
            return outputType;

        }

        [Function("Count")]
        public async Task Count(
            [QueueTrigger("counts")] string shortCode,
            [TableInput("shortUrls")]TableClient inTableClient
            )
        {
            _logger.LogWarning($"Short Code: {shortCode}");
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
