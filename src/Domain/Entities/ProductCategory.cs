namespace Grocery.Domain.Entities
{
    public class ProductCategory
    {
        public bool IsFeaturedProduct { get; set; }
        public int DisplayOrder { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}