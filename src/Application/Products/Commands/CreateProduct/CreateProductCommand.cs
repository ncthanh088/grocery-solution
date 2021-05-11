using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Grocery.Domain.Entities;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands.CreateProduct
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
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                CreateAt = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Detail = request.Detail,
                        SaleDescription = request.SaleDescription,
                        SaleTitle = request.SaleTitle,
                    }
                }
            };

            _context.Products.Add(product);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}