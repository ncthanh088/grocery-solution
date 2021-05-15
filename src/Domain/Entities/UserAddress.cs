using System;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class UserAddress
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
        public DateTimeOffset? LastUsedOn { get; set; }
    }
}