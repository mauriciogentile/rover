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
            string commands1 = commands.ToUpper();
            ValidateCommands(commands1);

            int i = 0;
            do
            {
                var command = commands1[i];
                switch (command)
                {
                    case 'F':
                        MoveForward();
                        break;
                    case 'B':
                        MoveBackward();
                        break;
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    default:
                        break;
                }
                i++;
            }
            while (i < commands1.Length);
        }

        void ValidateCommands(string commands)
        {
            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];
                if (command != 'F' && command != 'B' && command != 'L' && command != 'R')
                {
                    throw new InvalidOperationException("Invalid command detected!");
                }
            }
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
                    nextSpot.Y++;
                    break;
                case Direction.Left:
                    nextSpot.X--;
                    break;
                case Direction.Right:
                    nextSpot.X++;
                    break;
            }

            TryMove(nextSpot);
        }

        void MoveBackward()
        {
            var nextSpot = _currentPosition;

            switch (_currentDirection)
            {
                case Direction.Up:
                    nextSpot.Y++;
                    break;
                case Direction.Down:
                    nextSpot.Y--;
                    break;
                case Direction.Left:
                    nextSpot.X++;
                    break;
                case Direction.Right:
                    nextSpot.X--;
                    break;
            }

            TryMove(nextSpot);
        }

        void TurnLeft()
        {
            switch (_currentDirection)
            {
                case Direction.Up:
                    _currentDirection = Direction.Left;
                    break;
                case Direction.Down:
                    _currentDirection = Direction.Right;
                    break;
                case Direction.Left:
                    _currentDirection = Direction.Down;
                    break;
                case Direction.Right:
                    _currentDirection = Direction.Up;
                    break;
            }
        }

        void TurnRight()
        {
            switch (_currentDirection)
            {
                case Direction.Up:
                    _currentDirection = Direction.Right;
                    break;
                case Direction.Down:
                    _currentDirection = Direction.Left;
                    break;
                case Direction.Left:
                    _currentDirection = Direction.Up;
                    break;
                case Direction.Right:
                    _currentDirection = Direction.Down;
                    break;
            }
        }
    }
}
