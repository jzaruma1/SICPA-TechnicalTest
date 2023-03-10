using Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebApi
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();

            var defaultConnectionString = configuration.GetConnectionString("DefaultConnection");
            builder
                        .UseMySql(
                            defaultConnectionString,
                            new MariaDbServerVersion(new Version(10, 6)));

            return new DataContext(builder.Options);
        }
    }
}
