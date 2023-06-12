using Microsoft.Extensions.Configuration;

namespace ExpertFinder.Presistence.IntegrationTests
{
    public static class TestConfiguration
    {
        private static readonly IConfigurationRoot _configuration;
        public static string ApiUrl => GetSetting("ApiUrl");
        public static string AutoFinderApiKey => GetSetting("AutoFinderApiKey");
        static TestConfiguration()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@"TestData/TestSettings.json", true, true)
                .Build();

        }

        private static string GetSetting(string name)
        {
            return _configuration.GetSection("Settings").GetSection(name).Value;
        }
    }
}