using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class FloorTile : Tile
    {
        public override TerrainType Type
        {
            get
            {
                return TerrainType.Floor;
            }
        }

        public FloorTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
