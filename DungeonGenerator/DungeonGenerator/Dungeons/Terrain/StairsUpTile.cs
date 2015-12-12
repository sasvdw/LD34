using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
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
