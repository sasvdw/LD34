namespace DungeonGenerator.Dungeons.Entities.GameComponents
{
    public abstract class GameComponent
    {
        protected readonly GameEntity parentGameEntity;

        protected GameComponent(GameEntity parentGameEntity)
        {
            this.parentGameEntity = parentGameEntity;
            this.parentGameEntity.AddComponent(this);
        }
    }
}