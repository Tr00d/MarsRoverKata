using AutoFixture;
using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Domain.Tests
{
    public class RoverTest
    {
        private readonly Fixture fixture;

        public RoverTest()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void State_ShouldHaveNorthDirection_GivenIsDefault()
        {
            Rover rover = new(fixture.Create<Grid>());
            rover.State.Direction.Should().Be("N");
        }

        [Fact]
        public void State_ShouldHaveZeroAsX_GivenIsDefault()
        {
            Rover rover = new(fixture.Create<Grid>());
            rover.State.X.Should().Be(0);
        }

        [Fact]
        public void State_ShouldHaveZeroAsY_GivenIsDefault()
        {
            Rover rover = new(fixture.Create<Grid>());
            rover.State.Y.Should().Be(0);
        }
    }
}