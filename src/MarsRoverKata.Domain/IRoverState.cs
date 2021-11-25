namespace MarsRoverKata.Domain
{
    public interface IRoverState
    {
        void RotateLeft();

        void RotateRight();

        void MoveForward();

        RoverDirection Direction { get; }
        
        RoverPosition Position { get; }
    }
}