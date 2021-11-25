using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.Directions
{
    public class NorthDirection : IDirection
    {
        public IDirection GetLeftDirection() => new WestDirection();

        public IDirection GetRightDirection() => new EastDirection();

        public void MoveForward(IPosition position) => position.IncreaseY();

        public string Cardinal { get; } = "N";
    }
}