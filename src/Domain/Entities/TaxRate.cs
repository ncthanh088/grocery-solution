using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class TaxRate : IEntity<long>
    {
        public long Id { get; set; }
        public long TaxId { get; set; }
        public Tax Tax { get; set; }
        public string CountryId { get; set; }
        public Country Country { get; set; }
        public long? StateOrProvinceId { get; set; }
        public StateOrProvince StateOrProvince { get; set; }
        public decimal Rate { get; set; }
        public string ZipCode { get; set; }
    }
}