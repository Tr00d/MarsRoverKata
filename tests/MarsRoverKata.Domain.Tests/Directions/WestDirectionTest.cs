using AutoFixture;
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
        private Fixture fixture;
        private readonly Mock<IPosition> mockPosition;

        public WestDirectionTest()
        {
            direction = new WestDirection();
            fixture = new Fixture();
            mockPosition = new Mock<IPosition>();
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
        public void MoveForward_ShouldDecreaseXCoordinate()
        {
            direction.MoveForward(mockPosition.Object);
            mockPosition.Verify(position => position.DecreaseX(), Times.Once);
        }
    }
}