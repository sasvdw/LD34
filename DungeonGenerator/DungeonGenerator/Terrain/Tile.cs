using System.Collections.Generic;
using System.Linq;
using Dungeons.Entities.DungeonObjects;
using Dungeons.Entities.Interfaces;
using Dungeons.Entities.Items;
using Dungeons.Entities.Monsters;
using Dungeons.Terrain.Enums;

namespace Dungeons.Terrain
{
    public abstract class Tile
    {
        private readonly Dungeon dungeon;
        private readonly IList<IGameEntity> gameEntities;
        public int X { get; private set; }
        public int Y { get; private set; }

        public abstract TerrainType Type { get; }

        public bool IsPassable
        {
            get
            {
                return this.gameEntities.Any(x => x.IsPassable);
            }
        }

        public bool HasDungeonObject
        {
            get
            {
                return this.gameEntities.Any(x => x is DungeonObject);
            }
        }

        public bool HasMonster
        {
            get
            {
                return this.gameEntities.Any(x => x is Monster);
            }
        }

        public bool HasItem
        {
            get
            {
                return this.gameEntities.Any(x => x is Item);
            }
        }

        public Dungeon Dungeon
        {
            get
            {
                return this.dungeon;
            }
        }

        private Tile()
        {
            this.gameEntities = new List<IGameEntity>();
        }

        protected Tile(Dungeon dungeon, int x, int y)
            : this()
        {
            this.dungeon = dungeon;
            this.X = x;
            this.Y = y;
            this.dungeon.SetTile(this, x, y);
        }

        public void AddGameEntity(IGameEntity gameEntity)
        {
            this.gameEntities.Add(gameEntity);

            gameEntity.SetCurrentTile(this);
        }

        public void RemoveGameEntity(IGameEntity gameEntity)
        {
            if(!this.gameEntities.Contains(gameEntity))
            {
                return;
            }

            this.gameEntities.Remove(gameEntity);
        }

        public void CleanUpTile()
        {
            foreach(var gameEntity in this.gameEntities)
            {
                this.dungeon.RemoveDungeonObject(gameEntity as DungeonObject);
                this.dungeon.RemoveItem(gameEntity as Item);
                this.dungeon.RemoveMonster(gameEntity as Monster);
            }
        }
    }
}
