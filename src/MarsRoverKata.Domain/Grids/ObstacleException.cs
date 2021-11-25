using System;
using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public class ObstacleException : Exception
    {
        public ObstacleException(Point obstacleLocation)
            : this()
        {
            ObstacleLocation = obstacleLocation;
        }

        public ObstacleException()
        {
            ObstacleLocation = new Point();
        }

        public Point ObstacleLocation { get; }
    }
}