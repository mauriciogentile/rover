using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Rover
    {
        private readonly Terrain _terrain;
        private object _lock = new object();
        private Point _currentPosition;
        private Direction _currentDirection;

        public Rover(ExplorationParams param)
        {
            _currentPosition = param.PositionInfo.Position;
            _currentDirection = param.PositionInfo.Direction;
            _terrain = param.Terrain;
        }

        public PositionInfo GetPositionInfo()
        {
            return new PositionInfo
            {
                Position = _currentPosition,
                Direction = _currentDirection
            };
        }

        public void Move(string commands)
        {
            int i = 0;
            do
            {
                var command = commands[i];
                switch (command)
                {
                    case 'F':
                        MoveForward();
                        break;
                    default:
                        break;
                }
                i++;
            }
            while (i < commands.Length);
        }

        void TryMove(Point nextSpot)
        {
            if (_terrain.IsOutOfBounds(nextSpot))
            {
                return;
            }

            _currentPosition = nextSpot;
        }

        void MoveForward()
        {
            var nextSpot = _currentPosition;

            switch (_currentDirection)
            {
                case Direction.Up:
                    nextSpot.Y--;
                    break;
                case Direction.Down:
                    break;
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
            }

            TryMove(nextSpot);
        }
    }
}
