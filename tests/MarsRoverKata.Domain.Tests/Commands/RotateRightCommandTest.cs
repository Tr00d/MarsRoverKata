using FluentAssertions;
using MarsRoverKata.Domain.Commands;
using MarsRoverKata.Domain.States;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Commands
{
    public class RotateRightCommandTest
    {
        private readonly RotateRightCommand command;
        private readonly Mock<IState> mockState;

        public RotateRightCommandTest()
        {
            command = new RotateRightCommand();
            mockState = new Mock<IState>();
        }

        [Fact]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsAccepted()
        {
            bool result = command.CanExecuteInput('R');
            result.Should().Be(true);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('r')]
        [InlineData('M')]
        [InlineData('L')]
        public void CanExecuteInput_ShouldReturnTrue_GivenInputIsNotAccepted(char input)
        {
            bool result = command.CanExecuteInput(input);
            result.Should().Be(false);
        }

        [Fact]
        public void ExecuteCommand_ShouldExecuteRotateLeft()
        {
            command.ExecuteCommand(mockState.Object);
            mockState.Verify(state => state.RotateRight(), Times.Once);
        }
    }
}