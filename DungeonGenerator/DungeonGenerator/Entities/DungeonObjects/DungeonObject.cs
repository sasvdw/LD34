namespace Dungeons.Entities.DungeonObjects
{
    public abstract class DungeonObject : GameEntity
    {
        protected override void AssociateToDungeon(Dungeon dungeon)
        {
            dungeon.AddDungeonObject(this);
        }
    }
}
