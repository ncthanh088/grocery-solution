namespace Grocery.Domain.Entities
{
    public class ProductCategory
    {
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}