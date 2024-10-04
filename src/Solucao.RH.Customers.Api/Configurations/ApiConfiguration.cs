using Api.Service.Configurations;

namespace Solucao.RH.Customers.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddCoreApiConfig(configuration, environment);

        services.AddRepositories();
        services.AddAutoMapper();
        services.AddDbContext(configuration);

        return services;
    }

    public static WebApplication UseApiConfig(this WebApplication app)
    {
        app.UseCoreApiConfig();

        return app;
    }
}
