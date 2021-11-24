using System;
using Dawn;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private Grid grid;

        public Rover(Grid grid)
        {
            this.grid = Guard.Argument(grid, nameof(grid)).NotNull().Value;
            State = new RoverState
            {
                Direction = "N",
                X = 0,
                Y = 0
            };
        }

        public Rover(Grid grid, RoverState state)
            : this(grid)
        {
            State = Guard.Argument(state, nameof(state)).NotNull().Value;
        }

        public RoverState State { get; set; }

        public string Execute(string command)
        {
            throw new NotImplementedException();
        }
    }
}