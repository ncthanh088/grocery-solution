using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Grocery.Domain.Enums;
using Grocery.Application.Common.Interfaces;
using Grocery.Application.Products.Queries.GetProduct.Models;

namespace Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductModel>
    {
        public long Id { get; set; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductModel>
    {
        private readonly IApplicationDbContext _context;
        public async Task<ProductModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Medias).ThenInclude(m => m.Media)
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            var productModel = new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                OldPrice = product.OldPrice,
                Price = product.Price,
                SpecialPrice = product.SpecialPrice,
                SpecialPriceStart = product.SpecialPriceStart,
                SpecialPriceEnd = product.SpecialPriceEnd,
                CategoryIds = product.Categories.Select(x => x.CategoryId).ToList(),
                BrandId = product.BrandId,
                TaxId = product.TaxId
            };

            foreach (var productMedia in product.Medias.Where(x => x.Media.MediaType == MediaType.Image))
            {
                productModel.ProductImages.Add(new ProductMediaModel
                {
                    Id = productMedia.Id,
                    //MediaUrl = _mediaService.GetThumbnailUrl(productMedia.Media)
                });
            }

            return productModel;
        }
    }
}