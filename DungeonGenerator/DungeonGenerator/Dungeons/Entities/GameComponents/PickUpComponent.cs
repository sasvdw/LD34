namespace DungeonGenerator.Dungeons.Entities.GameComponents
{
    public class PickUpComponent : GameComponent
    {
        private Item ParentItem
        {
            get
            {
                return (Item)this.parentGameEntity;
            }
        }

        private Dungeon Dungeon
        {
            get
            {
                return this.parentGameEntity.Dungeon;
            }
        }

        public PickUpComponent(Item parentItem) : base(parentItem) {}

        public InventoryItem PickUpItem(Player player)
        {
            this.Dungeon.RemoveItem(this.ParentItem);

            return new InventoryItem(player);
        }
    }
}
