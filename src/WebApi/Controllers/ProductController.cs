using System;
using System.Threading.Tasks;
using Grocery.Application.Products.Commands;
using Grocery.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Grocery.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailAsync(Guid id)
        {
            var request = new GetProductDetailQuery() { ProductId = id };
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetProductsAsync([FromBody] GetProductsQuery request)
        {
            var response = await Mediator.Send(request);
            
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand request)
        {
            var response = await Mediator.Send(request);
                        
            return Ok(response);
        }
    }
}