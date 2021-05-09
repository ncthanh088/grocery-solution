using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Products.Models;
using Grocery.Application.Services.Abstractions;

namespace Grocery.Application.Products.Queries
{
    public class GetProductDetailQuery : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDto>
    {
        private readonly IProductService _productService;

        public GetProductDetailQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            return await _productService.GetProductByIdAsync(request, cancellationToken);
        }
    }
}