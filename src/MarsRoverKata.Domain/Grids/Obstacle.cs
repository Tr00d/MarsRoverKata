using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public class Obstacle
    {
        public Obstacle(Point location)
        {
            Location = location;
        }

        public Point Location { get; }
    }
}