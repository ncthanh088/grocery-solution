using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class StateOrProvince : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public Country Country { get; set; }
    }
}