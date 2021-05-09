using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Common.Interfaces;
using Grocery.Application.Common.Models;
using Grocery.Application.Products.Commands;
using Grocery.Application.Products.Models;
using Grocery.Application.Products.Queries;
using Grocery.Application.Services.Abstractions;
using Grocery.Domain.Entities;
using Grocery.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _context;
        public ProductService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateProductAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                CreateAt = DateTime.Now,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name = request.Name,
                        Description = request.Description,
                        Detail = request.Detail,
                        SaleDescription = request.SaleDescription,
                        SaleTitle = request.SaleTitle,
                    }
                }
            };

            _context.Products.Add(product);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteProductAsync(DeleteProductCommand request, CancellationToken cancellationToken)
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

        public async Task<bool> UpdateProductAsync(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(request.Id);
            var productTranslationEntity = await _context.ProductTranslations.FirstOrDefaultAsync(
                    x => x.ProductId.Equals(request.Id) && x.LanguageId.Equals(request.LanguageId));

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

        public async Task<bool> UpdatePriceAsync(Guid productId, float newPrice, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(productId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, productId);
            }

            productEntity.Price = newPrice;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateStockAsync(Guid productId, int quantity, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(productId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, productId);
            }

            productEntity.Stock = quantity;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> UpdateViewCountAsync(Guid productId, int viewCount, CancellationToken cancellationToken)
        {
            var productEntity = await _context.Products.FindAsync(productId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, productId);
            }

            productEntity.ViewCount = viewCount;

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<ProductDto> GetProductByIdAsync(GetProductDetailQuery request, CancellationToken cancellationToken)
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

        public Task<PaginatedList<ProductModel>> GetProductsByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
            // TODO: use Query model or direct value to implement this function
            throw new NotImplementedException();
        }

        public async Task<PaginatedList<ProductModel>> GetProductsAsync(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        where pt.Name.Contains(request.Criteria)
                        select new { p, pt };

            if (!string.IsNullOrEmpty(request.Criteria))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Criteria));
            }

            var queryable = query.Select(x => new ProductModel
            {
                Id = x.p.Id,
                Name = x.pt.Name,
                Price = x.p.Price,
                OriginalPrice = x.p.OriginalPrice,
                Stock = x.p.Stock,
                Description = x.pt.Description,
                Detail = x.pt.Detail,
                SaleDescription = x.pt.SaleDescription,
                SaleTitle = x.pt.SaleTitle
            });

            return await PaginatedList<ProductModel>.CreateAsync(queryable, request.PageIndex, request.PageSize);
        }
    }
}