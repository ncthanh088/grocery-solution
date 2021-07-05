using System;

namespace Grocery.Domain.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int OrderNumber { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int IDSKU { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }

    }
}