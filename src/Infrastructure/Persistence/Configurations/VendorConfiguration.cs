using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Persistence.Configuration
{
    public class VendorConfigurationConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable("Vendors");
            builder.HasKey(x => x.Id);
        }
    }
}