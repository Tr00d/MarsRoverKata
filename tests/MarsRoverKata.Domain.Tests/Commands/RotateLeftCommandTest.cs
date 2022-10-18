using FluentAssertions;
using MarsRoverKata.Domain.Commands;
using MarsRoverKata.Domain.States;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Commands
{
    public class RotateLeftCommandTest
    {
        private readonly RotateLeftCommand command;
        private readonly Mock<IState> mockState;

        public RotateLeftCommandTest()
        {
            this.command = new RotateLeftCommand();
            this.mockState = new Mock<IState>();
        }

        [Fact]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsAccepted()
        {
            bool result = this.command.CanExecuteInput('L');
            result.Should().Be(true);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('l')]
        [InlineData('M')]
        [InlineData('R')]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsNotAccepted(char input)
        {
            bool result = this.command.CanExecuteInput(input);
            result.Should().Be(false);
        }

        [Fact]
        public void ExecuteCommand_ShouldExecuteRotateLeft()
        {
            this.command.ExecuteCommand(this.mockState.Object);
            this.mockState.Verify(state => state.RotateLeft(), Times.Once);
        }
    }
}