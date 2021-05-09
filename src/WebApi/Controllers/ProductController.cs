using System;
using System.Threading.Tasks;
using Grocery.Application.Products.Commands;
using Grocery.Application.Products.Queries;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductByIdAsync(Guid id)
        {
            var request = new DeleteProductCommand() { Id = id };
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(Guid id, UpdateProductCommand request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(request);

            return Ok(response);
        }
    }
}