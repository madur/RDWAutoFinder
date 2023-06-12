using AutoFinder.Application.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AutoFinder.Application
{
    public static class SettingsRegistration
    {
        public static void AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RdwServiceSettings>(configuration.GetSection("RdwServiceSettings"));
        }

    }
}
