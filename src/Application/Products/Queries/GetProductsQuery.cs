using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Common.Models;
using Grocery.Application.Products.Models;
using Grocery.Application.Services.Abstractions;
using MediatR;

namespace Grocery.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<PaginatedList<ProductModel>>
    {
        public string Criteria { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductModel>>
    {
        private readonly IProductService _productService;

        public GetProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<PaginatedList<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductsAsync(request, cancellationToken);
        }
    }
}