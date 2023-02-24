using FluentAssertions;
using LandRover.Application.Services;
using LandRover.Domain.Entities;
using LandRover.Domain.Interfaces.Infra.Repository;
using Moq;

namespace LandRover.UnitTests.Application.Service
{
    public class LandingPlanServiceTests
    {
        private readonly LandingPlanService _landingPlanService;
        readonly Mock<ILandingPlanRepository> _landingPlanRepositoryMock;
        
        public LandingPlanServiceTests()
        {
            _landingPlanRepositoryMock = new Mock<ILandingPlanRepository>();
            _landingPlanService = new LandingPlanService(_landingPlanRepositoryMock.Object);
        }

        [Fact]
        public void GetLandingPlans_ShouldGetLandingPlans()
        {

            _landingPlanRepositoryMock.Setup(x => x.GetLandingPlans(It.IsAny<string>())).Returns(new LandingPlans());

            var plans = _landingPlanService.GetLandingPlans("/path");

            plans.Should().NotBeNull();                
        }
    }
}