using System;
using System.Collections.Generic;
using System.Linq;
using Dawn;
using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private readonly Dictionary<char, Action> actions;
        private readonly IState state;

        public Rover(IState state)
        {
            this.state = Guard.Argument(state, nameof(state)).NotNull().Value;
            actions = new Dictionary<char, Action>
            {
                {'M', this.state.MoveForward},
                {'L', this.state.RotateLeft},
                {'R', this.state.RotateRight}
            };
        }

        public string Direction => state.GetDirection();

        public int X => state.GetXCoordinate();

        public int Y => state.GetYCoordinate();

        public void Execute(string input) => input.ToList().ForEach(command => actions[command]());
    }
}