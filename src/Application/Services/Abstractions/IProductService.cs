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
        Task<bool> DeleteProductAsync(Guid productId, CancellationToken cancellationToken);
        Task<ProductDto> GetProductByIdAsync(Guid productId);
        Task<PaginatedList<ProductModel>> GetProductsAsync(GetProductsQuery request, CancellationToken cancellationToken);
    }
}