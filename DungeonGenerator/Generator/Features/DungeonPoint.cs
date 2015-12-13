using Common.Wrappers;
using Dungeons;
using Dungeons.Terrain.Enums;
using Generator.Features.Interfaces;

namespace Generator.Features
{
    public class DungeonPoint : Point
    {
        private readonly FeaturePointsGenerator featurePointsGenerator;

        public bool IsWall
        {
            get
            {
                return this.featurePointsGenerator.IsWall(this);
            }
        }

        public DungeonPoint(FeaturePointsGenerator featurePointsGenerator, int x, int y)
            : base(x, y)
        {
            this.featurePointsGenerator = featurePointsGenerator;
        }

        public bool IsPointValid(Dungeon dungeon)
        {
            return this.IsPointOutsideDungeon(dungeon) ||
                   dungeon.GetTile(this.point).Type == TerrainType.Unused;
        }

        private bool IsPointOutsideDungeon(Dungeon dungeon)
        {
            return this.point.X < 0 || this.point.X >= dungeon.Width
                   || this.point.Y < 0 || this.point.Y >= dungeon.Height;
        }
    }
}
