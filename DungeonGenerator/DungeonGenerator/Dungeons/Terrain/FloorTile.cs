using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class FloorTile : Tile
    {
        public override char Type
        {
            get
            {
                return (char)TerrainType.Floor;
            }
        }

        public FloorTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
