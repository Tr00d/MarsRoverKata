using Dawn;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;

namespace MarsRoverKata.Domain.States
{
    public class State : IState
    {
        private readonly IPosition position;
        private IDirection direction;

        public State(IDirection direction, IPosition position)
        {
            this.direction = Guard.Argument(direction, nameof(direction)).NotNull().Value;
            this.position = Guard.Argument(position, nameof(position)).NotNull().Value;
        }

        public void RotateLeft() => this.direction = this.direction.GetLeftDirection();

        public void RotateRight() => this.direction = this.direction.GetRightDirection();

        public void MoveForward() => this.direction.MoveForward(this.position);

        public string GetDirection() => this.direction.Cardinal;

        public int GetXCoordinate() => this.position.Location.X;

        public int GetYCoordinate() => this.position.Location.Y;
    }
}