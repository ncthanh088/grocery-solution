using MediatR;

namespace Grocery.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductModel>
    {
        public int Id { get; set; }
    }
}