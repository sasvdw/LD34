﻿using System.Collections.Generic;
using System.Linq;
using DungeonGenerator.Dungeons.Entities;

namespace DungeonGenerator.Dungeons.Terrain
{
    public abstract class Tile
    {
        private readonly Dungeon dungeon;
        private readonly IList<GameEntity> gameEntities;
        public int X { get; private set; }
        public int Y { get; private set; }

        public abstract char Type { get; }

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

        public char Object
        {
            get
            {
                return ' ';
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
            this.gameEntities = new List<GameEntity>();
        }

        protected Tile(Dungeon dungeon, int x, int y)
            : this()
        {
            this.dungeon = dungeon;
            this.X = x;
            this.Y = y;
            this.dungeon.SetTile(this, x, y);
        }

        public void AddGameEntity(GameEntity gameEntity)
        {
            this.gameEntities.Add(gameEntity);

            gameEntity.SetCurrentTile(this);
        }

        public void RemoveGameEntity(GameEntity gameEntity)
        {
            if(!this.gameEntities.Contains(gameEntity))
            {
                return;
            }

            this.gameEntities.Remove(gameEntity);
        }
    }
}
