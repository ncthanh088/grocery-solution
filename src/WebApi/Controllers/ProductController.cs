using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grocery.Application.Products.Queries;
using Grocery.Application.Products.Commands.CreateProduct;
using Grocery.Application.Products.Commands.DeleteProduct;
using Grocery.Application.Products.Commands.UpdateProduct;
using Grocery.Application.Products.Commands.UpdateProductPrice;

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

        [HttpPut("{id}/price/{newPrice}")]
        public async Task<ActionResult> UpdatePriceAsync([FromQuery] Guid id, float newPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = await Mediator.Send(request: new UpdateProductPriceCommand() { ProductId = id, Price = newPrice });

            return Ok(response);
        }
    }
}