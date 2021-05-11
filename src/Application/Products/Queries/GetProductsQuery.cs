using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Grocery.Application.Common.Models;
using Grocery.Application.Common.Interfaces;
using Grocery.Application.Products.Models;
namespace Grocery.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<PaginatedList<ProductModel>>
    {
        public string Criteria { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductModel>>
    {
        private readonly IApplicationDbContext _context;
        public GetProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<ProductModel>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        where pt.Name.Contains(request.Criteria)
                        select new { p, pt };

            if (!string.IsNullOrEmpty(request.Criteria))
            {
                query = query.Where(x => x.pt.Name.Contains(request.Criteria));
            }

            var queryable = query.Select(x => new ProductModel
            {
                Id = x.p.Id,
                Name = x.pt.Name,
                Price = x.p.Price,
                OriginalPrice = x.p.OriginalPrice,
                Stock = x.p.Stock,
                Description = x.pt.Description,
                Detail = x.pt.Detail,
                SaleDescription = x.pt.SaleDescription,
                SaleTitle = x.pt.SaleTitle
            });

            return await PaginatedList<ProductModel>.CreateAsync(queryable, request.PageIndex, request.PageSize);
        }
    }
}