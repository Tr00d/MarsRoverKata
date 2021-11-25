using System.Collections.Generic;
using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public class Grid : IGrid
    {
        private readonly List<Obstacle> obstacles;

        public Grid(Point maxPoint)
        {
            MaxPoint = maxPoint;
            obstacles = new List<Obstacle>();
        }

        public Point MaxPoint { get; }

        public IEnumerable<Obstacle> Obstacles => new List<Obstacle>(obstacles);

        public void AddObstacle(Obstacle obstacle) => obstacles.Add(obstacle);
    }
}