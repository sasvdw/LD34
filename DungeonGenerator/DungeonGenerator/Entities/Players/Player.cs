using Dungeons.Entities.Enums;
using Dungeons.Entities.GameComponents;
using Dungeons.Entities.Interfaces;

namespace Dungeons.Entities.Players
{
    public class Player : GameEntity, IMovableGameEntity
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
                return GameEntityType.Player;
            }
        }

        public Player()
        {
            new MoveComponent(this);
        }

        public void Move(Direction direction)
        {
            this.GetComponent<MoveComponent>().Move(direction);
        }

        protected override void AssociateToDungeon(Dungeon dungeon)
        {
            if(this.dungeon == dungeon)
            {
                return;
            }

            if(this.dungeon != null)
            {
                this.dungeon.RemovePlayer();
            }

            this.dungeon = dungeon;
            dungeon.SetPlayer(this);
        }
    }
}
