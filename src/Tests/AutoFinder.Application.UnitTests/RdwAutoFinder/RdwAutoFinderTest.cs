using AutoFinder.Application.Contracts.Persistance;
using AutoFinder.Application.Contracts.Service;
using AutoFinder.Application.Profile;
using AutoFinder.Domain.Entities;
using AutoFinder.Services.RdwAuto;
using AutoFixture;
using AutoMapper;
using Moq;
using NUnit.Framework;

namespace AutoFinder.Application.UnitTests.RdwAutoFinder
{
    public class RdwAutoFinderTest
    {
        private readonly IMapper _mapper;
        private IRdwAutoService _rdwAutoService;
        private Mock<IRdwAutoRepository> _rdwAutoRepository = new();
        private IFixture _fixture;

        public RdwAutoFinderTest()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

            _fixture = new Fixture();
            _fixture
                .Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));

            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(10));
        }

        [SetUp]
        public void TestSetup()
        {
            _rdwAutoService = new RdwAutoService(_rdwAutoRepository.Object, _mapper);
        }


        [Test]
        //Only one unit test for example
        public void FindAutoByOnlyPlateNumber_Success()
        {
            // Arrange
            var proposalId = Guid.NewGuid();
            //unit test full mocking of result
            IEnumerable<RdwAutoModel> rdwAutos = _fixture.Create<List<RdwAutoModel>>();

            _rdwAutoRepository.Setup(x => x.FindAuto(It.IsAny<string>(), null, null)).Returns(rdwAutos);
            // Act
            var result = _rdwAutoService.FindAuto("HB100B", null, null);
            // Assert
            Assert.NotNull(result);
        }
    }
}