using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Language : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}