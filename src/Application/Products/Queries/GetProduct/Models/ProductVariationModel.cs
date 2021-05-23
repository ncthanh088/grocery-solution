namespace Grocery.Application.Products.Queries.GetProduct.Models
{
    public class ProductVariationModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string Sku { get; set; }
        public string Gtin { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }

    }
}