using System.Collections.Generic;
using System.Drawing;
using MarsRoverKata.Domain;
using MarsRoverKata.Domain.Commands;
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
            this.grid = new Grid(new Point(10, 10));
            this.state = new State(new NorthDirection(), new Position(this.grid));
            this.rover = new Rover(this.state,
                new List<IInputCommand> {new MoveForwardCommand(), new RotateLeftCommand(), new RotateRightCommand()});
        }

        public void SendInput(string input) => this.rover.Execute(input);

        public string GetRoverDirection() => this.rover.Direction;

        public int GetRoverXCoordinate() => this.rover.X;

        public int GetRoverYCoordinate() => this.rover.Y;

        public void InitializeObstacle(int x, int y) => this.grid.AddObstacle(new Obstacle(new Point(x, y)));

        public bool HasObstacleWarning() => this.rover.HasObstacleWarning;
    }
}