using Newtonsoft.Json;
using RestSharp;
using ExpertFinder.Presistence.IntegrationTests;

namespace AutoFinder.IntegrationTests.Client
{
    public abstract class BaseClient
    {
        protected readonly RestClient Client;

        protected BaseClient(RestClient client)
        {
            Client = client;
            Client.AddDefaultHeader("Content-Type", "application/json;charset=UTF-8");
            Client.AddDefaultHeader("AutoFinderApiKey", TestConfiguration.AutoFinderApiKey);
        }
    }
}
