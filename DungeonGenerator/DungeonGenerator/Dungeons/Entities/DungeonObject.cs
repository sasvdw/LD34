namespace DungeonGenerator.Dungeons.Entities
{
    public abstract class DungeonObject : GameEntity
    {
        public abstract override bool IsPassable { get; }
    }
}
