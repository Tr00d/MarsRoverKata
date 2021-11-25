namespace MarsRoverKata.Domain.Directions
{
    public class WestDirection : IDirection
    {
        public IDirection GetLeftDirection() => new SouthDirection();

        public IDirection GetRightDirection() => new NorthDirection();

        public RoverPosition MoveForward(RoverPosition position) => new RoverPosition(position.X - 1, position.Y);

        public string Cardinal { get; } = "W";
    }
}