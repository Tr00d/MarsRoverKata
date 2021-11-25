using MarsRoverKata.Domain.Grids;

namespace MarsRoverKata.Domain.Positions
{
    public class Position : IPosition
    {
        private IGrid grid;

        public Position(IGrid grid)
        {
            this.grid = grid;
        }

        public void IncreaseX() => X = X == grid.Width - 1 ? 0 : ++X;

        public void IncreaseY() => Y = Y == grid.Height - 1 ? 0 : ++Y;

        public void DecreaseX() => X = X == 0 ? grid.Width - 1 : --X;

        public void DecreaseY() => Y = Y == 0 ? grid.Height - 1 : --Y;

        public int X { get; private set; }

        public int Y { get; private set; }
    }
}