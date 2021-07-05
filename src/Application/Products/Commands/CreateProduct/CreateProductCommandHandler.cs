using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                VendorId = request.VendorId,
                SupplierId = request.SupplierId,
                CategoryId = request.CategoryId,
                PricePerUnit = request.PricePerUnit,
                QuantityInStock = request.QuantityInStock,
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}