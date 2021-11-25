namespace MarsRoverKata.Domain.States
{
    public interface IState
    {
        void RotateLeft();

        void RotateRight();

        void MoveForward();

        string GetDirection();

        int GetXCoordinate();

        int GetYCoordinate();
    }
}