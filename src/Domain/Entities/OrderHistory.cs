using System;
using Grocery.Domain.Common;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class OrderHistory : IEntity<int>
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public OrderStatus? OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public string OrderSnapshot { get; set; }
        public string Note { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public long CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }
}