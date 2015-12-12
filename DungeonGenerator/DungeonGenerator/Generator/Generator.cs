using System;
using System.Drawing;
using System.Linq;
using DungeonGenerator.Dungeons;
using DungeonGenerator.Dungeons.Entities;
using DungeonGenerator.Dungeons.Entities.Enums;
using DungeonGenerator.Dungeons.Terrain;
using DungeonGenerator.Dungeons.Terrain.Enums;
using DungeonGenerator.Generator.Interfaces;
using DungeonGenerator.Generator.Tiles;

namespace DungeonGenerator.Generator
{
    public class Generator
    {
        private readonly Dungeon dungeon;
        private readonly IRandom random;

        private readonly int width;
        private readonly int height;

        private readonly Action<string> logger;

        private int MinX
        {
            get
            {
                return 0;
            }
        }

        private int MinY
        {
            get
            {
                return 0;
            }
        }

        private int MaxX
        {
            get
            {
                return this.width - 1;
            }
        }

        private int MaxY
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

        public Generator(int width, int height, Action<string> logger, IRandom random)
            : this(logger, random)
        {
            this.width = width;
            this.height = height;
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
            for(var x = leftX; x <= rightX; x++)
            {
                for(var y = topY; y <= bottomY; y++)
                {
                    Activator.CreateInstance(typeof(TTile), this.dungeon, x, y);
                }
            }
        }

        private void FillMap()
        {
            for(int x = 0; x < this.width; x++)
            {
                for(int y = 0; y < this.height; y++)
                {
                    if(x == this.MinX || y == this.MinY || x == this.MaxX || y == this.MaxY)
                    {
                        new WallTile(this.dungeon, x, y);
                    }
                    else
                    {
                        new FloorTile(this.dungeon, x, y);
                    }
                }
            }
        }

        private Direction RandomDirection()
        {
            var values = Enum.GetValues(typeof(Direction));

            return (Direction)values.GetValue(this.random.Next(values.Length));
        }

        private bool MakeRoom(int x, int y, int xLength, int yLength, Direction direction)
        {
            int xLen = this.random.Next(5, xLength);
            int yLen = this.random.Next(5, yLength);

            TerrainType tileFloor = TerrainType.Floor;
            TerrainType tileWall = TerrainType.Wall;

            var points = 
                new RoomPointsGenerator(x, y, xLen, yLen)
                .GeneratePoints(direction)
                .PointsGenerated;

            if(points.Any(s => 
            s.Y < this.MinY || s.Y > this.MaxY 
            || s.X < this.MinX || s.X > this.MaxX
            || this.dungeon.GetTile(s.X, s.Y).Type == TerrainType.Unused))
            {
                return false;
            }

            this.logger(string.Format("Making room:\nx={0}\nint y={1}\nint xLength={2}\nint yLength={3}\nDirection direction={4}",
                x, y, xLength, yLength, direction));

            foreach(var point in points)
            {
                this.SetCell(p.X, p.Y, IsWall(x, y, xlen, ylen, p.X, p.Y, direction) ? Wall : Floor);
                TileFactory.MakeTile(this.)
            }
        }

        private bool IsWall(int x, int y, int xlen, int ylen, Point tilePoint, Direction direction)
        {
            switch(direction)
            {
                case Direction.North:
                    break;
                case Direction.South:
                    break;
                case Direction.East:
                    break;
                case Direction.West:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }
        }

        private bool IsWallNorth(int x, int y, int xlen, int ylen, Point tilePoint)
        {
            
        }
    }
}
