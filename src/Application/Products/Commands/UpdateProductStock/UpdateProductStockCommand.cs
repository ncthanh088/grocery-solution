using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands.UpdateProductStock
{
    public class UpdateProductStockCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateProductStockCommandHandler : IRequestHandler<UpdateProductStockCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductStockCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductStockCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(request.ProductId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, request.ProductId);
            }

            productEntity.Stock = request.Quantity;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}