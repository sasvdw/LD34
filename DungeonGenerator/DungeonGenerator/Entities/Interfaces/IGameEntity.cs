using Dungeons.Entities.Enums;
using Dungeons.Entities.GameComponents;
using Dungeons.Terrain;

namespace Dungeons.Entities.Interfaces
{
    public interface IGameEntity : IPassable
    {
        GameEntityType Type { get; }
        Tile CurrentTile { get; }
        Dungeon Dungeon { get; }

        void SetCurrentTile(Tile tile);

        IGameEntity AddComponent(GameComponent gameComponent);

        T GetComponent<T>() where T : GameComponent;
    }
}
