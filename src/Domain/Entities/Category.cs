using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Category : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }
    }
}