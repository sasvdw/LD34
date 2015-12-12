using Dungeons.Entities.Enums;

namespace Dungeons.Entities.Monsters
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

        public override GameEntityType Type
        {
            get
            {
                return this.type;
            }
        }

        protected override void AssociateToDungeon(Dungeon dungeon)
        {
            dungeon.AddMonster(this);
        }
    }
}
