using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // TODO: create a transaction to delete a Product and Product Translation
            var productEntity = await _context.Products.FindAsync(request.Id);

            if (productEntity == null)
            {
                throw new EntityNotFoundException();
            }

            _context.Products.Remove(productEntity);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}