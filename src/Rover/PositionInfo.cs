using System.Drawing;

namespace MarsRover
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    public class PositionInfo
    {
        public Point Position { get; set; }
        public Direction Direction { get; set; }
    }
}
