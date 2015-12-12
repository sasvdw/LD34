using DungeonGenerator.Dungeons.Entities.Enums;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Dungeons.Entities
{
    public class Monster : GameEntity
    {
        private readonly GameEntityType type;

        public override bool IsPassable
        {
            get
            {
                return false;
            }
        }

        public Monster(Dungeon dungeon, GameEntityType type)
        {
            this.dungeon = dungeon;
            this.type = type;
        }

        public override char Type
        {
            get
            {
                return (char)this.type;
            }
        }
    }
}
