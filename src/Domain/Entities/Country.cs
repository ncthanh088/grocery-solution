using System.Collections.Generic;

namespace Grocery.Domain.Entities
{
    public class Country
    {
        public string Name { get; set; }
        public string Code3 { get; set; }
        public bool IsBillingEnabled { get; set; }
        public bool IsShippingEnabled { get; set; }
        public bool IsCityEnabled { get; set; } = true;
        public bool IsZipCodeEnabled { get; set; } = true;
        public bool IsDistrictEnabled { get; set; } = true;
        public IList<StateOrProvince> StatesOrProvinces { get; set; } = new List<StateOrProvince>();
    }
}