using FluentAssertions;
using MarsRoverKata.Tests.Acceptance.Drivers;
using TechTalk.SpecFlow;

namespace MarsRoverKata.Tests.Acceptance.Steps
{
    [Binding]
    public class RoverSteps
    {
        private readonly RoverDriver driver;

        public RoverSteps(RoverDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"rover is initialized")]
        public void InitializeRover()
        {
            driver.InitializeRover();
        }

        [Then(@"the direction should be ""(.*)""")]
        public void ThenTheDirectionShouldBe(string direction)
        {
            driver.GetRoverState().Direction.Should().Be(direction);
        }

        [Then(@"the X coordinate should be (.*)")]
        public void ThenTheXCoordinateShouldBe(int coordinate)
        {
            driver.GetRoverState().X.Should().Be(coordinate);
        }

        [Then(@"the Y coordinate should be (.*)")]
        public void ThenTheYCoordinateShouldBe(int coordinate)
        {
            driver.GetRoverState().Y.Should().Be(coordinate);
        }
    }
}