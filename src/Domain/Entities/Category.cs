using System.Collections.Generic;
using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}