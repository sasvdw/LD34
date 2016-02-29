using Common.Wrappers;
using Dungeons;
using Dungeons.Terrain.Enums;
using Generator.Features.Interfaces;
using Generator.Features.Tiles;

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
            return this.IsPointInsideDungeon(dungeon) ||
                   dungeon.GetTile(this.point)is WallTile;
        }

        private bool IsPointInsideDungeon(Dungeon dungeon)
        {
            return this.point.X >= 0 && this.point.X < dungeon.Width
                   && this.point.Y >= 0 && this.point.Y < dungeon.Height;
        }
    }
}
