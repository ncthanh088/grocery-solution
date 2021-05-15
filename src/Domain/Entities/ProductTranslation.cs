using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class ProductTranslation : IEntity<int>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string SaleDescription { get; set; }
        public string SaleTitle { get; set; }
        public Guid LanguageId { get; set; }
    }
}