using System;
using System.Collections.Generic;
using Dawn;
using MarsRoverKata.Domain.Directions;

namespace MarsRoverKata.Domain
{
    public class RoverState : IRoverState
    {
        public RoverState()
        {
            this.Direction = new NorthDirection();
            this.Position = new RoverPosition();
        }

        public RoverState(IDirection direction, RoverPosition position)
            : this()
        {
            this.Direction = Guard.Argument(direction, nameof(direction)).NotNull().Value;
            this.Position = Guard.Argument(position, nameof(position)).NotNull().Value;
        }
        
        public IDirection Direction { get; private set; }
        
        public RoverPosition Position { get; private set; }

        public void RotateLeft() => this.Direction = this.Direction.GetLeftDirection();

        public void RotateRight() => this.Direction = this.Direction.GetRightDirection();

        public void MoveForward() => this.Position = this.Direction.MoveForward(this.Position);
    }
}