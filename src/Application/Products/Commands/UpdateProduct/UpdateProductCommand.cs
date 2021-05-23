using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Grocery.Domain.Entities;
using Grocery.Domain.Exceptions;
using Grocery.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Grocery.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public bool IsPublished { get; set; }
        public DateTimeOffset? PublishedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public bool HasOptions { get; set; }
        public bool IsVisibleIndividually { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsCallForPricing { get; set; }
        public bool IsAllowToOrder { get; set; }
        public bool StockTrackingIsEnabled { get; set; }
        public int StockQuantity { get; set; }
        public string NormalizedName { get; set; }
        public int DisplayOrder { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public IList<long> CategoryIds { get; set; } = new List<long>();
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
            var product = _context.Products
                .Include(x => x.ThumbnailImage)
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                throw new EntityNotFoundException(typeof(Product).Name, product);
            }

            product.Name = request.Name;
            product.ShortDescription = request.ShortDescription;
            product.Description = request.Description;
            product.Price = request.Price;
            product.OldPrice = request.OldPrice;
            product.SpecialPrice = request.SpecialPrice;
            product.SpecialPriceStart = request.SpecialPriceStart;
            product.SpecialPriceEnd = request.SpecialPriceEnd;
            product.BrandId = request.BrandId;

            UpdateProductCategories(request, product);

            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }

        // TODO: Move code below to ProductCategory module?
        private void UpdateProductCategories(UpdateProductCommand request, Product product)
        {
            foreach (var categoryId in request.CategoryIds)
            {
                if (product.Categories.Any(x => x.CategoryId == categoryId))
                {
                    continue;
                }

                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            var deletedProductCategories =
                product.Categories.Where(productCategory => !request.CategoryIds.Contains(productCategory.CategoryId))
                    .ToList();

            foreach (var deletedProductCategory in deletedProductCategories)
            {
                deletedProductCategory.Product = null;
                product.Categories.Remove(deletedProductCategory);
                _context.ProductCategories.Remove(deletedProductCategory);
            }
        }
    }
}