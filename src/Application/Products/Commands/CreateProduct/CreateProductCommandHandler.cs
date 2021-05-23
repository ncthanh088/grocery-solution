using MediatR;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Grocery.Domain.Enums;
using Grocery.Domain.Entities;
using Grocery.Application.Common.Interfaces;
using Grocery.Application.Services.Abstractions;

namespace Grocery.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediaService _mediaService;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                ShortDescription = request.ShortDescription,
                Description = request.Description,
                Price = request.Price,
                OldPrice = request.OldPrice,
                SpecialPrice = request.SpecialPrice,
                SpecialPriceStart = request.SpecialPriceStart,
                SpecialPriceEnd = request.SpecialPriceEnd,
                BrandId = request.BrandId
            };

            await AddMediaInfo(request, product);

            AddProductCategories(request, product);

            _context.Products.Add(product);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        private async Task AddMediaInfo(CreateProductCommand request, Product product)
        {
            if (request.ThumbnailImageUrl != null)
            {
                var thumbnailImageFileName = await SaveFile(request.ThumbnailImage);
                if (product.ThumbnailImage != null)
                {
                    product.ThumbnailImage.FileName = thumbnailImageFileName;
                }
                else
                {
                    product.ThumbnailImage = new Media { FileName = thumbnailImageFileName };
                }
            }

            foreach (var image in request.NewImages)
            {
                var fileName = await SaveFile(image);
                var productMedia = new ProductMedia
                {
                    Product = product,
                    Media = new Media { FileName = fileName, MediaType = MediaType.Image }
                };

                product.AddMedia(productMedia);
            }
        }

        private static void AddProductCategories(CreateProductCommand request, Product product)
        {
            foreach (var categoryId in request.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}