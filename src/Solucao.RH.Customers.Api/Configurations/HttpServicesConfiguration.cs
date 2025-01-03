using Solucao.RH.Customers.Anticorruption.HttpServices;
using Solucao.RH.Customers.Business.Interfaces.HttpServices;

namespace Solucao.RH.Customers.Api.Configurations;

public static class HttpServicesConfiguration
{
    public static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHttpClient<ICustomerHistHttpService, CustomerHistHttpService>(services =>
            services.BaseAddress = new Uri(configuration.GetSection("Apis:Customer-hist:BaseAddress").Value)
        );

        return services;
    }
}
