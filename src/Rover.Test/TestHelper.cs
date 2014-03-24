using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MarsRover.Test
{
    static class TestHelper
    {
        public static ExplorationParams MarsExploration
        {
            get
            {
                return new ExplorationParams
                {
                    Terrain = Mars,
                    PositionInfo = new PositionInfo
                    {
                        Direction = Direction.Up,
                        Position = new Point(0, 0)
                    }
                };
            }
        }

        public static Terrain Mars
        {
            get
            {
                return new Terrain { FarthestPoint = new Point(10, 10) };
            }
        }
    }
}
