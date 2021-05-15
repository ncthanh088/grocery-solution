using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Language : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}