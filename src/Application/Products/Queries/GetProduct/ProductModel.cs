using System;
using System.Linq.Expressions;
using Grocery.Domain.Entities;

namespace Grocery.Application.Products.Queries.GetProduct
{
    public class ProductModel
    {
        public string SKU { get; set; }
        public string IDSKU { get; set; }
        public string VendorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public int CatalogId { get; set; }
        public int QuantityInStock { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal Discount { get; set; }

        public static Expression<Func<Product, ProductModel>> Projection
        {
            get
            {
                return product => new ProductModel
                {
                    SKU = product.SKU,
                    IDSKU = product.IDSKU,
                    VendorId = product.VendorId,
                    Name = product.Name,
                    Description = product.Description,
                    SupplierId = product.SupplierId,
                    CatalogId = product.CategoryId,
                    QuantityInStock = product.QuantityInStock,
                    PricePerUnit = product.PricePerUnit,
                    Discount = product.Discount,
                };
            }
        }

        public static ProductModel Create(Product product)
        {
            if (product is null)
                return null;
            return Projection.Compile().Invoke(product);
        }
    }
}