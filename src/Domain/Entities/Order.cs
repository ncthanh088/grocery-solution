using System;

namespace Grocery.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public int PaymentId { get; set; }
        public int ShipperId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Freight { get; set; } // VN: Cước vận chuyển
        public int Tax { get; set; }
        public bool Paid { get; set; }
        public bool Deleted { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}