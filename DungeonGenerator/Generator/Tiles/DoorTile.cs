using Dungeons;
using Dungeons.Entities.DungeonObjects;
using Dungeons.Terrain;

namespace Generator.Tiles
{
    public class DoorTile : FloorTile
    {
        public DoorTile(Dungeon dungeon, int x, int y) : base(dungeon, x, y)
        {
            this.AddGameEntity(new Door());
        }
    }
}
