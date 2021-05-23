namespace Grocery.Application.Products.Queries.GetProduct.Models
{
    public class ProductOptionCombinationVm
    {
        public long OptionId { get; set; }
        public string OptionName { get; set; }
        public string Value { get; set; }
        public int SortIndex { get; set; }
    }
}