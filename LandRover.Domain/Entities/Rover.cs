using LandRover.Domain.Enums;

namespace LandRover.Domain.Entities
{
    public class Rover
    {
        public Coordinate coordinate { get; set; }
        public CardinalPoint cardinalPoint { get; set; }
    }
}