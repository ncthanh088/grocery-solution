using Grocery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Grocery.Infrastructure.Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.DefaultShippingAddress)
                   .WithMany()
                   .HasForeignKey(x => x.DefaultShippingAddressId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DefaultBillingAddress)
                .WithMany()
                .HasForeignKey(x => x.DefaultBillingAddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}