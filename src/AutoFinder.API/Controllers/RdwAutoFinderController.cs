using AutoFinder.Application.Contracts.Service;
using AutoFinder.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RdwAutoFinderController : ControllerBase
    {
        private readonly IRdwAutoService _RdwAutoService;
        public RdwAutoFinderController(IRdwAutoService RdwAutoService)
        {
            _RdwAutoService = RdwAutoService;
        }

        [HttpGet(Name = "FindAuto")]
        [Produces(typeof(IEnumerable<RdwAutoViewModel>))]
        public IEnumerable<RdwAutoViewModel> FindAuto(string? plateNumber = null, string? brand = null, string? autoType = null)
        {
            return _RdwAutoService.FindAuto(plateNumber, brand, autoType);
        }
    }
}