using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Commands;
using MarsRoverKata.Domain.Grids;
using MarsRoverKata.Domain.States;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests
{
    public class RoverTest
    {
        private readonly Fixture fixture;
        private readonly Mock<IInputCommand> mockCommand;
        private Mock<IState> mockState;
        private Rover rover;

        public RoverTest()
        {
            this.fixture = new Fixture();
            this.mockCommand = new Mock<IInputCommand>();
            this.mockState = new Mock<IState>();
            this.rover = new Rover(this.mockState.Object, new List<IInputCommand> {this.mockCommand.Object});
        }

        [Fact]
        public void Execute_ShouldExecuteCommand_GivenInputCanBeExecuted()
        {
            string input = "LRLRLRMMM";
            this.mockCommand.Setup(command => command.CanExecuteInput('M')).Returns(true);
            this.rover.Execute(input);
            this.mockCommand.Verify(command => command.ExecuteCommand(this.mockState.Object), Times.Exactly(3));
        }

        [Fact]
        public void Execute_ShouldExecuteCommandsInCorrectSequence_GivenInputContainsMultipleCommands()
        {
            Mock<IInputCommand> mockCommand1 = new Mock<IInputCommand>();
            Mock<IInputCommand> mockCommand2 = new Mock<IInputCommand>();
            mockCommand1.Setup(command => command.CanExecuteInput('A')).Returns(true);
            mockCommand2.Setup(command => command.CanExecuteInput('B')).Returns(true);
            const string input = "ABABAABB";
            this.mockState = new Mock<IState>(MockBehavior.Strict);
            this.rover = new Rover(this.mockState.Object,
                new List<IInputCommand> {mockCommand1.Object, mockCommand2.Object});
            MockSequence sequence = new();
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            this.rover.Execute(input);
            mockCommand2.Verify(command => command.ExecuteCommand(this.mockState.Object), Times.Exactly(4));
            mockCommand2.Verify(command => command.ExecuteCommand(this.mockState.Object), Times.Exactly(4));
        }

        [Fact]
        public void Execute_ShouldProvideObstacleWarning_GivenStateProvideObstacleFeedback()
        {
            string input = this.fixture.Create<string>();
            this.mockCommand.Setup(command => command.CanExecuteInput(It.IsAny<char>())).Returns(true);
            this.mockCommand.Setup(command => command.ExecuteCommand(this.mockState.Object))
                .Throws<ObstacleException>();
            this.rover.Execute(input);
            this.rover.HasObstacleWarning.Should().Be(true);
        }

        [Fact]
        public void Execute_ShouldStop_GivenStateProvideObstacleFeedback()
        {
            const string input = "MMMMMMMMMM";
            this.mockState = new Mock<IState>(MockBehavior.Strict);
            Mock<IInputCommand> mockCommand = new Mock<IInputCommand>();
            mockCommand.Setup(command => command.CanExecuteInput('M')).Returns(true);
            this.rover = new Rover(this.mockState.Object, new List<IInputCommand> {mockCommand.Object});
            MockSequence sequence = new();
            mockCommand.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object))
                .Throws<ObstacleException>();
            mockCommand.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            this.rover.Execute(input);
            mockCommand.Verify(command => command.ExecuteCommand(this.mockState.Object), Times.Exactly(3));
        }

        [Fact]
        public void Execute_ShouldPreventFurtherMovement_GivenStateProvideObstacleFeedback()
        {
            Mock<IInputCommand> mockCommand1 = new Mock<IInputCommand>();
            Mock<IInputCommand> mockCommand2 = new Mock<IInputCommand>();
            mockCommand1.Setup(command => command.CanExecuteInput('A')).Returns(true);
            mockCommand2.Setup(command => command.CanExecuteInput('B')).Returns(true);
            this.mockState = new Mock<IState>(MockBehavior.Strict);
            this.rover = new Rover(this.mockState.Object,
                new List<IInputCommand> {mockCommand1.Object, mockCommand2.Object});
            MockSequence sequence = new();
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object))
                .Throws<ObstacleException>();
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand1.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            mockCommand2.InSequence(sequence).Setup(command => command.ExecuteCommand(this.mockState.Object));
            this.rover.Execute("A");
            this.rover.Execute("B");
            this.rover.Execute("A");
            this.rover.Execute("B");
            this.rover.Execute("A");
            this.rover.Execute("A");
            this.rover.Execute("B");
            this.rover.Execute("B");
            mockCommand1.Verify(command => command.ExecuteCommand(this.mockState.Object), Times.Exactly(1));
            mockCommand1.Verify(command => command.ExecuteCommand(this.mockState.Object), Times.Exactly(1));
        }
    }
}