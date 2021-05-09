using System;

namespace Grocery.Application.Products.Models
{
    public class ProductModel : ProductDto
    {        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public string SaleDescription { get; set; }
        public string SaleTitle { get; set; }
        public Guid LanguageId { get; set; }
    }
}