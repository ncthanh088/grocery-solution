using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Promotion> Promotions { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<ProductTranslation> ProductTranslations { get; set; }
        DbSet<CategoryTranslation> CategoryTranslations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
