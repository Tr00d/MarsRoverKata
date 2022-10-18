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
            this.command = new MoveForwardCommand();
            this.mockState = new Mock<IState>();
        }

        [Fact]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsAccepted()
        {
            bool result = this.command.CanExecuteInput('M');
            result.Should().Be(true);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('m')]
        [InlineData('L')]
        [InlineData('R')]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsNotAccepted(char input)
        {
            bool result = this.command.CanExecuteInput(input);
            result.Should().Be(false);
        }

        [Fact]
        public void ExecuteCommand_ShouldExecuteMoveForward()
        {
            this.command.ExecuteCommand(this.mockState.Object);
            this.mockState.Verify(state => state.MoveForward(), Times.Once);
        }
    }
}