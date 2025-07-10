using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Solucao.RH.Customers.Business.Interfaces.Repositories;
using Solucao.RH.Customers.Data.Repositories;

namespace Solucao.RH.Customers.Data.Configurations;

public static class DbContextConfiguration
{
    private const string CONNECTION_CUSTOMER_KEY = "CNN_DB_CUSTOMER";
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));
        ArgumentNullException.ThrowIfNull(configuration, nameof(IConfiguration));

        services.AddDbContext<CustomerContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(CONNECTION_CUSTOMER_KEY));
            options.EnableSensitiveDataLogging(false);
            options.UseLoggerFactory(LoggerFactory.Create(_ => { }));
        });

        services.TryAddScoped<CustomerContext>();

        services.AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services, nameof(IServiceCollection));

        services.TryAddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}
