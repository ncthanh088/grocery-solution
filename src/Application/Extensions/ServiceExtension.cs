using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Grocery.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}