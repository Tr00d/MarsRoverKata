using FluentAssertions;
using MarsRoverKata.Domain.Grids;
using MarsRoverKata.Domain.Positions;
using Moq;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Positions
{
    public class PositionTest
    {
        private readonly Mock<IGrid> mockGrid;

        public PositionTest()
        {
            mockGrid = new Mock<IGrid>();
            mockGrid.SetupGet(grid => grid.Height).Returns(5);
            mockGrid.SetupGet(grid => grid.Width).Returns(5);
        }

        [Fact]
        public void X_ShouldReturnZero_GivenPositionIsDefault()
        {
            Position position = new(mockGrid.Object);
            position.X.Should().Be(0);
        }

        [Fact]
        public void Y_ShouldReturnZero_GivenPositionIsDefault()
        {
            Position position = new(mockGrid.Object);
            position.Y.Should().Be(0);
        }

        [Fact]
        public void IncreaseX_ShouldIncreaseXValue()
        {
            Position position = new(mockGrid.Object);
            int initialPosition = position.X;
            position.IncreaseX();
            position.X.Should().Be(++initialPosition);
        }

        [Fact]
        public void IncreaseX_ShouldSetZero_GivenXWasGridLimit()
        {
            Position position = new(mockGrid.Object);
            position.IncreaseX();
            position.IncreaseX();
            position.IncreaseX();
            position.IncreaseX();
            position.IncreaseX();
            position.X.Should().Be(0);
        }

        [Fact]
        public void IncreaseY_ShouldIncreaseYValue()
        {
            Position position = new(mockGrid.Object);
            int initialPosition = position.Y;
            position.IncreaseY();
            position.Y.Should().Be(++initialPosition);
        }

        [Fact]
        public void IncreaseY_ShouldSetZero_GivenYWasGridLimit()
        {
            Position position = new(mockGrid.Object);
            position.IncreaseY();
            position.IncreaseY();
            position.IncreaseY();
            position.IncreaseY();
            position.IncreaseY();
            position.Y.Should().Be(0);
        }

        [Fact]
        public void DecreaseX_ShouldDecreaseXValue()
        {
            Position position = new(mockGrid.Object);
            position.IncreaseX();
            int initialPosition = position.X;
            position.DecreaseX();
            position.X.Should().Be(--initialPosition);
        }

        [Fact]
        public void DecreaseX_ShouldMaxX_GivenXWasGridLimit()
        {
            Position position = new(mockGrid.Object);
            position.DecreaseX();
            position.X.Should().Be(mockGrid.Object.Width - 1);
        }

        [Fact]
        public void DecreaseY_ShouldDecreaseYValue()
        {
            Position position = new(mockGrid.Object);
            position.IncreaseY();
            int initialPosition = position.Y;
            position.DecreaseY();
            position.Y.Should().Be(--initialPosition);
        }

        [Fact]
        public void DecreaseY_ShouldMaxY_GivenYWasGridLimit()
        {
            Position position = new(mockGrid.Object);
            position.DecreaseY();
            position.Y.Should().Be(mockGrid.Object.Height - 1);
        }
    }
}