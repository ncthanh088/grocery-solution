using System;

namespace Grocery.Domain.Entities
{
    public class AuditEntity
    {
        public long CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}