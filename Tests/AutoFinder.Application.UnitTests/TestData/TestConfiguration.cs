using AutoFinder.Application.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ExpertFinder.Application.UnitTests.TestData
{
    public class TestConfiguration
    {
        public readonly static IOptions<RdwServiceSettings> RdwServiceSettings;
        private static readonly IConfigurationRoot _configuration;
        static TestConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"TestData/TestSettings.json", true, true)
                .Build();

            var RdwServiceSection = _configuration.GetSection("RdwServiceSettings")
                                                  .Get<RdwServiceSettings>();

            RdwServiceSettings = Options.Create(RdwServiceSection);

        }
    }
}
