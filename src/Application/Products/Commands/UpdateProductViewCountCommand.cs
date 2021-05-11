using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands
{
    public class UpdateProductViewCountCommand : IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public int ViewCount { get; set; }
    }

    public class UpdateProductViewCountCommandHandler : IRequestHandler<UpdateProductViewCountCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductViewCountCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductViewCountCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(request.ProductId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, request.ProductId);
            }

            productEntity.Stock = request.ViewCount;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}