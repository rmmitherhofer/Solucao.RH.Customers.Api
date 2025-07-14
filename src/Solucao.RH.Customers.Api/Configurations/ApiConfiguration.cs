using Solucao.RH.Customers.Anticorruption.Configurations;
using Solucao.RH.Customers.Data.Configurations;
using Zypher.Api.Foundation.Configurations;


namespace Solucao.RH.Customers.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddCoreApiConfig(configuration, environment);

        services.AddAutoMapper();
        services.AddHttpServices(configuration);
        services.AddDbContext(configuration);

        return services;
    }

    public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(IApplicationBuilder));

        app.UseCoreApiConfig();

        return app;
    }
}
