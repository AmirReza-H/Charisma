using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Store.Application.Features.Setting;
using Store.Application.Interfaces.Repositories;
using System.Reflection;

namespace Store.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                    .AddHostedService<SettingHostService>()
                    .AddMediatR(Assembly.GetExecutingAssembly()); ;
        }
    }
}
