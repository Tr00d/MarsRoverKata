using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Directions
{
    public class EastDirectionTest
    {
        private readonly EastDirection direction;
        private readonly Mock<IPosition> mockPosition;

        public EastDirectionTest()
        {
            this.direction = new EastDirection();
            this.mockPosition = new Mock<IPosition>();
        }

        [Fact]
        public void Cardinal_ShouldReturnE() => this.direction.Cardinal.Should().Be("E");

        [Fact]
        public void GetLeftDirection_ShouldReturnNorthDirection()
        {
            IDirection northDirection = this.direction.GetLeftDirection();
            northDirection.Should().BeOfType<NorthDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnSouthDirection()
        {
            IDirection southDirection = this.direction.GetRightDirection();
            southDirection.Should().BeOfType<SouthDirection>();
        }

        [Fact]
        public void MoveForward_ShouldIncreaseXCoordinate()
        {
            this.direction.MoveForward(this.mockPosition.Object);
            this.mockPosition.Verify(position => position.IncreaseX(), Times.Once);
        }
    }
}