using System;
using System.Linq;
using Dungeons;
using Dungeons.Entities.Enums;
using Dungeons.Entities.Players;
using Dungeons.Terrain;
using Dungeons.Terrain.Enums;
using Generator.Interfaces;
using Generator.Tiles;

namespace Generator
{
    public class Generator
    {
        private readonly Dungeon dungeon;
        private readonly IRandom random;

        private readonly int width;
        private readonly int height;
        private readonly int objects;

        private readonly Action<string> logger;

        public int MinX
        {
            get
            {
                return 0;
            }
        }

        public int MinY
        {
            get
            {
                return 0;
            }
        }

        public int MaxX
        {
            get
            {
                return this.width - 1;
            }
        }

        public int MaxY
        {
            get
            {
                return this.height - 1;
            }
        }

        public Dungeon ConstructedDungeon
        {
            get
            {
                return this.dungeon;
            }
        }

        private Generator(Action<string> logger, IRandom random)
        {
            this.logger = logger;
            this.random = random;
            this.logger(string.Format("Seed: {0}", this.random.Seed));
        }

        public Generator(int width, int height, int objects, Action<string> logger, IRandom random)
            : this(logger, random)
        {
            this.width = width;
            this.height = height;
            this.objects = objects;
            this.dungeon = new Dungeon(width, height);
        }

        public Generator CreateDungeon()
        {
            this.FillMap();
            this.MakeRoom(this.width / 2, this.height / 2, 8, 6, RandomDirection());

            var currentFeatures = 1;

            for(int countingTries = 0; countingTries < 1000; countingTries++)
            {
                if(currentFeatures == this.objects)
                {
                    break;
                }

                int newX = 0;
                int xMod = 0;
                int newY = 0;
                int yMod = 0;
                Direction? validTile = null;
            }

            return this;
        }

        public Generator PlacePlayer(Player player)
        {
            int x = this.random.Next(this.ConstructedDungeon.Width);
            int y = this.random.Next(this.ConstructedDungeon.Height);

            var stairsDownTile = new StairsDownTile(this.dungeon, x, y);
            stairsDownTile.AddGameEntity(player);

            return this;
        }

        private void FillMap()
        {
            for(int x = 0; x < this.width; x++)
            {
                for(int y = 0; y < this.height; y++)
                {
                    new WallTile(this.dungeon, x, y);
                }
            }
        }

        private Direction RandomDirection()
        {
            var values = Enum.GetValues(typeof(Direction));

            return (Direction)values.GetValue(this.random.Next(values.Length));
        }

        private bool MakeRoom(int x, int y, int width, int height, Direction direction)
        {
            int xLen = this.random.Next(5, width);
            int yLen = this.random.Next(5, height);

            var points =
                new RoomPointsGenerator(x, y, xLen, yLen)
                    .GeneratePoints(direction)
                    .PointsGenerated;

            if(points.Any(s => s.IsPointValid(this.dungeon)))
            {
                return false;
            }

            this.logger(string.Format("Making room:\nx={0}\nint y={1}\nint width={2}\nint height={3}\nDirection direction={4}\n",
                x, y, width, height, direction));

            foreach(var point in points.Where(s => !s.IsWall))
            {
                TileFactory.MakeTile(this.dungeon, TerrainType.Floor, point);
            }

            return true;
        }
    }
}
