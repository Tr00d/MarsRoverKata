using MarsRoverKata.Domain.Directions;

namespace MarsRoverKata.Domain
{
    public interface IRoverState
    {
        void RotateLeft();

        void RotateRight();

        void MoveForward();

        IDirection Direction { get; }
        
        RoverPosition Position { get; }
    }
}