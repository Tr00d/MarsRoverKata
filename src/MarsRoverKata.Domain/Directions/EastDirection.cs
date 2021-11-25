namespace MarsRoverKata.Domain.Directions
{
    public class EastDirection : IDirection
    {
        public IDirection GetLeftDirection() => new NorthDirection();

        public IDirection GetRightDirection() => new SouthDirection();

        public RoverPosition MoveForward(RoverPosition position) => new RoverPosition(position.X + 1, position.Y);

        public string Cardinal { get; } = "E";
    }
}