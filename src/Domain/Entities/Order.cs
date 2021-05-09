using System;
using System.Collections.Generic;
using Grocery.Domain.Enums;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Order : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public OrderStatusEnum Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}