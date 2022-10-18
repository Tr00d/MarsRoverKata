using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public class Grid : IGrid
    {
        private readonly List<Obstacle> obstacles;

        public Grid(Point maxPoint)
        {
            this.MaxPoint = maxPoint;
            this.obstacles = new List<Obstacle>();
        }

        public Point MaxPoint { get; }

        public IEnumerable<Obstacle> Obstacles => new List<Obstacle>(this.obstacles);

        public void AddObstacle(Obstacle obstacle) => this.obstacles.Add(obstacle);
    }
}