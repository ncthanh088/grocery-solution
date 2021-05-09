using System;
using Grocery.Domain.Enums;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Category : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public Guid ParentId { get; set; }
        public CategoryStatusEnum Status { get; set; }

    }
}