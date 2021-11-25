using System.Collections.Generic;
using System.Drawing;

namespace MarsRoverKata.Domain.Grids
{
    public interface IGrid
    {
        Point MaxPoint { get; }
        
        IEnumerable<Obstacle> Obstacles { get; }

        void AddObstacle(Obstacle obstacle);
    }
}