using System.Collections.Generic;
using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string IDSKU { get; set; }
        public string VendorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int QuantityInStock { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Discount { get; set; }        
        public ICollection<OrderDetail> OrderDetails{ get; set; }
    }
}