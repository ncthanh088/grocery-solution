using System;
using System.Collections.Generic;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class User : IEntity<long>
    {
        public long Id { get; set; }
        public Guid UserGuid { get; set; }
        public string FullName { get; set; }
        public long? VendorId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LatestUpdatedOn { get; set; }
        public IList<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
        public long? DefaultShippingAddressId { get; set; }
        public UserAddress DefaultShippingAddress { get; set; }
        public long? DefaultBillingAddressId { get; set; }
        public UserAddress DefaultBillingAddress { get; set; }
        public string RefreshTokenHash { get; set; }
        public IList<UserRole> Roles { get; set; } = new List<UserRole>();
        public string Culture { get; set; }
        public string ExtensionData { get; set; }        
    }
}