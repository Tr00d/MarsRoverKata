namespace MarsRoverKata.Domain.Directions
{
    public class NorthDirection : IDirection
    {
        public IDirection GetLeftDirection() => new WestDirection();

        public IDirection GetRightDirection() => new EastDirection();

        public RoverPosition MoveForward(RoverPosition position) => new RoverPosition(position.X, position.Y + 1);

        public string Cardinal { get; } = "N";
    }
}