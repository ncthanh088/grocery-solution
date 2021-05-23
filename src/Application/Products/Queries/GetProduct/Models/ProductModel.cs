using System;
using System.Collections.Generic;

namespace Grocery.Application.Products.Queries.GetProduct.Models
{
    public class ProductModel
    {
        public long Id { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public IList<long> CategoryIds { get; set; } = new List<long>();
        public string ThumbnailImageUrl { get; set; }
        public IList<ProductMediaModel> ProductImages { get; set; } = new List<ProductMediaModel>();
        public IList<ProductMediaModel> ProductDocuments { get; set; } = new List<ProductMediaModel>();
        public IList<long> DeletedMediaIds { get; set; } = new List<long>();
        public long? BrandId { get; set; }
        public long? TaxId { get; set; }
    }
}