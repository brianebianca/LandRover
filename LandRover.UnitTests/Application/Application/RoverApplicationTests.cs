using AutoFixture;
using FluentAssertions;
using LandRover.Application.Application;
using LandRover.Domain.Entities;
using LandRover.Domain.Interfaces.Application.Services;
using Moq;

namespace LandRover.UnitTests.Application.Application
{
    public class RoverApplicationTests
    {
        private readonly IFixture _fixture;
        private readonly RoverApplication _roverApplication;
        private readonly Mock<ILandingPlanService> _landingPlanServiceMock;
        private readonly Mock<IRoverService> _roverServiceMock;

        public RoverApplicationTests()
        {
            _fixture = new Fixture();
            _landingPlanServiceMock = new Mock<ILandingPlanService>();
            _roverServiceMock = new Mock<IRoverService>();
            _roverApplication = new RoverApplication(_landingPlanServiceMock.Object, _roverServiceMock.Object);
        }

        [Fact]
        public void NavigateAllRovers_ShouldMoveAllRovers()
        {
            var instructions = _fixture.CreateMany<Instruction>(2).ToList();
            var rover = _fixture.Build<Rover>().Create();
            var plan = new LandingPlan() { Rover = rover, instructions = instructions };
            var plans = new List<LandingPlan>() { plan, plan };
            var landingPlans = _fixture.Build<LandingPlans>()
                              .With(p => p.landingPlans, plans)
                              .Create();

            _landingPlanServiceMock.Setup(x => x.GetLandingPlans(It.IsAny<string>())).Returns(landingPlans);
            _roverServiceMock.Setup(x => x.Navigate(It.IsAny<Rover>(), It.IsAny<List<Instruction>>())).Returns(rover);

            var rovers = _roverApplication.NavigateAllRovers("/path");

            rovers.Count().Should().Be(2);
            _landingPlanServiceMock.Verify(x => x.GetLandingPlans(It.IsAny<string>()), Times.Once);
            _roverServiceMock.Verify(x => x.Navigate(It.IsAny<Rover>(), It.IsAny<List<Instruction>>()), Times.Exactly(2));
        }
    }
}