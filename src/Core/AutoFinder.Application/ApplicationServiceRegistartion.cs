using AutoFinder.Application.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SODA;
using System.Reflection;

namespace AutoFinder.Application
{
    //Register SodaClient instance
    public static class ApplicationServiceRegistartion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped(BuildSodaService);
            return services;
        }

        private static SodaClient BuildSodaService(IServiceProvider provider)
        {
            var sodaClientSettingsOptions = provider.GetService<IOptions<RdwServiceSettings>>();
            var sodaClientServiceSettings = sodaClientSettingsOptions.Value;

            return GetSodaClient(sodaClientServiceSettings);
        }

        public static SodaClient GetSodaClient(RdwServiceSettings sodaServiceSettings)
        {
            var client = new SodaClient(sodaServiceSettings.Host, sodaServiceSettings.SODAAppToken);

            return client;
        }

    }
}
