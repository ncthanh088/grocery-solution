using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands.UpdateProductPrice
{
    public class UpdateProductPriceCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public float Price { get; set; }
    }

    public class UpdateProductPriceCommandHandler : IRequestHandler<UpdateProductPriceCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductPriceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductPriceCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(request.ProductId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, request.ProductId);
            }

            productEntity.Price = request.Price;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}