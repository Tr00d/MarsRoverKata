using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class SouthDirectionTest
    {
        private readonly SouthDirection direction;
        private readonly Mock<IPosition> mockPosition;

        public SouthDirectionTest()
        {
            this.direction = new SouthDirection();
            this.mockPosition = new Mock<IPosition>();
        }

        [Fact]
        public void Cardinal_ShouldReturnS() => this.direction.Cardinal.Should().Be("S");

        [Fact]
        public void GetLeftDirection_ShouldReturnEastDirection()
        {
            IDirection eastDirection = this.direction.GetLeftDirection();
            eastDirection.Should().BeOfType<EastDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnWestDirection()
        {
            IDirection westDirection = this.direction.GetRightDirection();
            westDirection.Should().BeOfType<WestDirection>();
        }

        [Fact]
        public void MoveForward_ShouldDecreaseYCoordinate()
        {
            this.direction.MoveForward(this.mockPosition.Object);
            this.mockPosition.Verify(position => position.DecreaseY(), Times.Once);
        }
    }
}