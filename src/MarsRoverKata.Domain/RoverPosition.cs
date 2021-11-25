namespace MarsRoverKata.Domain
{
    public class RoverPosition
    {
        public int X { get; }

        public int Y { get; }

        public RoverPosition()
        {
            X = 0;
            Y = 0;
        }

        public RoverPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}