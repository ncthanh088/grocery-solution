using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Tax : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}