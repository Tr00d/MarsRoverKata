using System.Drawing;

namespace MarsRoverKata.Domain.Positions
{
    public interface IPosition
    {
        Point Location { get; }
        
        void IncreaseX();

        void IncreaseY();

        void DecreaseX();

        void DecreaseY();
    }
}