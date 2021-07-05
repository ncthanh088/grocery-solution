using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Grocery.Application.Common.Exceptions;
using Grocery.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductModel>
    {
        private readonly IApplicationDbContext _context;

        public GetProductQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return ProductModel.Create(product);
        }
    }
}