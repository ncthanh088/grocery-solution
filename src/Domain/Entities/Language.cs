using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class Language : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}