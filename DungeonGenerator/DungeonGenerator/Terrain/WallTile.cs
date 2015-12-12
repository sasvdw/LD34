using Dungeons.Entities.DungeonObjects;
using Dungeons.Terrain.Enums;

namespace Dungeons.Terrain
{
    public class WallTile : Tile
    {
        public override TerrainType Type
        {
            get
            {
                return TerrainType.Floor;
            }
        }

        public WallTile(Dungeon dungeon, int x, int y) 
            : base(dungeon, x, y)
        {
            this.AddGameEntity(new Wall());
        }
    }
}
