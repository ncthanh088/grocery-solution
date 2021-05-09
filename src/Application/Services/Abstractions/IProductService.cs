using System;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Common.Models;
using Grocery.Application.Products.Commands;
using Grocery.Application.Products.Models;
using Grocery.Application.Products.Queries;

namespace Grocery.Application.Services.Abstractions
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(CreateProductCommand request, CancellationToken cancellationToken);
        Task<bool> DeleteProductAsync(DeleteProductCommand request, CancellationToken cancellationToken);
        Task<bool> UpdateProductAsync(UpdateProductCommand request, CancellationToken cancellationToken);
        Task<bool> UpdatePriceAsync(Guid productId, float newPrice, CancellationToken cancellationToken);
        Task<bool> UpdateStockAsync(Guid productId, int quantity, CancellationToken cancellationToken);
        Task<bool> UpdateViewCountAsync(Guid productId, int viewCount, CancellationToken cancellationToken);
        Task<ProductDto> GetProductByIdAsync(GetProductDetailQuery request, CancellationToken cancellationToken);
        Task<PaginatedList<ProductModel>> GetProductsByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken);
        Task<PaginatedList<ProductModel>> GetProductsAsync(GetProductsQuery request, CancellationToken cancellationToken);
    }
}