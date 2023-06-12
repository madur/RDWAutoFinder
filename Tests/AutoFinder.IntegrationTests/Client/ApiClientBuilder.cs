using ExpertFinder.Presistence.IntegrationTests;
using RestSharp;
using System.Net;

namespace AutoFinder.IntegrationTests.Client
{
    public static class ApiClientBuilder
    {
        public static RestClient GetClient()
        {
            var client = new RestClient(TestConfiguration.ApiUrl);

            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, sslPolicyErrors) => true; // SSL fails for local API

            return client;
        }
    }
}
