using System;
using System.Collections.Generic;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Promotion : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool ApplyForAll { get; set; }
        public float DiscountPercent { get; set; }
        public int DiscountAmount { get; set; }
        public string Status { get; set; }
    }
}