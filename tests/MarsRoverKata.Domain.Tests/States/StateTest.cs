using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Positions;
using MarsRoverKata.Domain.States;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.States
{
    public class StateTest
    {
        private readonly Fixture fixture;
        private readonly Mock<IDirection> mockDirection;
        private readonly Mock<IPosition> mockPosition;

        public StateTest()
        {
            fixture = new Fixture();
            mockDirection = new Mock<IDirection>();
            mockPosition = new Mock<IPosition>();
        }

        [Fact]
        public void RotateLeft_ShouldModifyDirectionToLeftDirection()
        {
            IDirection leftDirection = new Mock<IDirection>().Object;
            mockDirection.Setup(direction => direction.GetLeftDirection()).Returns(leftDirection);
            State state = new(mockDirection.Object, mockPosition.Object);
            state.RotateLeft();
            state.GetDirection().Should().Be(leftDirection.Cardinal);
        }

        [Fact]
        public void RotateLeft_ShouldModifyDirectionToRightDirection()
        {
            IDirection rightDirection = new Mock<IDirection>().Object;
            mockDirection.Setup(direction => direction.GetRightDirection()).Returns(rightDirection);
            State state = new(mockDirection.Object, mockPosition.Object);
            state.RotateRight();
            state.GetDirection().Should().Be(rightDirection.Cardinal);
        }

        [Fact]
        public void MoveForward_ShouldUpdateCoordinate()
        {
            State state = new(mockDirection.Object, mockPosition.Object);
            state.MoveForward();
            mockDirection.Verify(direction => direction.MoveForward(mockPosition.Object), Times.Once);
        }
    }
}