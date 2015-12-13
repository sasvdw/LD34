using System;
using Common.Wrappers;
using Dungeons;
using Dungeons.Terrain;
using Dungeons.Terrain.Enums;

namespace Generator.Features.Tiles
{
    public static class TileFactory
    {
        public static Tile MakeTile(Dungeon dungeon, TerrainType type, int x, int y)
        {
            switch(type)
            {
                case TerrainType.Floor:
                    return new FloorTile(dungeon, x, y);
                case TerrainType.StairsUp:
                    return new StairsUpTile(dungeon, x, y);
                case TerrainType.StairsDown:
                    return new StairsDownTile(dungeon, x, y);
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public static Tile MakeTile(Dungeon dungeon, TerrainType type, Point point)
        {
            return MakeTile(dungeon, type, point.X, point.Y);
        }

        public static Tile MakeDoorTile(Dungeon dungeon, int x, int y)
        {
            return new DoorTile(dungeon, x, y);
        }

        public static Tile MakeDoorTile(Dungeon dungeon, Point point)
        {
            return MakeDoorTile(dungeon, point.X, point.Y);
        }
    }
}
