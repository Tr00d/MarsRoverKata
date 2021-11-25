using Dawn;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.States
{
    public class State : IState
    {
        private IDirection direction;

        private readonly IPosition position;

        public State(IDirection direction, IPosition position)
        {
            this.direction = Guard.Argument(direction, nameof(direction)).NotNull().Value;
            this.position = Guard.Argument(position, nameof(position)).NotNull().Value;
        }

        public void RotateLeft() => direction = direction.GetLeftDirection();

        public void RotateRight() => direction = direction.GetRightDirection();

        public void MoveForward() => direction.MoveForward(position);

        public string GetDirection() => direction.Cardinal;

        public int GetXCoordinate() => position.X;

        public int GetYCoordinate() => position.Y;
    }
}