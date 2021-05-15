using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Grocery.Infrastructure.Persistence.Configurations
{
    public class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.ToTable("OrderAddresses");
            builder.HasKey(x => x.Id);

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