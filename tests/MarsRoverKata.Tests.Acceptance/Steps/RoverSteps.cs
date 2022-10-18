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
        public void InitializeRover() => this.driver.InitializeRover();

        [Then(@"the direction should be ""(.*)""")]
        public void VerifyDirection(string direction) => this.driver.GetRoverDirection().Should().Be(direction);

        [Then(@"the X coordinate should be (.*)")]
        public void VerifyXCoordinate(int coordinate) => this.driver.GetRoverXCoordinate().Should().Be(coordinate);

        [Then(@"the Y coordinate should be (.*)")]
        public void VerifyYCoordinate(int coordinate) => this.driver.GetRoverYCoordinate().Should().Be(coordinate);

        [When(@"rover receives input ""(.*)""")]
        public void SendInput(string input) => this.driver.SendInput(input);

        [Given(@"obstacle stands at ""(.*)"":""(.*)""")]
        public void InitializeObstacle(string x, string y) =>
            this.driver.InitializeObstacle(int.Parse(x), int.Parse(y));

        [Then(@"the rover provides an obstacle warning")]
        public void ThenTheRoverProvidesAnObstacleWarning() => this.driver.HasObstacleWarning().Should().Be(true);
    }
}