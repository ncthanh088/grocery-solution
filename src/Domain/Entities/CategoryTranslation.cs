using System;
using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class CategoryTranslation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string SaleDescription { get; set; }
        public string SaleTitle { get; set; }
        public Guid LanguageId { get; set; }
    }
}