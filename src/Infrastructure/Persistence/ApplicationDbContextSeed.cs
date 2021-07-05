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
            //TODO: Implement the sameple data here
            await context.SaveChangesAsync();
        }
    }
}
