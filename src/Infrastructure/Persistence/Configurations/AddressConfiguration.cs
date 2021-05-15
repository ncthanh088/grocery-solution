using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            // Address
            builder.ToTable("Address");
            builder.HasKey(x => x.Id);

            // Address's Relationships
            builder.HasOne(d => d.District)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.StateOrProvince)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Country)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}