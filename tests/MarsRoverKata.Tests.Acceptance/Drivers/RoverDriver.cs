using MarsRoverKata.Domain;

namespace MarsRoverKata.Tests.Acceptance.Drivers
{
    public class RoverDriver
    {
        private Rover rover;

        public void InitializeRover()
        {
            rover = new Rover(new Grid());
        }

        public RoverState GetRoverState()
        {
            return rover.State;
        }
    }
}