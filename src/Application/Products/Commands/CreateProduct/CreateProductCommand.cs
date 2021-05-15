using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Grocery.Domain.Entities;
using Grocery.Application.Common.Interfaces;

namespace Grocery.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
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
        public IList<int> CategoryIds { get; set; } = new List<int>();
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IApplicationDbContext _context;
        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                MetaTitle = request.MetaTitle,
                MetaKeywords = request.MetaKeywords,
                MetaDescription = request.MetaDescription,
                ShortDescription = request.ShortDescription,
                Description = request.Description,
                Specification = request.Specification,
                Price = request.Price,
                OldPrice = request.OldPrice,
                SpecialPrice = request.SpecialPrice,
                SpecialPriceStart = request.SpecialPriceStart,
                SpecialPriceEnd = request.SpecialPriceEnd,
                IsPublished = request.IsPublished,
                IsFeatured = request.IsFeatured,
                IsCallForPricing = request.IsCallForPricing,
                IsAllowToOrder = request.IsAllowToOrder,
                BrandId = request.BrandId,
                StockTrackingIsEnabled = request.StockTrackingIsEnabled,
                IsVisibleIndividually = true
            };

            foreach (var categoryId in request.CategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = categoryId
                };
                product.AddCategory(productCategory);
            }

            _context.Products.Add(product);
            
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}