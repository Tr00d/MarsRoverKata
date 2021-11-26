using FluentAssertions;
using MarsRoverKata.Domain.Commands;
using MarsRoverKata.Domain.States;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Commands
{
    public class MoveForwardCommandTest
    {
        private readonly MoveForwardCommand command;
        private readonly Mock<IState> mockState;

        public MoveForwardCommandTest()
        {
            command = new MoveForwardCommand();
            mockState = new Mock<IState>();
        }

        [Fact]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsAccepted()
        {
            bool result = command.CanExecuteInput('M');
            result.Should().Be(true);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('m')]
        [InlineData('L')]
        [InlineData('R')]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsNotAccepted(char input)
        {
            bool result = command.CanExecuteInput(input);
            result.Should().Be(false);
        }

        [Fact]
        public void ExecuteCommand_ShouldExecuteMoveForward()
        {
            command.ExecuteCommand(mockState.Object);
            mockState.Verify(state => state.MoveForward(), Times.Once);
        }
    }
}