using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain.Commands
{
    public class MoveForwardCommand : IInputCommand
    {
        private const char acceptedInput = 'M';
        
        public bool CanExecuteInput(char input) => input == acceptedInput;

        public void ExecuteCommand(IState state) => state.MoveForward();
    }
}