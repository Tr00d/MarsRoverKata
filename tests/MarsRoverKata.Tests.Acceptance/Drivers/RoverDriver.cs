using System.Drawing;
using MarsRoverKata.Domain;
using MarsRoverKata.Domain.Directions;
using MarsRoverKata.Domain.Grids;
using MarsRoverKata.Domain.Positions;
using MarsRoverKata.Domain.States;

namespace MarsRoverKata.Tests.Acceptance.Drivers
{
    public class RoverDriver
    {
        private Grid grid;
        private Rover rover;
        private State state;

        public void InitializeRover()
        {
            grid = new Grid(new Point(10, 10));
            state = new State(new NorthDirection(), new Position(grid));
            rover = new Rover(state);
        }

        public void SendInput(string input) => rover.Execute(input);

        public string GetRoverDirection() => rover.Direction;

        public int GetRoverXCoordinate() => rover.X;

        public int GetRoverYCoordinate() => rover.Y;

        public void InitializeObstacle(int x, int y) => grid.AddObstacle(new Obstacle(new Point(x, y)));

        public bool HasObstacleWarning() => rover.HasObstacleWarning;
    }
}