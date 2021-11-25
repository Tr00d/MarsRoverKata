using System;
using AutoFixture;
using FluentAssertions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests
{
    public class RoverTest
    {
        private Fixture fixture;
        private Rover rover;
        private Mock<IRoverState> mockState;
        public RoverTest()
        {
            fixture = new Fixture();
            mockState = new Mock<IRoverState>();
            rover = new(fixture.Create<Grid>(), mockState.Object);
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
            mockState = new Mock<IRoverState>(MockBehavior.Strict);
            rover = new(fixture.Create<Grid>(), mockState.Object);
            MockSequence sequence = new MockSequence();
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