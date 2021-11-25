using System;
using AutoFixture;
using FluentAssertions;
using LanguageExt;
using MarsRoverKata.Domain.Directions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests
{
    public class RoverStateTest
    {
        private readonly Fixture fixture;
        private readonly Mock<IDirection> mockDirection;

        public RoverStateTest()
        {
            fixture = new Fixture();
            mockDirection = new Mock<IDirection>();
        }

        [Fact]
        public void State_ShouldHaveNorthDirection_GivenIsDefault() =>
            new RoverState().Direction.Cardinal.Should().Be("N");

        [Fact]
        public void State_ShouldHaveZeroAsX_GivenIsDefault() => new RoverState().Position.X.Should().Be(0);

        [Fact]
        public void State_ShouldHaveZeroAsY_GivenIsDefault() => new RoverState().Position.Y.Should().Be(0);

        [Fact]
        public void RotateLeft_ShouldModifyDirectionToLeftDirection()
        {
            IDirection leftDirection = new Mock<IDirection>().Object;
            this.mockDirection.Setup(direction => direction.GetLeftDirection()).Returns(leftDirection);
            RoverState state = new RoverState(this.mockDirection.Object, this.fixture.Create<RoverPosition>());
            state.RotateLeft();
            state.Direction.Should().Be(leftDirection);
        }

        [Fact]

        public void RotateLeft_ShouldModifyDirectionToRightDirection()
        {
            IDirection rightDirection = new Mock<IDirection>().Object;
            this.mockDirection.Setup(direction => direction.GetRightDirection()).Returns(rightDirection);
            RoverState state = new RoverState(this.mockDirection.Object, this.fixture.Create<RoverPosition>());
            state.RotateRight();
            state.Direction.Should().Be(rightDirection);
        }

        [Fact]
        public void MoveForward_ShouldUpdateCoordinate()
        {
            RoverPosition position = this.fixture.Create<RoverPosition>();
            RoverPosition newPosition = this.fixture.Create<RoverPosition>();
            this.mockDirection.Setup(direction => direction.MoveForward(position)).Returns(newPosition);
            RoverState state = new RoverState(this.mockDirection.Object, position);
            state.MoveForward();
            state.Position.Should().Be(newPosition);
        }
    }
}