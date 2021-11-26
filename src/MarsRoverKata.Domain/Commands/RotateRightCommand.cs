using System.ComponentModel.Design;
using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain.Commands
{
    public class RotateRightCommand : IInputCommand
    {
        private const char acceptedInput = 'R';
        
        public bool CanExecuteInput(char input) => input == acceptedInput;

        public void ExecuteCommand(IState state) => state.RotateRight();
    }
}