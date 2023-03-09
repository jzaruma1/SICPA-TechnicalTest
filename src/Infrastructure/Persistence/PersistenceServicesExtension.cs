using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServicesExtension
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
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
