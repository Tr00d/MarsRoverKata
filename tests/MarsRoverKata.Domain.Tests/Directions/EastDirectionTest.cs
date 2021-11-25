using AutoFixture;
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
        private Fixture fixture;
        private readonly Mock<IPosition> mockPosition;

        public EastDirectionTest()
        {
            direction = new EastDirection();
            mockPosition = new Mock<IPosition>();
            fixture = new Fixture();
        }

        [Fact]
        public void Cardinal_ShouldReturnE() => direction.Cardinal.Should().Be("E");

        [Fact]
        public void GetLeftDirection_ShouldReturnNorthDirection()
        {
            IDirection northDirection = direction.GetLeftDirection();
            northDirection.Should().BeOfType<NorthDirection>();
        }

        [Fact]
        public void GetRightDirection_ShouldReturnSouthDirection()
        {
            IDirection southDirection = direction.GetRightDirection();
            southDirection.Should().BeOfType<SouthDirection>();
        }

        [Fact]
        public void MoveForward_ShouldIncreaseXCoordinate()
        {
            direction.MoveForward(mockPosition.Object);
            mockPosition.Verify(position => position.IncreaseX(), Times.Once);
        }
    }
}