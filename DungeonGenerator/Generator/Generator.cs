using System;
using System.Collections.Generic;
using System.Linq;
using Dungeons;
using Dungeons.Entities.Enums;
using Dungeons.Entities.Players;
using Dungeons.Terrain;
using Dungeons.Terrain.Enums;
using Generator.Interfaces;
using Generator.Tiles;
using WallTile = Generator.Tiles.WallTile;

namespace Generator
{
    public class Generator
    {
        private readonly Dungeon dungeon;
        private readonly IRandom random;

        private readonly int width;
        private readonly int height;
        private readonly int objects;
        private readonly int roomChance;

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

        public Generator(int width, int height, int objects, int roomChance, Action<string> logger, IRandom random)
            : this(logger, random)
        {
            this.width = width;
            this.height = height;
            this.objects = objects;
            this.roomChance = roomChance;

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

                KeyValuePair<Direction, Tile> validTile = new KeyValuePair<Direction, Tile>();
                for(int testing = 0; testing < 1000; testing++)
                {
                    newX = this.random.Next(1, this.MaxX);
                    newY = this.random.Next(1, this.MaxY);

                    var tile = this.dungeon.GetTile(newX, newY);


                    if(!(tile is WallTile) && !(tile is CorridorTile))
                    {
                        continue;
                    }

                    var surroundings = tile.Surroundings;

                    if(surroundings.All(x => !(x.Value is WallTile) && !(x.Value is CorridorTile)))
                    {
                        continue;
                    }

                    validTile = surroundings.First(x => x.Value is CorridorTile || x.Value is FloorTile);

                    switch(validTile.Key)
                    {
                        case Direction.North:
                            xMod = 0;
                            yMod = -1;
                            break;
                        case Direction.South:
                            xMod = 0;
                            yMod = 1;
                            break;
                        case Direction.East:
                            xMod = 1;
                            yMod = 0;
                            break;
                        case Direction.West:
                            xMod = -1;
                            yMod = 0;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    var otherSurroundings = surroundings.Where(x => x.Key != validTile.Key);

                    if(otherSurroundings.Any(x => x.Value is DoorTile))
                    {
                        validTile = new KeyValuePair<Direction, Tile>(validTile.Key, null);
                    }

                    if(validTile.Value != null)
                    {
                        break;
                    }
                }

                if(validTile.Value == null)
                {
                    continue;
                }

                int feature = this.random.Next(0, 100);

                if(feature <= this.roomChance)
                {
                    if(this.MakeRoom(newX + xMod, newY + yMod, 8, 6, validTile.Key))
                    {
                        currentFeatures++;

                        TileFactory.MakeDoorTile(this.dungeon, newX, newY);

                        TileFactory.MakeTile(this.dungeon, TerrainType.Floor, newX + xMod, newY + yMod);
                    }
                }
                else if(feature >= roomChance)
                {
                    
                }
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

            var points = new RoomPointsGenerator(x, y, xLen, yLen).GeneratePoints(direction).PointsGenerated;

            if(points.Any(s => s.IsPointValid(this.dungeon)))
            {
                return false;
            }

            this.logger(string.Format("Making room:\nx={0}\nint y={1}\nint width={2}\nint height={3}\nDirection direction={4}\n", x, y, width, height, direction));

            foreach(var point in points.Where(s => !s.IsWall))
            {
                TileFactory.MakeTile(this.dungeon, TerrainType.Floor, point);
            }

            return true;
        }
    }
}
