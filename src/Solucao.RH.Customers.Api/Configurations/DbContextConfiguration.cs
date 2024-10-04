using Microsoft.EntityFrameworkCore;
using Solucao.RH.Customers.Data;

namespace Solucao.RH.Customers.Api.Configurations;

public static class DbContextConfiguration
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CustomerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CNN_DB_CUSTOMER")));

        services.AddScoped<CustomerContext>();

        return services;
    }
}
