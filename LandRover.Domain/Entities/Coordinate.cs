using LandRover.Domain.Enums;

namespace LandRover.Domain.Entities
{
    public class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }

        public void MoveXAsis(CardinalPoint cardinalPoint)
        {
            if (cardinalPoint == CardinalPoint.E)
            {
                x++;
            }
            else if(cardinalPoint == CardinalPoint.W)
            {
                x--;
            }
        }

        public void MoveYAsis(CardinalPoint cardinalPoint)
        {
            if (cardinalPoint == CardinalPoint.N)
            {
                y++;
            }
            else if (cardinalPoint == CardinalPoint.S)
            {
                y--;
            }
        }
    }
}