using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grocery.Application.Products.Commands.CreateProduct;
using Grocery.Application.Products.Commands.DeleteProduct;
using Grocery.Application.Products.Commands.UpdateProduct;
namespace Grocery.Api.Controllers
{
    public class ProductsController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommand request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductByIdAsync(int id)
        {
            var request = new DeleteProductCommand() { Id = id };
            var response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductAsync(int id, UpdateProductCommand request)
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