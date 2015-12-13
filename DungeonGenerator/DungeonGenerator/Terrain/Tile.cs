using System.Collections.Generic;
using System.Linq;
using Dungeons.Entities.DungeonObjects;
using Dungeons.Entities.Enums;
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
                return this.gameEntities.All(x => x.IsPassable);
            }
        }

        public Dungeon Dungeon
        {
            get
            {
                return this.dungeon;
            }
        }

        public Tile NorthTile
        {
            get
            {
                return this.dungeon.GetTile(this.X, this.Y - 1);
            }
        }

        public Tile SouthTile
        {
            get
            {
                return this.dungeon.GetTile(this.X, this.Y + 1);
            }
        }

        public Tile EastTile
        {
            get
            {
                return this.dungeon.GetTile(this.X + 1, this.Y);
            }
        }

        public Tile WestTile
        {
            get
            {
                return this.dungeon.GetTile(this.X - 1, this.Y);
            }
        }

        public Dictionary<Direction, Tile> Surroundings
        {
            get
            {
                var surroundings = new Dictionary<Direction, Tile>()
                       {
                            {Direction.North, this.NorthTile },
                            {Direction.South, this.SouthTile },
                            {Direction.East, this.EastTile },
                            {Direction.West, this.WestTile },
                       };

                foreach(var surrounding in surroundings.Where(surrounding => surrounding.Value == null))
                {
                    surroundings.Remove(surrounding.Key);
                }

                return surroundings;
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
