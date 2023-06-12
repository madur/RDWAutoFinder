using AutoFinder.Application.Contracts.Persistance;
using AutoFinder.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AutoFinder.Infrastructure.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRdwAutoRepository), typeof(RdwAutoRepository));

            return services;
        }
    }
}
