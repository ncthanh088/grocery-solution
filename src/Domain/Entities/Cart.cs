using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Cart : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}