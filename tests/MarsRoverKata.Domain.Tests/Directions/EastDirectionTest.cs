using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class EastDirectionTest
    {
        private Fixture fixture;
        private EastDirection direction;
        public EastDirectionTest()
        {
            this.direction = new EastDirection();
            this.fixture = new Fixture();
        }

        [Fact]
        public void Cardinal_ShouldReturnE() => direction.Cardinal.Should().Be("E");

        [Fact]
        public void GetLeftDirection_ShouldReturnNorthDirection()
        {
            IDirection northDirection = direction.GetLeftDirection();
            northDirection.Should().BeOfType<NorthDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnSouthDirection()
        {
            IDirection southDirection = direction.GetRightDirection();
            southDirection.Should().BeOfType<SouthDirection>();
        }

        [Fact]
        public void MoveForward_ShouldReturnPositionWithIncreasedXCoordinate()
        {
            RoverPosition position = this.fixture.Create<RoverPosition>();
            RoverPosition result = direction.MoveForward(position);
            result.Y.Should().Be(position.Y);
            result.X.Should().Be(position.X + 1);
        }
    }
}