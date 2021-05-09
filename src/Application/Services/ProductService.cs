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

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<bool> DeleteProductAsync(Guid productId, CancellationToken cancellationToken)
        {
            // TODO: create a transaction to delete a Product and Product Translation
            var productEntity = await _context.Products.FindAsync(productId);

            if (productEntity == null)
            {
                throw new EntityNotFoundException();
            }

            _context.Products.Remove(productEntity);

            var result = await _context.SaveChangesAsync(cancellationToken);

            return result > 0;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var productEntity = await _context.Products
                                    .Where(x => x.Id == productId)
                                    .OrderBy(x => x.CreateAt)
                                    .FirstOrDefaultAsync();

            if (productEntity == null)
            {
                throw new EntityNotFoundException();
            }

            return ProductDto.Create(productEntity);
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