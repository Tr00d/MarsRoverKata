using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.Directions
{
    public class EastDirection : IDirection
    {
        public IDirection GetLeftDirection() => new NorthDirection();

        public IDirection GetRightDirection() => new SouthDirection();

        public void MoveForward(IPosition position) => position.IncreaseX();

        public string Cardinal => "E";
    }
}