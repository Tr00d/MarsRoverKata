using LanguageExt;
using MarsRoverKata.Domain;

namespace MarsRoverKata.Tests.Acceptance.Drivers
{
    public class RoverDriver
    {
        private Rover rover;

        public void InitializeRover()
        {
            this.rover = new Rover(new Grid(), new RoverState());
        }

        public void SendInput(string input) => this.rover.Execute(input);

        public string GetRoverDirection() => rover.Direction;

        public int GetRoverXCoordinate() => rover.X;

        public int GetRoverYCoordinate() => rover.Y;
    }
}