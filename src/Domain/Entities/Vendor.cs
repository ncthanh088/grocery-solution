using System;
using System.Collections.Generic;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Vendor : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LatestUpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public IList<User> Users { get; set; } = new List<User>();
    }
}