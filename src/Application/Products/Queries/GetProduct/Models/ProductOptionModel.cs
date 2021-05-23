using System.Collections.Generic;

namespace Grocery.Application.Products.Queries.GetProduct.Models
{
    public class ProductOptionModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DisplayType { get; set; }
        public IList<ProductOptionValueModel> Values { get; set; } = new List<ProductOptionValueModel>();
    }
}