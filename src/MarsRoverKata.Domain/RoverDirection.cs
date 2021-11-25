using LanguageExt;

namespace MarsRoverKata.Domain
{
    public class RoverDirection
    {
        public string Direction { get; }

        public RoverDirection()
        {
            Direction = "N";
        }

        public RoverDirection(string direction)
        {
            Direction = direction;
        }
    }
}