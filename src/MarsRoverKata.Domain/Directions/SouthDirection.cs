using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.Directions
{
    public class SouthDirection : IDirection
    {
        public IDirection GetLeftDirection() => new EastDirection();

        public IDirection GetRightDirection() => new WestDirection();

        public void MoveForward(IPosition position) => position.DecreaseY();

        public string Cardinal => "S";
    }
}