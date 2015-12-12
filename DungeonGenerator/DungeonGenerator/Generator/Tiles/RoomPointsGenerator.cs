using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DungeonGenerator.Dungeons.Entities.Enums;

namespace DungeonGenerator.Generator.Tiles
{
    public class RoomPointsGenerator
    {
        private readonly int startX;
        private readonly int y;
        private readonly int width;
        private readonly int height;
        private readonly IList<DungeonPoint> dungeonPoints;
        private Direction direction;

        private int WidthLowerBound
        {
            get
            {
                return this.startX - this.width / 2;
            }
        }

        private int WidthUpperBound
        {
            get
            {
                return this.startX + (this.width + 1) / 2;
            }
        }

        private int HeightLowerBound
        {
            get
            {
                return this.y - this.height / 2;
            }
        }

        private int HeightUpperBound
        {
            get
            {
                return this.y + (this.height + 1) / 2;
            }
        }

        public IEnumerable<DungeonPoint> PointsGenerated
        {
            get
            {
                return this.dungeonPoints;
            }
        }

        private RoomPointsGenerator()
        {
            this.dungeonPoints = new List<DungeonPoint>();
        }

        public RoomPointsGenerator(int startX, int y, int width, int height)
            : this()
        {
            this.startX = startX;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public RoomPointsGenerator GeneratePoints(Direction direction)
        {
            if(this.direction == direction && this.dungeonPoints.Any())
            {
                return this;
            }

            this.dungeonPoints.Clear();
            this.direction = direction;
            switch(direction)
            {
                case Direction.North:
                    this.GeneratePointsNorth();
                    break;
                case Direction.South:
                    this.GeneratePointsSouth();
                    break;
                case Direction.East:
                    this.GeneratePointsEast();
                    break;
                case Direction.West:
                    this.GeneratePointsWest();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("direction");
            }

            return this;
        }

        private void GeneratePointsNorth()
        {
            for(var x = this.WidthLowerBound; x < WidthUpperBound; x++)
            {
                for(var y = this.y; y > this.y - this.height; y--)
                {
                    this.dungeonPoints.Add(new DungeonPoint(this, x, y));
                }
            }
        }

        private void GeneratePointsSouth()
        {
            for(var x = WidthLowerBound; x < WidthUpperBound; x++)
            {
                for(var y = this.y; y < this.y + this.height; y++)
                {
                   this.dungeonPoints.Add(new DungeonPoint(this, x, y));
                }
            }
        }

        private void GeneratePointsEast()
        {
            for(var x = this.startX; x < this.startX + this.width; x++)
            {
                for(var y = this.HeightLowerBound; y < this.HeightUpperBound; y++)
                {
                    this.dungeonPoints.Add(new DungeonPoint(this, x, y));
                }
            }
        }

        private void GeneratePointsWest()
        {
            for(var x = this.startX; x > this.startX - this.width; x--)
            {
                for(var y = this.HeightLowerBound; y < this.HeightUpperBound; y++)
                {
                    this.dungeonPoints.Add(new DungeonPoint(this, x, y));
                }
            }
        }

        public bool IsWall(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
