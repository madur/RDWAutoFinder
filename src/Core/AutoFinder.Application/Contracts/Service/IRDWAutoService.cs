using AutoFinder.Application.DTO;

namespace AutoFinder.Application.Contracts.Service
{
    public interface IRdwAutoService
    {
        public IEnumerable<RdwAutoViewModel> FindAuto(string? plateNumber, string? brand, string? autoType);
    }
}
