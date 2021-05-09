using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Services.Abstractions;
using MediatR;

namespace Grocery.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public string Detail { get; set; }
        public string Description { get; set; }
        public string SaleTitle { get; set; }
        public string SaleDescription { get; set; }
        public Guid LanguageId { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        IProductService _productService;
        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.UpdateProductAsync(request, cancellationToken);
        }
    }
}