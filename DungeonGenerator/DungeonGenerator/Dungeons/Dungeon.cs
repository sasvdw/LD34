using System.Collections.Generic;
using System.Linq;
using DungeonGenerator.Dungeons.Entities;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Dungeons
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

        public char[] Map
        {
            get
            {
                return this.tiles.Select(x => (char)x.Type).ToArray();
            }
        }

        public Dictionary<int, char> DungeonObjectDictionary
        {
            get
            {
                return this.dungeonObjects.ToDictionary(x => this.GetTilePosition(x.CurrentTile.X, x.CurrentTile.Y), y => y.Type);
            }
        }

        public Dictionary<int, char> MonsterDictionary
        {
            get
            {
                return this.monsters.ToDictionary(x => this.GetTilePosition(x.CurrentTile.X, x.CurrentTile.Y), y => y.Type);
            }
        }

        public Dictionary<int, char> ItemDictionary
        {
            get
            {
                return this.items.ToDictionary(x => this.GetTilePosition(x.CurrentTile.X, x.CurrentTile.Y), y => y.Type);
            }
        }

        public KeyValuePair<int, char> PlayerValuePair
        {
            get
            {
                return new KeyValuePair<int, char>(this.GetTilePosition(this.player.CurrentTile.X, this.player.CurrentTile.Y), this.player.Type);
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

            return this.tiles[pos];
        }

        public void SetTile(Tile tile, int x, int y)
        {
            var pos = this.GetTilePosition(x, y);

            this.tiles[pos] = tile;
        }

        public void SetPlayer(Player player)
        {
            this.player = player;
        }

        private int GetTilePosition(int x, int y)
        {
            var pos = y * this.Width + x;
            return pos;
        }

        public void RemoveItem(Item item)
        {
            if(!this.items.Contains(item))
            {
                return;
            }

            this.items.Remove(item);
        }

        public void RemovePlayer()
        {
            this.player = null;
        }

        public void RemoveMonster(Monster monster)
        {
            if(!this.monsters.Contains(monster))
            {
                return;
            }

            this.monsters.Remove(monster);
        }
    }
}
