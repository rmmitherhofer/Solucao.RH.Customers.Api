using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NedMonitor.Http.Handlers;
using Solucao.RH.Customers.Anticorruption.HttpServices;
using Solucao.RH.Customers.Anticorruption.Options;
using Solucao.RH.Customers.Business.Interfaces.HttpServices;

namespace Solucao.RH.Customers.Anticorruption.Configurations;

public static class HttpServicesConfiguration
{
    public static IServiceCollection AddHttpServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddHttpServiceOptions(configuration);

        var settings = configuration.GetSection(CustomerHistorySettings.SECTION_NAME).Get<CustomerHistorySettings>() ?? new();

        services.AddHttpClient<ICustomerHistHttpService, CustomerHistHttpService>(services =>
            services.BaseAddress = new Uri(settings.BaseAddress)
        ).AddHttpMessageHandler<NedMonitorHttpLoggingHandler>();


        return services;
    }

    private static IServiceCollection AddHttpServiceOptions(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.Configure<CustomerHistorySettings>(configuration.GetSection(CustomerHistorySettings.SECTION_NAME));

        return services;
    }
}
