using Solucao.RH.Customers.Anticorruption.AutoMapper;
using Solucao.RH.Customers.Api.Configurations;
using Solucao.RH.Customers.Api.Configurations.AutoMapper;

namespace Solucao.RH.Customers.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.AddAutoMapper(typeof(FilterRequestToFilterProfile), typeof(EntityToResponseProfile), typeof(EntityToHttpRequestProfile));

        return services;
    }
}
