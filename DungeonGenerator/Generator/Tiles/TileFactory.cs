using System;
using Dungeons.Terrain;
using Dungeons.Terrain.Enums;

namespace Generator.Tiles
{
    public static class TileFactory
    {
        public static Tile MakeTile(Dungeons.Dungeon dungeon, TerrainType type, int x, int y)
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

        public static Tile MakeTile(Dungeons.Dungeon dungeon, TerrainType type, DungeonPoint point)
        {
            return MakeTile(dungeon, type, point.X, point.Y);
        }
    }
}
