using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Application.Helpers;

namespace Application
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
