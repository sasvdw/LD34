using Dungeons.Entities.Enums;

namespace Dungeons.Entities.Interfaces
{
    public interface IMovableGameEntity : IGameEntity
    {
        void Move(Direction direction);
    }
}
