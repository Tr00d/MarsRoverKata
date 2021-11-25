using MarsRoverKata.Domain.States;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests
{
    public class RoverTest
    {
        private Mock<IState> mockState;
        private Rover rover;

        public RoverTest()
        {
            mockState = new Mock<IState>();
            rover = new Rover(mockState.Object);
        }

        [Fact]
        public void Execute_ShouldRotateStateToLeft_GivenInputIsL()
        {
            rover.Execute("L");
            mockState.Verify(state => state.RotateLeft(), Times.Once);
        }

        [Fact]
        public void Execute_ShouldRotateStateToRight_GivenInputIsR()
        {
            rover.Execute("R");
            mockState.Verify(state => state.RotateRight(), Times.Once);
        }

        [Fact]
        public void Execute_ShouldMoveStateForward_GivenInputIsM()
        {
            rover.Execute("M");
            mockState.Verify(state => state.MoveForward(), Times.Once);
        }

        [Fact]
        public void Execute_ShouldUpdateStateInCorrectSequence_GivenInputContainsMultipleCommands()
        {
            const string input = "MMLMRMMLM";
            mockState = new Mock<IState>(MockBehavior.Strict);
            rover = new Rover(mockState.Object);
            MockSequence sequence = new();
            mockState.InSequence(sequence).Setup(state => state.MoveForward());
            mockState.InSequence(sequence).Setup(state => state.MoveForward());
            mockState.InSequence(sequence).Setup(state => state.RotateLeft());
            mockState.InSequence(sequence).Setup(state => state.MoveForward());
            mockState.InSequence(sequence).Setup(state => state.RotateRight());
            mockState.InSequence(sequence).Setup(state => state.MoveForward());
            mockState.InSequence(sequence).Setup(state => state.MoveForward());
            mockState.InSequence(sequence).Setup(state => state.RotateLeft());
            mockState.InSequence(sequence).Setup(state => state.MoveForward());
            rover.Execute(input);
            mockState.Verify(state => state.MoveForward(), Times.Exactly(6));
            mockState.Verify(state => state.RotateLeft(), Times.Exactly(2));
            mockState.Verify(state => state.RotateRight(), Times.Exactly(1));
        }
    }
}