using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Address : IEntity<int>
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public long StateOrProvinceId { get; set; }
    }
}