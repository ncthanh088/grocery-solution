using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Product : IEntity<long>
    {
        public long Id { get; set; }
        public string SKU { get; set; }
        public string IDSKU { get; set; }
        public string VendorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SupplierId { get; set; }
        public string CatalogId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
    }
}