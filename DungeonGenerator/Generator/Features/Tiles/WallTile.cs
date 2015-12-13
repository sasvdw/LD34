using Dungeons;
using Dungeons.Entities.DungeonObjects;
using Dungeons.Terrain;

namespace Generator.Features.Tiles
{
    public class WallTile : FloorTile
    {
        public WallTile(Dungeon dungeon, int x, int y) 
            : base(dungeon, x, y)
        {
            this.AddGameEntity(new Wall());
        }
    }
}
