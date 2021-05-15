using System;
using Grocery.Domain.Common;
using Grocery.Domain.Enums;

namespace Grocery.Domain.Entities
{
    public class UserAddress : IEntity<long>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public AddressType AddressType { get; set; }
        public DateTimeOffset? LastUsedOn { get; set; }
    }
}