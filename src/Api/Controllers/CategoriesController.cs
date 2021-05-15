using System.Threading.Tasks;
using Grocery.Application.Categories.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Grocery.Api.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController()
        {
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryCommand request)
        {
            var response = await Mediator.Send(request);

            return Ok(response);
        }
    }
}