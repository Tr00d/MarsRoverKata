using System;
using System.Collections.Generic;
using Dawn;

namespace MarsRoverKata.Domain
{
    public class RoverState : IRoverState
    {
        private readonly Dictionary<string, string> rotationsLeft = new Dictionary<string, string>()
        {
            { "N", "W" },
            { "W", "S" },
            { "S", "E" },
            { "E", "N" },
        };
        
        private readonly Dictionary<string, string> rotationsRight = new Dictionary<string, string>()
        {
            { "N", "E" },
            { "W", "N" },
            { "S", "W" },
            { "E", "S" },
        };

        public RoverState()
        {
            this.Direction = new RoverDirection();
            this.Position = new RoverPosition();
        }

        public RoverState(RoverDirection direction, RoverPosition position)
            : this()
        {
            this.Direction = Guard.Argument(direction, nameof(direction)).NotNull().Value;
            this.Position = Guard.Argument(position, nameof(position)).NotNull().Value;
        }
        
        public RoverDirection Direction { get; private set; }
        
        public RoverPosition Position { get; private set; }

        public void RotateLeft() => this.Direction = new RoverDirection(rotationsLeft[this.Direction.Direction]);

        public void RotateRight() => this.Direction = new RoverDirection(rotationsRight[this.Direction.Direction]);

        public void MoveForward()
        {
            this.Position = new RoverPosition(0, 1);
        }
    }
}