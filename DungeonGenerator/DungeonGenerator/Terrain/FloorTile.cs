using Dungeons.Terrain.Enums;

namespace Dungeons.Terrain
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
