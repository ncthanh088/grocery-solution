using System;
using System.Collections.Generic;
using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Product : AuditEntity, IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
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
        public long? VendorId { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }
        public long? BrandId { get; set; }
        public Brand Brand { get; set; }
        public Media ThumbnailImage { get; set; }       
        public IList<ProductCategory> Categories { get; protected set; } = new List<ProductCategory>();
        public IList<ProductPriceHistory> PriceHistories { get; protected set; } = new List<ProductPriceHistory>();
        
        public void AddCategory(ProductCategory category)
        {
            category.Product = this;
            Categories.Add(category);
        }
    }
}