namespace Grocery.Domain.Entities
{
    public class OrderAddress
    {
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public long? DistrictId { get; set; }
        public District District { get; set; }
        public long StateOrProvinceId { get; set; }
        public StateOrProvince StateOrProvince { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
    }
}