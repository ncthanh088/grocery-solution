using System;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class UserAddress 
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
        public DateTimeOffset? LastUsedOn { get; set; }
    }
}