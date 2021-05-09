using System;
using System.Linq;
using System.Threading.Tasks;
using Grocery.Domain.Entities;

namespace Grocery.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Price = 10f,
                    OriginalPrice = 10f,
                    Stock = 100,
                    CreateAt = DateTime.UtcNow
                });
            }

            if (!context.Orders.Any())
            {
                context.Orders.Add(new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    OrderDate = DateTime.UtcNow,
                    Status = Domain.Enums.OrderStatusEnum.Success,
                    ShipAddress = "20/33 Truong Chinh, P14, Tan Binh",
                    ShipEmail = "ship01@gmail.com",
                    ShipName = "Shipper",
                });
            }

            await context.SaveChangesAsync();
        }
    }

    internal static class OrderExtensions
    {
        public static Order AddOrderDetail(this Order order, params OrderDetail[] orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                order.OrderDetails.Add(orderDetail);
            }

            return order;
        }
    }
}
