using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Domain.Commands
{
    public interface IInputCommand
    {
        bool CanExecuteInput(char input);

        void ExecuteCommand(IState state);
    }
}