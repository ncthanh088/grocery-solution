using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Persistence.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ShippingAddress)
               .WithMany()
               .HasForeignKey(x => x.ShippingAddressId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.BillingAddress)
               .WithMany()
               .HasForeignKey(x => x.BillingAddressId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}