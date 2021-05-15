using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
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
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException();
            }

            _context.Products.Remove(product);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}