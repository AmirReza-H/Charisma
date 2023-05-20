using Microsoft.Extensions.DependencyInjection;
using Store.Application.Interfaces;
using Store.Application.Interfaces.Repositories;
using Store.Infrastructure.Persistence.Contexts;
using Store.Infrastructure.Persistence.Repositories;

namespace Store.Infrastructure.Persistence
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                    .AddScoped<IUnitOfWork, UnitOfWork>()
                    .AddScoped<ISettingRepository, SettingRepository>()
                    .AddScoped<IOrderRepository, OrderRepository>()
                    .AddScoped<IProductRepository, ProductRepository>()
                    ;

            return services;
        }
    }
}
