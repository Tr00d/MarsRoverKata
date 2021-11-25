using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class SouthDirectionTest
    {
        private Fixture fixture;
        private SouthDirection direction;
        public SouthDirectionTest()
        {
            this.direction = new SouthDirection();
            this.fixture = new Fixture();
        }

        [Fact]
        public void Cardinal_ShouldReturnS() => direction.Cardinal.Should().Be("S");

        [Fact]
        public void GetLeftDirection_ShouldReturnEastDirection()
        {
            IDirection eastDirection = direction.GetLeftDirection();
            eastDirection.Should().BeOfType<EastDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnWestDirection()
        {
            IDirection westDirection = direction.GetRightDirection();
            westDirection.Should().BeOfType<WestDirection>();
        }

        [Fact]
        public void MoveForward_ShouldReturnPositionWithDecreasedYCoordinate()
        {
            RoverPosition position = this.fixture.Create<RoverPosition>();
            RoverPosition result = direction.MoveForward(position);
            result.Y.Should().Be(position.Y - 1);
            result.X.Should().Be(position.X);
        }
    }
}