using AutoFinder.Domain.Entities;

namespace AutoFinder.Application.Contracts.Persistance
{
    public interface IRdwAutoRepository
    {
        IEnumerable<RdwAutoModel> FindAuto(string? plateNumber, string? brand, string? autoType);
    }
}
