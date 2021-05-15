using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class OrderItem : IEntity<long>
    {
        public long Id { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxPercent { get; set; }
    }
}