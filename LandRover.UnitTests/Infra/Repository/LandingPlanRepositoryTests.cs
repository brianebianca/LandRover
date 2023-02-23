using FluentAssertions;
using LandRover.Domain.Enums;
using LandRover.Infra.Repository.Repositories;

namespace LandRover.UnitTests.Infra.Repository
{
    public class LandingPlanRepositoryTests
    {
        private LandingPlanRepository landingPlanRepository;
        public LandingPlanRepositoryTests()
        {
            landingPlanRepository = new LandingPlanRepository();
        }

        [Fact]
        public void LoadPlateau_ShouldCreatePlateauObjectForAGivenStringList()
        {
            var stringList = new string[] { "27", "89"};
            var plateau = landingPlanRepository.LoadPlateau(stringList);

            plateau.UpperRightLimit.x.Should().Be(27);
            plateau.UpperRightLimit.y.Should().Be(89);
        }

        [Fact]
        public void LoadRover_ShouldCreateRoverObjectForAGivenStringList()
        {
            var stringList = new string[] { "13", "45", "W"};
            var rover = landingPlanRepository.LoadRover(stringList);

            rover.coordinate.x.Should().Be(13);
            rover.coordinate.y.Should().Be(45);
            rover.cardinalPoint.Should().Be(CardinalPoint.W);
        }

        [Fact]
        public void LoadInstructions_ShouldCreateInstructionsObjectsForAGivenString()
        {
            var stringText = "LMMRM";
            var instructions = landingPlanRepository.LoadInstructions(stringText);
            instructions.Should().HaveCount(5);
        }

        [Fact]
        public void LoadLandingPlans_ShouldCreateLoadLandingPlansForAGivenInput()
        {
            var stringList = new string[]
            {
                "7 9",
                "2 3 W",
                "LMRMM",
                "3 5 S",
                "MMLMR"
            };

            var plans = landingPlanRepository.LoadLandingPlans(stringList);

            plans.plateau.Should().NotBeNull();
            plans.landingPlans.Should().HaveCount(2);
        }
    }
}