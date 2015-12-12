using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class WallTile : Tile
    {
        public override TerrainType Type
        {
            get
            {
                return TerrainType.Wall;
            }
        }

        public WallTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
