using System;
using Common.Wrappers;
using Dungeons.Entities.Enums;
using Generator.Features.Interfaces;

namespace Generator.Features.Rooms
{
    public class RoomPointsGenerator : FeaturePointsGenerator
    {
        private readonly int startX;
        private readonly int startY;
        private readonly int width;
        private readonly int height;

        private int WidthLowerBound
        {
            get
            {
                switch(this.direction)
                {
                    case Direction.North:
                    case Direction.South:
                        return this.startX - this.width / 2;
                    case Direction.East:
                        return this.startX;
                    case Direction.West:
                        return this.startX - this.width;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private int WidthUpperBound
        {
            get
            {
                switch(this.direction)
                {
                    case Direction.North:
                    case Direction.South:
                        return this.startX + (this.width + 1) / 2;
                    case Direction.East:
                        return this.startX + this.width;
                    case Direction.West:
                        return this.startX;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private int HeightLowerBound
        {
            get
            {
                switch(this.direction)
                {
                    case Direction.North:
                        return this.startY - this.height;
                    case Direction.South:
                        return this.startY;
                    case Direction.East:
                    case Direction.West:
                        return this.startY - this.height / 2;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private int HeightUpperBound
        {
            get
            {
                switch(this.direction)
                {
                    case Direction.North:
                        return this.startY;
                    case Direction.South:
                        return this.startY + this.height;
                    case Direction.East:
                    case Direction.West:
                        return this.startY + (this.height + 1) / 2;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private int WallWidthLowerBound
        {
            get
            {
                return this.WidthLowerBound;
            }
        }

        private int WallWidthUpperBound
        {
            get
            {
                return this.WidthUpperBound - 1;
            }
        }

        private int WallHeightLowerBound
        {
            get
            {
                return this.HeightLowerBound;
            }
        }

        private int WallHeightUpperBound
        {
            get
            {
                return this.HeightUpperBound - 1;
            }
        }

        public RoomPointsGenerator(int startX, int startY, int width, int height)
        {
            this.startX = startX;
            this.startY = startY;
            this.width = width;
            this.height = height;
        }

        public override bool IsWall(Point point)
        {
            return this.IsWall(point.X, point.Y);
        }

        protected override FeaturePointsGenerator GeneratePoints()
        {
            for(int x = this.WidthLowerBound; x < this.WidthUpperBound; x++)
            {
                for(int y = this.WallHeightLowerBound; y < this.HeightUpperBound; y++)
                {
                    this.dungeonPoints.Add(new DungeonPoint(this, x, y));
                }
            }

            return this;
        }

        private bool IsWall(int x, int y)
        {
            return x == this.WallWidthLowerBound || x == this.WallWidthUpperBound || y == this.WallHeightLowerBound || y == this.WallHeightUpperBound;
        }
    }
}
