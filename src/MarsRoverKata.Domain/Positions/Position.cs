using System.Drawing;
using MarsRoverKata.Domain.Grids;

namespace MarsRoverKata.Domain.Positions
{
    public class Position : IPosition
    {
        private readonly IGrid grid;

        public Position(IGrid grid)
        {
            this.grid = grid;
            this.Location = new Point(0, 0);
        }

        public Point Location { get; private set; }

        public void IncreaseX() => this.UpdateLocation(this.Location with
        {
            X = this.Location.X == this.grid.MaxPoint.X - 1 ? 0 : this.Location.X + 1,
        });

        public void IncreaseY() => this.UpdateLocation(this.Location with
        {
            Y = this.Location.Y == this.grid.MaxPoint.Y - 1 ? 0 : this.Location.Y + 1,
        });

        public void DecreaseX() => this.UpdateLocation(this.Location with
        {
            X = this.Location.X == 0 ? this.grid.MaxPoint.X - 1 : this.Location.X - 1,
        });

        public void DecreaseY() => this.UpdateLocation(this.Location with
        {
            Y = this.Location.Y == 0 ? this.grid.MaxPoint.Y - 1 : this.Location.Y - 1,
        });

        private void UpdateLocation(Point location)
        {
            this.Location = this.grid.Obstacles.All(obstacle => obstacle.Location != location)
                ? location
                : throw new ObstacleException(location);
        }
    }
}