using AutoFinder.Application.Contracts.Persistance;
using AutoFinder.Application.Resource;
using AutoFinder.Application.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SODA;
using System.Data;

namespace AutoFinder.Infrastructure.Persistence
{
    public class BaseRdwSodaRepository<TDataSetObject> : BaseSodaRepository<TDataSetObject> where TDataSetObject : class
    {
        public BaseRdwSodaRepository(SodaClient sodaClient,
                                     IOptions<RdwServiceSettings> rdwServiceSetting,
                                     ILogger<BaseRdwSodaRepository<TDataSetObject>> logger) : base(sodaClient, logger)
        {
            try
            {
                _dataset = sodaClient.GetResource<TDataSetObject>(rdwServiceSetting.Value.Gekentekende_voertuigenDataSet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessages.SodaDataSetError);
                throw new ApplicationException(ErrorMessages.SodaDataSetError);
            }
        }
    }
}