using System;
using Common.Wrappers;
using Dungeons.Entities.Enums;
using Dungeons.Terrain;

namespace Generator.Features
{
    public class NextFeatureStartResult
    {
        private readonly Tile roomDoorTile;
        private readonly Direction? reachableAdjacentTileDirection;

        public Point NewRoomStart
        {
            get
            {
                switch(this.NewRoomDirection)
                {
                    case Direction.North:
                        return new Point(this.roomDoorTile.X, this.roomDoorTile.Y - 1);
                    case Direction.South:
                        return new Point(this.roomDoorTile.X, this.roomDoorTile.Y + 1);
                    case Direction.East:
                        return new Point(this.roomDoorTile.X + 1, this.roomDoorTile.Y);
                    case Direction.West:
                        return new Point(this.roomDoorTile.X - 1, this.roomDoorTile.Y);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Point DoorPoint
        {
            get
            {
                return new Point(this.roomDoorTile.X, this.roomDoorTile.Y);
            }
        }

        public Direction NewRoomDirection
        {
            get
            {
                switch(this.reachableAdjacentTileDirection)
                {
                    case Direction.North:
                        return Direction.South;
                    case Direction.South:
                        return Direction.North;
                    case Direction.East:
                        return Direction.West;
                    case Direction.West:
                        return Direction.East;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public bool IsValidStart
        {
            get
            {
                return this.roomDoorTile != null || this.reachableAdjacentTileDirection.HasValue;
            }
        }

        public NextFeatureStartResult() { }

        public NextFeatureStartResult(Tile roomDoorTile, Direction reachableAdjacentTileDirection)
        {
            this.roomDoorTile = roomDoorTile;
            this.reachableAdjacentTileDirection = reachableAdjacentTileDirection;
        }
    }
}
