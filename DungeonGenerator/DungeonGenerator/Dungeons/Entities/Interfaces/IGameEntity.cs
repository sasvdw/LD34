using DungeonGenerator.Dungeons.Entities.GameComponents;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Dungeons.Entities.Interfaces
{
    public interface IGameEntity : IPassable
    {
        char Type { get; }
        Tile CurrentTile { get; }
        Dungeon Dungeon { get; }

        void SetCurrentTile(Tile tile);

        IGameEntity AddComponent(GameComponent gameComponent);

        T GetComponent<T>() where T : GameComponent;
    }
}
