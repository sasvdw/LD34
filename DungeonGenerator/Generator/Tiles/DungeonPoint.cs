using Dungeons;
using Dungeons.Terrain.Enums;

namespace Generator.Tiles
{
    public class DungeonPoint : Point
    {
        private readonly RoomPointsGenerator roomPointsGenerator;

        public bool IsWall
        {
            get
            {
                return this.roomPointsGenerator.IsWall(this);
            }
        }

        public DungeonPoint(RoomPointsGenerator roomPointsGenerator, int x, int y)
            : base(x, y)
        {
            this.roomPointsGenerator = roomPointsGenerator;
        }

        public bool IsPointValid(Dungeon dungeon)
        {
            return this.IsPointOutsideDungeon(dungeon) ||
                   dungeon.GetTile(this.point).Type == TerrainType.Unused;
        }

        private bool IsPointOutsideDungeon(Dungeons.Dungeon dungeon)
        {
            return this.point.X < 0 || this.point.X >= dungeon.Width
                   || this.point.Y < 0 || this.point.Y >= dungeon.Height;
        }
    }
}
