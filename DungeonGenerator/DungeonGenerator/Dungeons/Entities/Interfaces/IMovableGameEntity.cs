using DungeonGenerator.Dungeons.Entities.Enums;

namespace DungeonGenerator.Dungeons.Entities.Interfaces
{
    public interface IMovableGameEntity : IGameEntity
    {
        void Move(Direction direction);
    }
}
