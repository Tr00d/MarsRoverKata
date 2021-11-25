using System.Drawing;
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
            mockGrid.SetupGet(grid => grid.MaxPoint).Returns(new Point(5, 5));
        }

        [Fact]
        public void X_ShouldReturnZero_GivenPositionIsDefault()
        {
            Position position = new(mockGrid.Object);
            position.Location.X.Should().Be(0);
        }

        [Fact]
        public void Y_ShouldReturnZero_GivenPositionIsDefault()
        {
            Position position = new(mockGrid.Object);
            position.Location.Y.Should().Be(0);
        }

        [Fact]
        public void IncreaseX_ShouldIncreaseXValue()
        {
            Position position = new(mockGrid.Object);
            int initialPosition = position.Location.X;
            position.IncreaseX();
            position.Location.X.Should().Be(++initialPosition);
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
            position.Location.X.Should().Be(0);
        }

        [Fact]
        public void IncreaseY_ShouldIncreaseYValue()
        {
            Position position = new(mockGrid.Object);
            int initialPosition = position.Location.Y;
            position.IncreaseY();
            position.Location.Y.Should().Be(++initialPosition);
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
            position.Location.Y.Should().Be(0);
        }

        [Fact]
        public void DecreaseX_ShouldDecreaseXValue()
        {
            Position position = new(mockGrid.Object);
            position.IncreaseX();
            int initialPosition = position.Location.X;
            position.DecreaseX();
            position.Location.X.Should().Be(--initialPosition);
        }

        [Fact]
        public void DecreaseX_ShouldMaxX_GivenXWasGridLimit()
        {
            Position position = new(mockGrid.Object);
            position.DecreaseX();
            position.Location.X.Should().Be(mockGrid.Object.MaxPoint.X - 1);
        }

        [Fact]
        public void DecreaseY_ShouldDecreaseYValue()
        {
            Position position = new(mockGrid.Object);
            position.IncreaseY();
            int initialPosition = position.Location.Y;
            position.DecreaseY();
            position.Location.Y.Should().Be(--initialPosition);
        }

        [Fact]
        public void DecreaseY_ShouldMaxY_GivenYWasGridLimit()
        {
            Position position = new(mockGrid.Object);
            position.DecreaseY();
            position.Location.Y.Should().Be(mockGrid.Object.MaxPoint.Y - 1);
        }
    }
}