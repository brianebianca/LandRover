using FluentAssertions;
using LandRover.Domain.Entities;
using LandRover.Domain.Enums;

namespace LandRover.UnitTests.Domain.Entities
{
    public class RoverTests
    {
        [Theory]
        [InlineData(CardinalPoint.N, CardinalPoint.E)]
        [InlineData(CardinalPoint.E, CardinalPoint.S)]
        [InlineData(CardinalPoint.S, CardinalPoint.W)]
        [InlineData(CardinalPoint.W, CardinalPoint.N)]
        public void SpinClockwise_ShouldMoveToNextCartinalPointByClockWiseDirection(CardinalPoint currentPoint, CardinalPoint nextPoint)
        {
            var rover = new Rover()
            {
                cardinalPoint = currentPoint
            };

            rover.SpinClockwise();

            rover.cardinalPoint.Should().Be(nextPoint);
        }

        [Theory]
        [InlineData(CardinalPoint.N, CardinalPoint.W)]
        [InlineData(CardinalPoint.W, CardinalPoint.S)]
        [InlineData(CardinalPoint.S, CardinalPoint.E)]
        [InlineData(CardinalPoint.E, CardinalPoint.N)]
        public void SpinAntiClockwise_ShouldMoveToPreviousCartinalPointByClockWiseDirection(CardinalPoint currentPoint, CardinalPoint previousPoint)
        {
            var rover = new Rover()
            {
                cardinalPoint = currentPoint
            };

            rover.SpinAntiClockwise();

            rover.cardinalPoint.Should().Be(previousPoint);
        }
    }
}