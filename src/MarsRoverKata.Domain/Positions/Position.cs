using System.Drawing;
using MarsRoverKata.Domain.Grids;

namespace MarsRoverKata.Domain.Positions
{
    public class Position : IPosition
    {
        private IGrid grid;

        public Position(IGrid grid)
        {
            this.grid = grid;
            this.Location = new Point(0, 0);
        }

        public Point Location { get; private set; }
        
        public void IncreaseX() => this.Location = new Point(this.Location.X == grid.MaxPoint.X - 1 ? 0 : this.Location.X + 1, this.Location.Y);

        public void IncreaseY() => this.Location = new Point(this.Location.X, this.Location.Y == grid.MaxPoint.Y - 1 ? 0 : this.Location.Y + 1);

        public void DecreaseX() => this.Location = new Point(this.Location.X == 0 ? grid.MaxPoint.X - 1 : this.Location.X - 1, this.Location.Y);

        public void DecreaseY() => this.Location = new Point(this.Location.X, this.Location.Y == 0 ? grid.MaxPoint.Y - 1 : this.Location.Y - 1);
    }
}