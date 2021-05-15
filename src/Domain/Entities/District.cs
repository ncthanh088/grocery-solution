using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class District : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public long StateOrProvinceId { get; set; }
        public StateOrProvince StateOrProvince { get; set; }
    }
}