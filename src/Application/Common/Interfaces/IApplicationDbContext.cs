using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Grocery.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<District> Districts { get; set; }
        DbSet<StateOrProvince> StateOrProvinces { get; set; }
        DbSet<Country> Countries { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
