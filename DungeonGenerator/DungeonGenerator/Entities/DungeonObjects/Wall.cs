using Dungeons.Entities.Enums;
using Dungeons.Terrain;

namespace Dungeons.Entities.DungeonObjects
{
    public class Wall : DungeonObject
    {
        public override bool IsPassable
        {
            get
            {
                return false;
            }
        }

        public override GameEntityType Type
        {
            get
            {
                return GameEntityType.Wall;
            }
        }
    }
}
