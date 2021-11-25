namespace MarsRoverKata.Domain.Directions
{
    public interface IDirection
    {
        IDirection GetLeftDirection();

        IDirection GetRightDirection();

        RoverPosition MoveForward(RoverPosition position);
        
        string Cardinal { get; }
    }
}