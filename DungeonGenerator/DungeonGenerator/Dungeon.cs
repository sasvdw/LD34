using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Dungeons.Entities.DungeonObjects;
using Dungeons.Entities.Enums;
using Dungeons.Entities.Items;
using Dungeons.Entities.Monsters;
using Dungeons.Entities.Players;
using Dungeons.Terrain;
using Dungeons.Terrain.Enums;

namespace Dungeons
{
    public class Dungeon
    {
        private readonly Tile[] tiles;
        private readonly int width;
        private readonly int height;
        private readonly IList<Monster> monsters;
        private readonly IList<Item> items;
        private readonly IList<DungeonObject> dungeonObjects;
        private Player player;

        public int Width
        {
            get
            {
                return this.width;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
        }

        public TerrainType[] Map
        {
            get
            {
                return this.tiles.Select(x => x.Type).ToArray();
            }
        }

        public Dictionary<int, GameEntityType> DungeonObjectDictionary
        {
            get
            {
                return this.dungeonObjects.ToDictionary(x => this.GetTilePosition(x.CurrentTile.X, x.CurrentTile.Y), y => y.Type);
            }
        }

        public Dictionary<int, GameEntityType> MonsterDictionary
        {
            get
            {
                return this.monsters.ToDictionary(x => this.GetTilePosition(x.CurrentTile.X, x.CurrentTile.Y), y => y.Type);
            }
        }

        public Dictionary<int, GameEntityType> ItemDictionary
        {
            get
            {
                return this.items.ToDictionary(x => this.GetTilePosition(x.CurrentTile.X, x.CurrentTile.Y), y => y.Type);
            }
        }

        public KeyValuePair<int, GameEntityType> PlayerValuePair
        {
            get
            {
                return new KeyValuePair<int, GameEntityType>(this.GetTilePosition(this.player.CurrentTile.X, this.player.CurrentTile.Y),
                    this.player.Type);
            }
        }

        private Dungeon()
        {
            this.monsters = new List<Monster>();
            this.items = new List<Item>();
            this.dungeonObjects = new List<DungeonObject>();
        }

        public Dungeon(int width, int height)
            : this()
        {
            this.width = width;
            this.height = height;
            this.tiles = new Tile[width * height];
        }

        public Tile GetTile(int x, int y)
        {
            var pos = this.GetTilePosition(x, y);

            if(pos < 0 || pos >= this.tiles.Length)
            {
                return null;
            }

            return this.tiles[pos];
        }

        public Tile GetTile(Point point)
        {
            return this.GetTile(point.X, point.Y);
        }

        public void SetTile(Tile tile, int x, int y)
        {
            var pos = this.GetTilePosition(x, y);

            var oldTile = this.tiles[pos];

            if(oldTile != null)
            {
                oldTile.CleanUpTile();
            }

            this.tiles[pos] = tile;
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        public void RemovePlayer()
        {
            this.player = null;
        }

        public void AddItem(Item item)
        {
            if(this.items.Contains(item))
            {
                return;
            }

            this.items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (!this.items.Contains(item))
            {
                return;
            }

            this.items.Remove(item);
        }

        public void AddMonster(Monster monster)
        {
            if(this.monsters.Contains(monster))
            {
                return;
            }

            this.monsters.Add(monster);
        }

        public void RemoveMonster(Monster monster)
        {
            if (!this.monsters.Contains(monster))
            {
                return;
            }

            this.monsters.Remove(monster);
        }

        public void AddDungeonObject(DungeonObject dungeonObject)
        {
            if(this.dungeonObjects.Contains(dungeonObject))
            {
                return;
            }

            this.dungeonObjects.Add(dungeonObject);
        }

        public void RemoveDungeonObject(DungeonObject dungeonObject)
        {
            if(!this.dungeonObjects.Contains(dungeonObject))
            {
                return;
            }

            this.dungeonObjects.Remove(dungeonObject);
        }

        private int GetTilePosition(int x, int y)
        {
            var pos = y * this.Width + x;
            return pos;
        }
    }
}
