using System;
using System.Collections.Generic;
using System.Linq;
using Dawn;
using LanguageExt;
using MarsRoverKata.Domain.Commands;
using MarsRoverKata.Domain.Grids;
using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private readonly IState state;
        private readonly IEnumerable<IInputCommand> inputCommands;

        public Rover(IState state, IEnumerable<IInputCommand> inputCommands)
        {
            this.state = Guard.Argument(state, nameof(state)).NotNull().Value;
            this.inputCommands = inputCommands;
        }

        public string Direction => state.GetDirection();

        public int X => state.GetXCoordinate();

        public int Y => state.GetYCoordinate();

        public bool HasObstacleWarning { get; private set; }

        public void Execute(string input) => input.ToList().ForEach(ExecuteCommand);

        private void ExecuteCommand(char command)
        {
            if (HasObstacleWarning || !inputCommands.Any(inputCommand => inputCommand.CanExecuteInput(command)))
            {
                return;
            }

            try
            {
                inputCommands.First(inputCommand => inputCommand.CanExecuteInput(command)).ExecuteCommand(this.state);
            }
            catch (ObstacleException)
            {
                HasObstacleWarning = true;
            }
        }
    }
}