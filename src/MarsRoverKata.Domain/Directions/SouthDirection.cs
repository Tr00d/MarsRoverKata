namespace MarsRoverKata.Domain.Directions
{
    public class SouthDirection : IDirection
    {
        public IDirection GetLeftDirection() => new EastDirection();

        public IDirection GetRightDirection() => new WestDirection();

        public RoverPosition MoveForward(RoverPosition position) => new RoverPosition(position.X, position.Y - 1);

        public string Cardinal { get; } = "S";
    }
}