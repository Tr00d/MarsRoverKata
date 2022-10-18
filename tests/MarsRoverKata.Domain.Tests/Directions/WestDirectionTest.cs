using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class WestDirectionTest
    {
        private readonly WestDirection direction;
        private readonly Mock<IPosition> mockPosition;

        public WestDirectionTest()
        {
            this.direction = new WestDirection();
            this.mockPosition = new Mock<IPosition>();
        }

        [Fact]
        public void Cardinal_ShouldReturnW() => this.direction.Cardinal.Should().Be("W");

        [Fact]
        public void GetLeftDirection_ShouldReturnSouthDirection()
        {
            IDirection southDirection = this.direction.GetLeftDirection();
            southDirection.Should().BeOfType<SouthDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnNorthDirection()
        {
            IDirection northDirection = this.direction.GetRightDirection();
            northDirection.Should().BeOfType<NorthDirection>();
        }

        [Fact]
        public void MoveForward_ShouldDecreaseXCoordinate()
        {
            this.direction.MoveForward(this.mockPosition.Object);
            this.mockPosition.Verify(position => position.DecreaseX(), Times.Once);
        }
    }
}