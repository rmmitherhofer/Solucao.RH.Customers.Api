using Solucao.RH.Customers.Api.Configurations;
using Solucao.RH.Customers.Api.Configurations.AutoMapper;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Solucao.RH.Customers.Data.Repositories;

namespace Solucao.RH.Customers.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(FilterRequestToFilterProfile), typeof(EntityToResponseProfile));

        return services;
    }
}
