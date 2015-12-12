using DungeonGenerator.Dungeons.Entities.Enums;
using DungeonGenerator.Dungeons.Entities.GameComponents;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Dungeons.Entities
{
    public class Item : GameEntity
    {
        private readonly GameEntityType type;

        public override bool IsPassable
        {
            get
            {
                return true;
            }
        }

        public override char Type
        {
            get
            {
                return (char)this.type;
            }
        }

        public Item(Dungeon dungeon, GameEntityType type)
        {
            this.dungeon = dungeon;
            this.type = type;
            new PickUpComponent(this);
        }
    }
}
