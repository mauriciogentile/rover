using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover
{
    public class Terrain
    {
        readonly List<Point> _obstacles;

        public Terrain()
        {
            _obstacles = new List<Point>();
        }

        public Point FarthestPoint { get; set; }

        public void AddObstacle(Point obstacle)
        {
            if (IsOutOfBounds(obstacle))
            {
                throw new InvalidOperationException("Obstacle out of range");
            }
            if (!_obstacles.Contains(obstacle))
            {
                _obstacles.Add(obstacle);
            }
        }

        public void RemoveObstacle(Point obstacle)
        {
            _obstacles.Remove(obstacle);
        }

        public bool HasObstacleAt(Point position)
        {
            return _obstacles.Contains(position);
        }

        public bool IsOutOfBounds(Point position)
        {
            if (position.X < 0 || position.X > FarthestPoint.X || position.Y < 0 || position.Y > FarthestPoint.Y)
            {
                return true;
            }
            return false;
        }
    }
}
