using Dungeons.Entities.Interfaces;

namespace Dungeons.Entities.GameComponents
{
    public abstract class GameComponent
    {
        protected readonly IGameEntity parentGameEntity;

        protected GameComponent(IGameEntity parentGameEntity)
        {
            this.parentGameEntity = parentGameEntity;
            this.parentGameEntity.AddComponent(this);
        }
    }
}