namespace MarsRoverKata.Domain.Grids
{
    public class Grid : IGrid
    {
        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Width { get; }
        public int Height { get; }
    }
}