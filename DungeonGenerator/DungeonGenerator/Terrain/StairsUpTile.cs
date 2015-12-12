using Dungeons.Terrain.Enums;

namespace Dungeons.Terrain
{
    public class StairsUpTile : FloorTile
    {
        public override TerrainType Type
        {
            get
            {
                return TerrainType.StairsUp;
            }
        }

        public StairsUpTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
