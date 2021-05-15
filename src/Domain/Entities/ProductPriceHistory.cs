using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class ProductPriceHistory : IEntity<long>
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public long CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public decimal? Price { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTimeOffset? SpecialPriceStart { get; set; }
        public DateTimeOffset? SpecialPriceEnd { get; set; }
        public bool IsPriceChange { get; set; }
    }
}