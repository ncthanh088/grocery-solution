using Grocery.Domain.Common;

namespace Grocery.Domain.Entities
{
    public class ProductMedia : IEntity<long>
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long MediaId { get; set; }
        public Media Media { get; set; }
        public int DisplayOrder { get; set; }
    }
}