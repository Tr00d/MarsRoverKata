using System;
using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public class ObstacleException : Exception
    {
        public ObstacleException(Point obstacleLocation)
            : this()
        {
            this.ObstacleLocation = obstacleLocation;
        }

        public ObstacleException()
        {
            this.ObstacleLocation = new Point();
        }

        public Point ObstacleLocation { get; }
    }
}