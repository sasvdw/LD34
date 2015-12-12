using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class StairsDownTile : FloorTile
    {
        public override char Type
        {
            get
            {
                return (char)TerrainType.StairsDown;
            }
        }

        public StairsDownTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
