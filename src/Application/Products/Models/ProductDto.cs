using System;
using System.Collections.Generic;
using Grocery.Domain.Entities;

namespace Grocery.Application.Products.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public float Price { get; set; }
        public float OriginalPrice { get; set; }
        public int Stock { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateAt { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<ProductTranslation> ProductTranslations { get; set; }
        public static ProductDto Create(Product productEntity)
        {
            return new ProductDto
            {
                Id = productEntity.Id,
                Price = productEntity.Price,
                OriginalPrice = productEntity.Price,
                Stock = productEntity.Stock,
                ViewCount = productEntity.ViewCount,
                CreateAt = productEntity.CreateAt,
                OrderDetails = productEntity.OrderDetails,
                ProductTranslations = productEntity.ProductTranslations
            };
        }
    }
}