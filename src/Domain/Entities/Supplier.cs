using System.Collections.Generic;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Supplier : IEntity<int>
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContractName { get; set; }
        public string ContractTitle { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string SiteUrl { get; set; } // Web Address
        public string PaymentMethods { get; set; }
        public string Logo { get; set; }
        public ICollection<Product> Porducts { get; set; }
    }
}