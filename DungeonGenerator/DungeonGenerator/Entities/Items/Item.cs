using Dungeons.Entities.Enums;
using Dungeons.Entities.GameComponents;

namespace Dungeons.Entities.Items
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

        public override GameEntityType Type
        {
            get
            {
                return this.type;
            }
        }

        protected override void AssociateToDungeon(Dungeon dungeon)
        {
            dungeon.AddItem(this);
        }

        public Item(Dungeon dungeon, GameEntityType type)
        {
            this.dungeon = dungeon;
            this.type = type;
            new PickUpComponent(this);
        }
    }
}
