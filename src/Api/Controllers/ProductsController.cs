using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Grocery.Application.Products.Queries.GetProduct;
using Grocery.Application.Products.Commands.CreateProduct;

namespace Grocery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductModel>> Get(int id)
        {
            var response = await _mediator.Send(request: new GetProductQuery { Id = id });

            return base.Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}