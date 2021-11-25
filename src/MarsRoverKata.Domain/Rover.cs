using System;
using System.Collections.Generic;
using System.Linq;
using Dawn;
using LanguageExt;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private Grid grid;
        private IRoverState state;

        public Rover(Grid grid, IRoverState state)
        {
            this.grid = Guard.Argument(grid, nameof(grid)).NotNull().Value;
            this.state = Guard.Argument(state, nameof(state)).NotNull().Value;
            this.actions = new Dictionary<char, Action>()
            {
                { 'M', this.state.MoveForward },
                { 'L', this.state.RotateLeft },
                { 'R', this.state.RotateRight },
            };
        }

        private readonly Dictionary<char, Action> actions;

        public void Execute(string input) => input.ToList().ForEach(command => actions[command]());

        public RoverDirection Direction => this.state.Direction;

        public RoverPosition Position => this.state.Position;
    }
}