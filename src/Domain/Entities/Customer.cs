using System.Collections.Generic;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Customer : IEntity<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int OrderId { get; set; }
        public ICollection<Order> Order { get; set; }    
    }
}