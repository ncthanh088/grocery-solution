using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ShipperId { get; set; }
        public Shipper Shipper { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Freight { get; set; }  // payment to shipper
        public decimal Tax { get; set; }
        public bool Paid { get; set; }
        public bool Deleted { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}