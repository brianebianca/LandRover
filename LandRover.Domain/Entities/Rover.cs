using LandRover.Domain.Enums;

namespace LandRover.Domain.Entities
{
    public class Rover
    {
        public Coordinate coordinate { get; set; }
        public CardinalPoint cardinalPoint { get; set; }

        public void SpinClockwise()
        {
            CardinalPoint[] cardinalPoints = Enum.GetValues<CardinalPoint>();

            var firstPointIndex = 0;

            for (int i = 0; i < cardinalPoints.Length; i++)
            {
                if (cardinalPoints[i] == cardinalPoint)
                {
                    var nextCardinalPointIndex = i + 1;
                    if(nextCardinalPointIndex < cardinalPoints.Length)
                    {
                        cardinalPoint = cardinalPoints[nextCardinalPointIndex];
                    }
                    else
                    {
                        cardinalPoint = cardinalPoints[firstPointIndex];
                    }
                    break;
                }
            }
        }

        public void SpinAntiClockwise()
        {
            CardinalPoint[] cardinalPoints = Enum.GetValues<CardinalPoint>();

            var lastPointIndex = cardinalPoints.Length - 1;

            for (int i = lastPointIndex; i >= 0; i--)
            {
                if (cardinalPoints[i] == cardinalPoint)
                {
                    var previousCardinalPointIndex = i - 1;
                    if (previousCardinalPointIndex < 0)
                    {
                        cardinalPoint = cardinalPoints[lastPointIndex];
                    }
                    else
                    {
                        cardinalPoint = cardinalPoints[previousCardinalPointIndex];
                    }
                    break;
                }
            }
        }
    }
}