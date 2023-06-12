using AutoFinder.Application.Contracts.Persistance;
using AutoFinder.Application.Contracts.Service;
using AutoFinder.Application.DTO;
using AutoFinder.Application.Profile;
using AutoFinder.Domain.Entities;
using AutoMapper;


namespace AutoFinder.Services.RdwAuto
{
    public class RdwAutoService : IRdwAutoService
    {
        private readonly IRdwAutoRepository _RdwAutoRepository;
        private readonly IMapper _mapper;
        public RdwAutoService(IRdwAutoRepository RdwAutoRepository, IMapper mapper)
        {
            _RdwAutoRepository = RdwAutoRepository;
            _mapper = mapper;
        }

        public IEnumerable<RdwAutoViewModel> FindAuto(string? plateNumber, string? brand, string? autoType)
        {
            var result = _RdwAutoRepository.FindAuto(plateNumber, brand, autoType);
            var resultListVM = new MappingListToList<RdwAutoModel, RdwAutoViewModel>(_mapper).Convert(result.ToList());
            return resultListVM;
        }
    }
}
