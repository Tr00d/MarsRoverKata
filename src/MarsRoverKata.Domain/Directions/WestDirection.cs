using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.Directions
{
    public class WestDirection : IDirection
    {
        public IDirection GetLeftDirection() => new SouthDirection();

        public IDirection GetRightDirection() => new NorthDirection();

        public void MoveForward(IPosition position) => position.DecreaseX();

        public string Cardinal => "W";
    }
}