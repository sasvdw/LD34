using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Dungeons.Terrain
{
    public class StairsUpTile : FloorTile
    {
        public override char Type
        {
            get
            {
                return (char)TerrainType.StairsUp;
            }
        }

        public StairsUpTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y) {}
    }
}
