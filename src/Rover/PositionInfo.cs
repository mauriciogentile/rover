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

        public override bool Equals(object obj)
        {
            var y = obj as PositionInfo;
            if (y == null)
            {
                return false;
            }
            return (Position == y.Position && Direction == y.Direction);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Position, Direction);
        }
    }
}
