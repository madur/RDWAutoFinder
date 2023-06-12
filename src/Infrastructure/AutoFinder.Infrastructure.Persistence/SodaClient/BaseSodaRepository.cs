using AutoFinder.Application.Contracts.Persistance;
using AutoFinder.Application.Resource;
using Microsoft.Extensions.Logging;
using SODA;

namespace AutoFinder.Infrastructure.Persistence
{
    public abstract class BaseSodaRepository<TDataSetObject> : IBaseSodaRepository where TDataSetObject : class
    {
        private readonly SodaClient _sodaClient;
        protected Resource<TDataSetObject> _dataset;
        protected readonly ILogger _logger;
        public BaseSodaRepository(SodaClient sodaClient, ILogger logger)
        {
            _sodaClient = sodaClient;
            _logger = logger;
        }

        /// <summary>
        /// Socrata Query wrapper
        /// </summary>
        /// <typeparam name="TRow"></typeparam>
        /// <param name="soqlQuery"></param>
        /// <param name="resourceId"></param>
        /// <returns></returns>
        public IEnumerable<TDataSetObject> Query(SoqlQuery soqlQuery)
        {
            IEnumerable<TDataSetObject> results;
            try
            {
                results = _dataset.Query<TDataSetObject>(soqlQuery);
                return results;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogError(ex, ErrorMessages.BadResourceIdSodaQueryError);
                throw new ApplicationException(ErrorMessages.BadResourceIdSodaQueryError);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorMessages.SodaQueryError);
                throw new ApplicationException(ErrorMessages.SodaQueryError);
            }

        }

    }
}