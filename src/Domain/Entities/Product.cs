using System;
using System.Collections.Generic;
using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Product : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public int StockQuantity { get; set; }
        public string NormalizedName { get; set; }
        public int ReviewsCount { get; set; }
        public double? RatingAverage { get; set; }
        public long? BrandId { get; set; }
        public Brand Brand { get; set; }
        public long? TaxId { get; set; }
        public Tax Tax { get; set; }
        public Media ThumbnailImage { get; set; }
        public IList<ProductMedia> Medias { get; protected set; } = new List<ProductMedia>();
        public IList<ProductCategory> Categories { get; protected set; } = new List<ProductCategory>();

        public void AddCategory(ProductCategory category)
        {
            category.Product = this;
            Categories.Add(category);
        }

        public void AddMedia(ProductMedia media)
        {
            media.Product = this;
            Medias.Add(media);
        }
    }
}