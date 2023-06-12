using AutoFinder.Application.Contracts.Persistance;
using AutoFinder.Application.Settings;
using AutoFinder.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SODA;
using System.Text;

namespace AutoFinder.Infrastructure.Persistence.Repository
{
    public class RdwAutoRepository : BaseRdwSodaRepository<RdwAutoModel>, IRdwAutoRepository
    {
        public RdwAutoRepository(SodaClient sodaClient,
                                 IOptions<RdwServiceSettings> rdwServiceSetting,
                                 ILogger<RdwAutoRepository> logger) : base(sodaClient, rdwServiceSetting, logger)
        {

        }

        public IEnumerable<RdwAutoModel> FindAuto(string? plateNumber, string? brand, string? autoType)
        {
            var soql = new SoqlQuery()
                        .Select(typeof(RdwAutoModel)
                        .GetProperties()
                        .Select(x => x.Name.ToLower()).ToArray())
                        .Where(CreateAndWhereCondition(plateNumber, brand, autoType));

            return Query(soql);
        }


        //TODO: Make Helper, should be refactor
        private static string CreateAndWhereCondition(string? plateNumber, string? brand, string? autoType)
        {
            StringBuilder sb = new();
            if (!string.IsNullOrEmpty(plateNumber))
            {
                sb.Append($"kenteken LIKE \"{plateNumber}%\"");
            }
            if (!string.IsNullOrEmpty(brand))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" AND ");
                }
                sb.Append($"merk = \"{brand}\"");
            }
            if (!string.IsNullOrEmpty(autoType))
            {
                if (sb.Length > 0)
                {
                    sb.Append(" AND ");
                }
                sb.Append($"voertuigsoort = \"{autoType}\"");
            }
            return sb.ToString();

        }
    }
}
