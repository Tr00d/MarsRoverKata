namespace MarsRoverKata.Domain.Positions
{
    public interface IPosition
    {
        int X { get; }

        int Y { get; }
        void IncreaseX();

        void IncreaseY();

        void DecreaseX();

        void DecreaseY();
    }
}