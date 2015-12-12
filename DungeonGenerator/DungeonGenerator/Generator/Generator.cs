using System;
using DungeonGenerator.Dungeons;
using DungeonGenerator.Dungeons.Entities;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Generator
{
    public class Generator
    {
        private readonly Dungeon dungeon;
        private readonly Random random;

        public Dungeon ConstructedDungeon
        {
            get
            {
                return this.dungeon;
            }
        }

        private Generator()
        {
            random = new Random();
        }

        public Generator(int width, int height)
            : this()
        {
            this.dungeon = new Dungeon(width, height);
            this.FillMap();
        }

        public Generator PlacePlayer(Player player)
        {
            int x = this.random.Next(ConstructedDungeon.Width);
            int y = this.random.Next(ConstructedDungeon.Height);

            var stairsDownTile = new StairsDownTile(this.dungeon, x, y);
            stairsDownTile.AddGameEntity(player);

            return this;
        }

        private void FillRect<TTile>(int leftX, int rightX, int topY, int bottomY) where TTile : Tile
        {
            for (var x = leftX; x <= rightX; x++)
            {
                for (var y = topY; y <= bottomY; y++)
                {
                    Activator.CreateInstance(typeof(TTile), this.dungeon, x, y);
                }
            }
        }

        private void FillMap()
        {
            this.FillRect<FloorTile>(0, this.dungeon.Width - 1, 0, this.dungeon.Height - 1);
        }
    }
}
