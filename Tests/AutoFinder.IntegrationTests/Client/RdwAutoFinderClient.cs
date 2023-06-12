
using AutoFinder.Application.DTO;
using RestSharp;

namespace AutoFinder.IntegrationTests.Client
{
    public class RdwAutoFinderClient : BaseClient
    {
        public RdwAutoFinderClient(RestClient restClient) : base(restClient)
        {
        }


        public void FindAuto(string? plateNumber = null, string? brand = null, string? autoType = null, 
                             Action<RestResponse<List<RdwAutoViewModel>>>? test = null)
        {
            var request = new RestRequest($"api/RdwAutoFinder", Method.Get);
            request.AddParameter("plateNumber", plateNumber);
            request.AddParameter("brand", brand);
            request.AddParameter("autoType", autoType);

            try
            {
                var response = Client.Execute<List<RdwAutoViewModel>>(request);
                test?.Invoke(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
