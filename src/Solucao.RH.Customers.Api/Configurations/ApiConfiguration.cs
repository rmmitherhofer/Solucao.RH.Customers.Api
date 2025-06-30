using Api.Service.Configurations;
using SnapTrace.Configurations.Settings;
using SnapTrace.Enums;


namespace Solucao.RH.Customers.Api.Configurations;

public static class ApiConfiguration
{
    public static IServiceCollection AddApiConfig(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        SnapTraceSettings snapTraceSettings = new(ProjectType.Api, true);

        services.AddCoreApiConfig(configuration, environment, new(snapTraceSettings));

        services.AddRepositories();
        services.AddAutoMapper();
        services.AddHttpServices(configuration);
        services.AddDbContext(configuration);


        return services;
    }

    public static WebApplication UseApiConfig(this WebApplication app, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(IApplicationBuilder));

        app.UseCoreApiConfig();

        return app;
    }
}
