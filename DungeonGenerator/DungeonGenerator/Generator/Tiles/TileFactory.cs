using System;
using DungeonGenerator.Dungeons;
using DungeonGenerator.Dungeons.Terrain;
using DungeonGenerator.Dungeons.Terrain.Enums;

namespace DungeonGenerator.Generator.Tiles
{
    public static class TileFactory
    {
        public static Tile MakeTile(Dungeon dungeon, TerrainType type, int x, int y)
        {
            switch(type)
            {
                case TerrainType.Floor:
                    return new FloorTile(dungeon, x, y);
                case TerrainType.Wall:
                    return new WallTile(dungeon, x, y);
                case TerrainType.StairsUp:
                    return new StairsUpTile(dungeon, x, y);
                case TerrainType.StairsDown:
                    return new StairsDownTile(dungeon, x, y);
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
