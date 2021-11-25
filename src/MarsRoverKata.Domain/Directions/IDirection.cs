using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.Directions
{
    public interface IDirection
    {
        string Cardinal { get; }
        IDirection GetLeftDirection();

        IDirection GetRightDirection();

        void MoveForward(IPosition position);
    }
}