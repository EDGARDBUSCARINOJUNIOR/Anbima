using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Anbima.Application.Services;
using Anbima.Application.Services.Interfaces;
using Anbima.Application.Mappings;

namespace Anbima.Infra.Ioc
{
    public static class DependencyInjection
    {     

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IAnbimaService, AnbimaService>();
            return services;
        }
    }
}
