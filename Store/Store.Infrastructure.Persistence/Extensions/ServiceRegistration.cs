using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Infrastructure.Persistence.Contexts;

namespace Store.Infrastructure.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Store")));

            return services;
        }
    }
}
