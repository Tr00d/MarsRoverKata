using AutoFixture;
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
        private Fixture fixture;
        private readonly Mock<IPosition> mockPosition;

        public NorthDirectionTest()
        {
            direction = new NorthDirection();
            fixture = new Fixture();
            mockPosition = new Mock<IPosition>();
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
        public void MoveForward_ShouldIncreaseYCoordinate()
        {
            direction.MoveForward(mockPosition.Object);
            mockPosition.Verify(position => position.IncreaseY(), Times.Once);
        }
    }
}