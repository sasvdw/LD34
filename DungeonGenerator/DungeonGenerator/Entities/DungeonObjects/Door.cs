using Dungeons.Entities.Enums;

namespace Dungeons.Entities.DungeonObjects
{
    public class Door : DungeonObject
    {
        private bool isPassable;

        public override bool IsPassable
        {
            get
            {
                return this.isPassable;
            }
        }

        public override GameEntityType Type
        {
            get
            {
                return GameEntityType.Door;
            }
        }
    }
}
