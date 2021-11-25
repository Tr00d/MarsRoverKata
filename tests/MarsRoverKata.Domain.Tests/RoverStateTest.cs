using System;
using AutoFixture;
using FluentAssertions;
using LanguageExt;
using Xunit;

namespace MarsRoverKata.Domain.Tests
{
    public class RoverStateTest
    {
        private readonly Fixture fixture;
        public RoverStateTest()
        {
            fixture = new Fixture();
        }
        
        [Fact]
        public void State_ShouldHaveNorthDirection_GivenIsDefault() => new RoverState().Direction.Direction.Should().Be("N");

        [Fact]
        public void State_ShouldHaveZeroAsX_GivenIsDefault() => new RoverState().Position.X.Should().Be(0);

        [Fact]
        public void State_ShouldHaveZeroAsY_GivenIsDefault() => new RoverState().Position.Y.Should().Be(0);

        [Theory]
        [InlineData("N", "W")]
        [InlineData("W", "S")]
        [InlineData("S", "E")]
        [InlineData("E", "N")]
        public void RotateLeft_ShouldModifyDirectionToLeftCardinal(string startingDirection, string endingDirection)
        {
            RoverDirection direction = new RoverDirection(startingDirection);
            RoverState state = new RoverState(direction, this.fixture.Create<RoverPosition>());
            state.RotateLeft();
            state.Direction.Direction.Should().Be(endingDirection);
        }
        
        [Theory]
        [InlineData("N", "E")]
        [InlineData("W", "N")]
        [InlineData("S", "W")]
        [InlineData("E", "S")]
        public void RotateLeft_ShouldModifyDirectionToRightCardinal(string startingDirection, string endingDirection)
        {
            RoverDirection direction = new RoverDirection(startingDirection);
            RoverState state = new RoverState(direction, this.fixture.Create<RoverPosition>());
            state.RotateRight();
            state.Direction.Direction.Should().Be(endingDirection);
        }

        [Theory]
        [InlineData("N", 0, 0, 0, 1)]
        public void MoveForward_ShouldUpdateCoordinate(string direction, int startingX, int startingY, int endingX, int endingY)
        {
            RoverState state = new RoverState(new RoverDirection(direction),
                new RoverPosition(startingX, startingY));
            state.MoveForward();
            state.Position.X.Should().Be(endingX);
            state.Position.Y.Should().Be(endingY);
        }
    }
}