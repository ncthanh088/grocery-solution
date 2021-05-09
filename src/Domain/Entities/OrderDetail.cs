using System;

namespace Grocery.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}