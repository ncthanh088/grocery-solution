using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Services.Abstractions;
using MediatR;

namespace Grocery.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public string SaleTitle { get; set; }
        public string SaleDescription { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        IProductService _productService;
        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.CreateProductAsync(request, cancellationToken);
        }
    }
}