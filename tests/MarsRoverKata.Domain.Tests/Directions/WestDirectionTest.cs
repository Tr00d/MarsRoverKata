using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class WestDirectionTest
    {
        private Fixture fixture;
        private WestDirection direction;
        public WestDirectionTest()
        {
            this.direction = new WestDirection();
            this.fixture = new Fixture();
        }

        [Fact]
        public void Cardinal_ShouldReturnW() => direction.Cardinal.Should().Be("W");

        [Fact]
        public void GetLeftDirection_ShouldReturnSouthDirection()
        {
            IDirection southDirection = direction.GetLeftDirection();
            southDirection.Should().BeOfType<SouthDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnNorthDirection()
        {
            IDirection northDirection = direction.GetRightDirection();
            northDirection.Should().BeOfType<NorthDirection>();
        }

        [Fact]
        public void MoveForward_ShouldReturnPositionWithDecreasedXCoordinate()
        {
            RoverPosition position = this.fixture.Create<RoverPosition>();
            RoverPosition result = direction.MoveForward(position);
            result.Y.Should().Be(position.Y);
            result.X.Should().Be(position.X - 1);
        }
    }
}