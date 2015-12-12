using System.Collections.Generic;
using System.Linq;
using DungeonGenerator.Dungeons.Entities.GameComponents;
using DungeonGenerator.Dungeons.Entities.Interfaces;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Dungeons.Entities
{
    public abstract class GameEntity : IGameEntity
    {
        protected readonly IList<GameComponent> components;
        protected Tile currentTile;
        protected Dungeon dungeon;

        public abstract bool IsPassable { get; }
        public abstract char Type { get; }

        public Tile CurrentTile
        {
            get
            {
                return this.currentTile;
            }
        }

        public Dungeon Dungeon
        {
            get
            {
                return this.dungeon;
            }
        }

        protected GameEntity()
        {
            this.components = new List<GameComponent>();
        }

        public virtual void SetCurrentTile(Tile tile)
        {
            if(this.currentTile != null)
            {
                this.currentTile.RemoveGameEntity(this);
            }

            this.currentTile = tile;
        }

        public IGameEntity AddComponent(GameComponent gameComponent)
        {
            this.components.Add(gameComponent);

            return this;
        }

        public T GetComponent<T>() where T : GameComponent
        {
            return (T)this.components.Single(x => x is T);
        }
    }
}
