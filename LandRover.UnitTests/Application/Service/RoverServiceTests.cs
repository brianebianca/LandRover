using FluentAssertions;
using LandRover.Application.Services;
using LandRover.Domain.Entities;
using LandRover.Domain.Enums;

namespace LandRover.UnitTests.Application.Service
{
    public class RoverServiceTests
    {
        private RoverService _roverService;
        public RoverServiceTests() 
        {
            _roverService = new RoverService();
        }

        [Fact]
        public void Navigate_ShouldNavigateAccordToInstructions()
        {
            var coordinate = new Coordinate() { x = 3, y = 3 };
            var rover = new Rover()
            {
                coordinate = coordinate,
                cardinalPoint = CardinalPoint.E
            };
            var instructions = new List<Instruction>()
            {
                new Instruction("M"),
                new Instruction("M"),
                new Instruction("R"),
                new Instruction("M"),
                new Instruction("M"),
                new Instruction("R"),
                new Instruction("M"),
                new Instruction("R"),
                new Instruction("R"),
                new Instruction("M")
            };

            var plateau = new Plateau();

            var roverResult = _roverService.Navigate(rover, instructions, plateau);
            roverResult.coordinate.x.Should().Be(5);
            roverResult.coordinate.y.Should().Be(1);
            roverResult.cardinalPoint.Should().Be(CardinalPoint.E);
        }

        [Fact]
        public void NavigateByInstruction_ShouldChangeDirectionOrMoveAccordToAGivenInstruction()
        {
            var coordinate = new Coordinate() { x = 1, y = 2 };
            var rover = new Rover()
            {
                coordinate = coordinate,
                cardinalPoint = CardinalPoint.N
            };
            var instruction = new Instruction("R");
            var plateau = new Plateau();

            var roverResult = _roverService.NavigateByInstruction(rover, instruction, plateau);
            roverResult.coordinate.x.Should().Be(1);
            roverResult.coordinate.y.Should().Be(2);
            roverResult.cardinalPoint.Should().Be(CardinalPoint.E);
        }

        [Theory]
        [InlineData(SpinDirection.L, CardinalPoint.W)]
        [InlineData(SpinDirection.R, CardinalPoint.E)]
        public void Spin_ShouldTurnToCorrectDirection(SpinDirection direction, CardinalPoint directionExpected)
        {
            var coordinate = new Coordinate() { x = 1, y = 2 };
            var rover = new Rover()
            {
                coordinate = coordinate,
                cardinalPoint = CardinalPoint.N
            };
            var instruction = new Instruction(direction.ToString());
            var roverResult = _roverService.Spin(rover, instruction);
            roverResult.coordinate.x.Should().Be(1);
            roverResult.coordinate.y.Should().Be(2);
            roverResult.cardinalPoint.Should().Be(directionExpected);
        }

        [Theory]
        [InlineData(CardinalPoint.N, 1, 3)]
        [InlineData(CardinalPoint.E, 2, 2)]
        [InlineData(CardinalPoint.S, 1, 1)]
        [InlineData(CardinalPoint.W, 0, 2)]
        public void MoveFoward_ShouldMoveCorrectAsisAndDirection(CardinalPoint cardinalPoint, int expectedX, int expectedY)
        {
            var coordinate = new Coordinate() { x = 1, y = 2 };
            var rover = new Rover()
            {
                coordinate = coordinate,
                cardinalPoint = cardinalPoint
            };
            var instruction = new Instruction("M");
            var roverResult = _roverService.MoveFoward(rover, instruction);
            roverResult.coordinate.x.Should().Be(expectedX);
            roverResult.coordinate.y.Should().Be(expectedY);
            roverResult.cardinalPoint.Should().Be(cardinalPoint);
        }
    }
}