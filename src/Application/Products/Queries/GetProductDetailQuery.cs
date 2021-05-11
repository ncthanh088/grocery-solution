using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Products.Models;
using Grocery.Application.Common.Interfaces;
using Grocery.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
namespace Grocery.Application.Products.Queries
{
    public class GetProductDetailQuery : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }
    }

    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDto>
    {
        private readonly IApplicationDbContext _context;
        public GetProductDetailQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products
                                        .Where(x => x.Id == request.ProductId)
                                        .OrderBy(x => x.CreateAt)
                                        .FirstOrDefaultAsync();

            if (productEntity == null)
            {
                throw new EntityNotFoundException();
            }

            return ProductDto.Create(productEntity);
        }
    }
}