using System.Linq;
using System.Threading.Tasks;
using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Countries.Any())
            {
                context.Countries.AddRange(
                new Country() { Id = "VN", Code3 = "VNM", Name = "Việt Nam", IsBillingEnabled = true, IsShippingEnabled = true, IsCityEnabled = false, IsZipCodeEnabled = false, IsDistrictEnabled = true },
                new Country() { Id = "USA", Code3 = "USA", Name = "United States", IsBillingEnabled = true, IsShippingEnabled = true, IsCityEnabled = true, IsZipCodeEnabled = true, IsDistrictEnabled = false });
            }

            await context.SaveChangesAsync();
        }
    }
}
