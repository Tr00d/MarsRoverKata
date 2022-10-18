using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain.Commands
{
    public class RotateLeftCommand : IInputCommand
    {
        private const char acceptedInput = 'L';

        public bool CanExecuteInput(char input) => input == acceptedInput;

        public void ExecuteCommand(IState state) => state.RotateLeft();
    }
}