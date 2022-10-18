using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class NorthDirectionTest
    {
        private readonly NorthDirection direction;
        private readonly Mock<IPosition> mockPosition;

        public NorthDirectionTest()
        {
            this.direction = new NorthDirection();
            this.mockPosition = new Mock<IPosition>();
        }

        [Fact]
        public void Cardinal_ShouldReturnN() => this.direction.Cardinal.Should().Be("N");

        [Fact]
        public void GetLeftDirection_ShouldReturnWestDirection()
        {
            IDirection westDirection = this.direction.GetLeftDirection();
            westDirection.Should().BeOfType<WestDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnEastDirection()
        {
            IDirection eastDirection = this.direction.GetRightDirection();
            eastDirection.Should().BeOfType<EastDirection>();
        }

        [Fact]
        public void MoveForward_ShouldIncreaseYCoordinate()
        {
            this.direction.MoveForward(this.mockPosition.Object);
            this.mockPosition.Verify(position => position.IncreaseY(), Times.Once);
        }
    }
}