using System.Threading.Tasks;
using Grocery.Domain.Entities;
namespace Grocery.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Address's data info
            context.Countries.AddRange(
                new Country() { Id = "VN", Code3 = "VNM", Name = "Việt Nam", IsBillingEnabled = true, IsShippingEnabled = true, IsCityEnabled = false, IsZipCodeEnabled = false, IsDistrictEnabled = true },
                new Country() { Id = "USA", Code3 = "USA", Name = "United States", IsBillingEnabled = true, IsShippingEnabled = true, IsCityEnabled = true, IsZipCodeEnabled = true, IsDistrictEnabled = false }
            );

            context.StateOrProvinces.AddRange(
                new StateOrProvince() { Id = 1, CountryId = "VN", Name = "Hồ Chí Minh", Type = "Thành Phố" },
                new StateOrProvince() { Id = 2, CountryId = "US", Name = "Washington", Code = "WA" }
            );

            context.Districts.AddRange(
                new District() { Id = 1, Name = "Quận 1", StateOrProvinceId = 1, Type = "Quận" },
                new District() { Id = 2, Name = "Quận 2", StateOrProvinceId = 1, Type = "Quận" }
            );

            context.Addresses.AddRange(
                new Address() { Id = 1, AddressLine1 = "364 Cong Hoa", ContactName = "Thien Nguyen", CountryId = "VN", StateOrProvinceId = 1 }
            );

            await context.SaveChangesAsync();
        }
    }
}
