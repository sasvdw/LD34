using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class WallTile : Tile
    {
        public override char Type
        {
            get
            {
                return (char)TerrainType.Wall;
            }
        }

        public WallTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
