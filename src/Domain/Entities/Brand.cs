using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Brand : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }       
    }
}