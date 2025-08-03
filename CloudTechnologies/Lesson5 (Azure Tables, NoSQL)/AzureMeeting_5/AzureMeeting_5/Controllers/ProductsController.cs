using AzureMeeting_5.Models;
using AzureMeeting_5.Models.DTOs;
using AzureMeeting_5.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AzureMeeting_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(
        ITableStorageService<Product> storageService
            ) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PostProduct(ProductDTO dTO)
        {
            Product product = new()
            {
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = dTO.Category,
                Category = dTO.Category,
                Price = dTO.Price,
                Name = dTO.Name,
            };
            await storageService.UpsertEntityAsync( product );
            return Ok( product );
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync() {
            IEnumerable<Product> products = await storageService.GetEntitiesAsync(category: null);
            return Ok( products );
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetProductsAsync(string? category)
        {
            IEnumerable<Product> products = await storageService.GetEntitiesAsync(category);
            return Ok(products);
        }

        [HttpGet("{category}/{id}")]
        public async Task<IActionResult> GetProductsAsync(string category, string id)
        {
            Product product = await storageService.GetEntityAsync(category, id);
            return Ok(product);
        }

        //[HttpPut]
        //public async Task<IActionResult> PutProduct(Product product)
        //{
        //    Product editedProduct = await storageService
        //        .GetEntity(product.RowKey, product.PartitionKey);
        //    editedProduct.Price = product.Price;
        //    editedProduct.Name = product.Name;
        //    await storageService.UpsertEntity(editedProduct);
        //    return Ok( product );
        //}

        [HttpPut("{category}/{id}")]
        public async Task<IActionResult> PutProduct(string category, string id,
            [FromBody]ProductDTO dTO)
        {
            Product editedProduct = await storageService
                .GetEntityAsync(category, id);
            editedProduct.Price = dTO.Price;
            editedProduct.Name = dTO.Name;
            await storageService.UpsertEntityAsync(editedProduct);
            return Ok(editedProduct);
        }

        [HttpDelete("{category}/{id}")]
        public async Task<IActionResult> DeleteProduct(string category, string id)
        {
            bool isSuccess = await storageService.DeleteEntityAsync(rowKey: id, category: category);
            return Ok(isSuccess);
        }
    }
}
