using FluentAssertions;
using LandRover.Domain.Entities;
using LandRover.Domain.Enums;

namespace LandRover.UnitTests.Domain.Entities
{
    public class CoordinateTests
    {
        [Theory]
        [InlineData(CardinalPoint.E, 3, 3)]
        [InlineData(CardinalPoint.W, 1, 3)]
        [InlineData(CardinalPoint.N, 2, 3)]
        [InlineData(CardinalPoint.S, 2, 3)]
        public void MoveXAsis_ShouldMoveXAsis_ForAGivenCardinalPoint(CardinalPoint cardinalPoint, int x, int y)
        {
            var coordinate = new Coordinate()
            {
                x = 2,
                y = 3
            };
            coordinate.MoveXAsis(cardinalPoint);
            coordinate.x.Should().Be(x);
            coordinate.y.Should().Be(y);
        }

        [Theory]
        [InlineData(CardinalPoint.E, 2, 3)]
        [InlineData(CardinalPoint.W, 2, 3)]
        [InlineData(CardinalPoint.N, 2, 4)]
        [InlineData(CardinalPoint.S, 2, 2)]
        public void MoveYAsis_ShouldMoveYAsis_ForAGivenCardinalPoint(CardinalPoint cardinalPoint, int x, int y)
        {
            var coordinate = new Coordinate()
            {
                x = 2,
                y = 3
            };
            coordinate.MoveYAsis(cardinalPoint);
            coordinate.x.Should().Be(x);
            coordinate.y.Should().Be(y);
        }
    }
}