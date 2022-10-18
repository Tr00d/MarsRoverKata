using Dawn;
using MarsRoverKata.Domain.Commands;
using MarsRoverKata.Domain.Grids;
using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain
{
    public class Rover
    {
        private readonly IEnumerable<IInputCommand> inputCommands;
        private readonly IState state;

        public Rover(IState state, IEnumerable<IInputCommand> inputCommands)
        {
            this.state = Guard.Argument(state, nameof(state)).NotNull().Value;
            this.inputCommands = inputCommands;
        }

        public string Direction => this.state.GetDirection();

        public int X => this.state.GetXCoordinate();

        public int Y => this.state.GetYCoordinate();

        public bool HasObstacleWarning { get; private set; }

        public void Execute(string input) => input.ToList().ForEach(this.ExecuteCommand);

        private void ExecuteCommand(char command)
        {
            if (this.HasObstacleWarning ||
                !this.inputCommands.Any(inputCommand => inputCommand.CanExecuteInput(command)))
            {
                return;
            }

            try
            {
                this.inputCommands.First(inputCommand => inputCommand.CanExecuteInput(command))
                    .ExecuteCommand(this.state);
            }
            catch (ObstacleException)
            {
                this.HasObstacleWarning = true;
            }
        }
    }
}