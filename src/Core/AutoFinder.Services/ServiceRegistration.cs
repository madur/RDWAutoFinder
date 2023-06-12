using AutoFinder.Application.Contracts.Service;
using AutoFinder.Services.RdwAuto;
using Microsoft.Extensions.DependencyInjection;

namespace AutoFinder.Services
{
    public static class CoreServiceRegisteration
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRdwAutoService), typeof(RdwAutoService));
            return services;
        }
    }
}
