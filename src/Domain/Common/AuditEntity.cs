using System;

namespace Grocery.Domain.Entities
{
    public class AuditEntity
    {
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}