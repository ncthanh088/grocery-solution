using System.Collections.Generic;
using Grocery.Domain.Common;
namespace Grocery.Domain.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPublished { get; set; }
        public bool IncludeInMenu { get; set; }
        public bool IsDeleted { get; set; }
        public long? ParentId { get; set; }
        public Category Parent { get; set; }
        public IList<Category> Children { get; protected set; } = new List<Category>();
        public Media ThumbnailImage { get; set; }
    }
}