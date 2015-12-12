using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class StairsDownTile : FloorTile
    {
        public override TerrainType Type
        {
            get
            {
                return TerrainType.StairsDown;
            }
        }

        public StairsDownTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
