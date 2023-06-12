using AutoFinder.IntegrationTests.Client;
using NUnit.Framework;
using System.Net;

namespace AutoFinder.IntegrationTests.Tests
{
    public class FeaturesClientTests
    {
        private RdwAutoFinderClient _rdwAutoFinderClient;

        [OneTimeSetUp]
        public async Task Setup()
        {
            var apiClient = ApiClientBuilder.GetClient();
            _rdwAutoFinderClient = new RdwAutoFinderClient(apiClient);
            //Create infrastructire if neccessery 
        }


        [Test]
        public void FindAutoByPlateNumber_Feature_Success()
        {
            // Act
            _rdwAutoFinderClient.FindAuto("HB100", null, null,
            x =>
            {
                // Assert
                Assert.That(x.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.IsNotNull(x.Data);
                Assert.GreaterOrEqual(x.Data.Count, 1);


            });
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Cleanup

        }
    }
}
