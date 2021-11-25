using System.Drawing;
using System.Linq;
using MarsRoverKata.Domain.Grids;

namespace MarsRoverKata.Domain.Positions
{
    public class Position : IPosition
    {
        private readonly IGrid grid;

        public Position(IGrid grid)
        {
            this.grid = grid;
            Location = new Point(0, 0);
        }

        public Point Location { get; private set; }

        public void IncreaseX() =>
            UpdateLocation(new Point(Location.X == grid.MaxPoint.X - 1 ? 0 : Location.X + 1,
                Location.Y));

        public void IncreaseY() => UpdateLocation(new Point(Location.X,
            Location.Y == grid.MaxPoint.Y - 1 ? 0 : Location.Y + 1));

        public void DecreaseX() =>
            UpdateLocation(new Point(Location.X == 0 ? grid.MaxPoint.X - 1 : Location.X - 1,
                Location.Y));

        public void DecreaseY() => UpdateLocation(Location = new Point(Location.X,
            Location.Y == 0 ? grid.MaxPoint.Y - 1 : Location.Y - 1));

        private void UpdateLocation(Point location)
        {
            Location = grid.Obstacles.All(obstacle => obstacle.Location != location)
                ? location
                : throw new ObstacleException(location);
        }
    }
}