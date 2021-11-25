using AutoFixture;
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
            direction = new SouthDirection();
            mockPosition = new Mock<IPosition>();
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
        public void MoveForward_ShouldDecreaseYCoordinate()
        {
            direction.MoveForward(mockPosition.Object);
            mockPosition.Verify(position => position.DecreaseY(), Times.Once);
        }
    }
}