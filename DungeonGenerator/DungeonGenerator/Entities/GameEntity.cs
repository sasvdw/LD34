using System.Collections.Generic;
using System.Linq;
using Dungeons.Entities.Enums;
using Dungeons.Entities.GameComponents;
using Dungeons.Entities.Interfaces;
using Dungeons.Terrain;

namespace Dungeons.Entities
{
    public abstract class GameEntity : IGameEntity
    {
        protected readonly IList<GameComponent> components;
        protected Tile currentTile;
        protected Dungeon dungeon;

        public abstract bool IsPassable { get; }
        public abstract GameEntityType Type { get; }

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

        public void SetCurrentTile(Tile tile)
        {
            this.AssociateToDungeon(tile.Dungeon);
            if(this.currentTile != null)
            {
                this.currentTile.RemoveGameEntity(this);
            }

            this.currentTile = tile;
        }

        protected abstract void AssociateToDungeon(Dungeon dungeon);

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
