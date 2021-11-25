using System.Drawing;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using MarsRoverKata.Domain.Grids;
using Xunit;

namespace MarsRoverKata.Domain.Tests.Grids
{
    public class GridTest
    {
        [Fact]
        public void AddObstacle_ShouldAddObstacleToGrid()
        {
            Obstacle obstacle = new Obstacle(new Point(5, 5));
            Grid grid = new Grid(new Point(10, 10));
            grid.AddObstacle(obstacle);
            grid.Obstacles.First().Should().Be(obstacle);
            grid.Obstacles.Count().Should().Be(1);
        }
    }
}