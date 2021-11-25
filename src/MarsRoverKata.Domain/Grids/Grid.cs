using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public class Grid : IGrid
    {
        public Grid(Point maxPoint)
        {
            this.MaxPoint = maxPoint;
        }

        public Point MaxPoint { get; }
    }
}