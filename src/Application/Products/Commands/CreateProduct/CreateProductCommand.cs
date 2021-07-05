using MediatR;

namespace Grocery.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string SKU { get; set; }
        public string IDSKU { get; set; }
        public string VendorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public int QuantityInStock { get; set; }
        public int PricePerUnit { get; set; }
        public int Discount { get; set; }
    }
}