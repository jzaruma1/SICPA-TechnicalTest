using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence
{
    public static class PersistenceServicesExtension
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<DataContext>(
                  dbContextOptions => dbContextOptions
                      .UseMySql(
                          defaultConnectionString,
                          new MariaDbServerVersion(new Version(10, 6)))
                      .EnableSensitiveDataLogging()
                      .EnableDetailedErrors());

            return services;
        }
    }
}
