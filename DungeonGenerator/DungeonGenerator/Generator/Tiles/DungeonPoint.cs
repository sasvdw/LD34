using System.Drawing;

namespace DungeonGenerator.Generator.Tiles
{
    public class DungeonPoint
    {
        private readonly RoomPointsGenerator roomPointsGenerator;
        private readonly Point point;

        public DungeonPoint(RoomPointsGenerator roomPointsGenerator, int x, int y)
        {
            this.roomPointsGenerator = roomPointsGenerator;
            this.point = new Point(x, y);
        }

        public bool IsWall
        {
            get
            {
                return this.roomPointsGenerator.IsWall(this.point);
            }
        }

        public Point Point
        {
            get
            {
                return this.point;
            }
        }
    }
}
