using MarsRoverKata.Domain;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Grids;
using MarsRoverKata.Domain.Positions;
using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Tests.Acceptance.Drivers
{
    public class RoverDriver
    {
        private Rover rover;

        public void InitializeRover()
        {
            rover = new Rover(new State(new NorthDirection(), new Position(new Grid(10, 10))));
        }

        public void SendInput(string input) => rover.Execute(input);

        public string GetRoverDirection() => rover.Direction;

        public int GetRoverXCoordinate() => rover.X;

        public int GetRoverYCoordinate() => rover.Y;
    }
}