using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Application.Products.Commands.UpdateProduct
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
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(request.Id);
            var productTranslationEntity = await _context.ProductTranslations
                    .FirstOrDefaultAsync(x => x.ProductId.Equals(request.Id) && x.LanguageId.Equals(request.LanguageId));

            if (productEntity == null || productTranslationEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, request.Id);
            }

            _context.ProductTranslations.Update(new ProductTranslation
            {
                Name = request.Name,
                Detail = request.Detail,
                Description = request.Description,
                SaleTitle = request.SaleTitle,
                SaleDescription = request.SaleDescription
            });

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}