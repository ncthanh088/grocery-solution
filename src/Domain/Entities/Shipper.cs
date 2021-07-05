using System.Collections.Generic;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Shipper : IEntity<int>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}