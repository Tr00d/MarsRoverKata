using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class NorthDirectionTest
    {
        private Fixture fixture;
        private NorthDirection direction;
        public NorthDirectionTest()
        {
            this.direction = new NorthDirection();
            this.fixture = new Fixture();
        }

        [Fact]
        public void Cardinal_ShouldReturnN() => direction.Cardinal.Should().Be("N");

        [Fact]
        public void GetLeftDirection_ShouldReturnWestDirection()
        {
            IDirection westDirection = direction.GetLeftDirection();
            westDirection.Should().BeOfType<WestDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnEastDirection()
        {
            IDirection eastDirection = direction.GetRightDirection();
            eastDirection.Should().BeOfType<EastDirection>();
        }

        [Fact]
        public void MoveForward_ShouldReturnPositionWithIncreasedYCoordinate()
        {
            RoverPosition position = this.fixture.Create<RoverPosition>();
            RoverPosition result = direction.MoveForward(position);
            result.Y.Should().Be(position.Y + 1);
            result.X.Should().Be(position.X);
        }
    }
}