using System;
using System.Linq;
using Common.Wrappers;
using Dungeons;
using Dungeons.Entities.Enums;
using Dungeons.Terrain.Enums;
using Generator.Features.Rooms;
using Generator.Features.Tiles;
using Generator.Interfaces;

namespace Generator.Features
{
    public class FeatureBuilder
    {
        private readonly IRandom random;
        private readonly Action<string> logger;

        public FeatureBuilder(IRandom random, Action<string> logger)
        {
            this.random = random;
            this.logger = logger;
        }

        public bool MakeRoom(Dungeon dungeon, Point point, int width, int height, Direction direction)
        {
            return this.MakeRoom(dungeon, point.X, point.Y, width, height, direction);
        }

        public bool MakeRoom(Dungeon dungeon, int x, int y, int width, int height, Direction direction)
        {
            int xLen = this.random.Next(5, width);
            int yLen = this.random.Next(5, height);

            var points = new RoomPointsGenerator(x, y, xLen, yLen).GeneratePoints(direction).PointsGenerated.ToList();

            if(!points.Any(s => s.IsPointValid(dungeon)))
            {
                return false;
            }
            this.logger(string.Format("Making room:\nx={0}\nint y={1}\nint width={2}\nint height={3}\nDirection direction={4}\n", x, y, width, height,
                direction));

            foreach (var point in points.Where(s => !s.IsWall))
            {
                TileFactory.MakeTile(dungeon, TerrainType.Floor, point);
            }

            return true;
        }

        public bool MakeCorridor(Dungeon dungeon, Point point, int length, Direction direction)
        {
            return this.MakeCorridor(dungeon, point.X, point.Y, length, direction);
            ;
        }

        private bool MakeCorridor(Dungeon dungeon, int x, int y, int length, Direction direction)
        {
            int len = this.random.Next(2, length);

            return true;
        }
    }
}
