using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Brand : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }       
    }
}