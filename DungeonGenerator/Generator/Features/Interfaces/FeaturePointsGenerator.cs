using System.Collections.Generic;
using System.Linq;
using Common.Wrappers;
using Dungeons.Entities.Enums;

namespace Generator.Features.Interfaces
{
    public abstract class FeaturePointsGenerator
    {
        protected IList<DungeonPoint> dungeonPoints;
        protected Direction direction;

        public IEnumerable<DungeonPoint> PointsGenerated
        {
            get
            {
                return this.dungeonPoints;
            }
        }

        protected FeaturePointsGenerator()
        {
            this.dungeonPoints = new List<DungeonPoint>();
        }

        public FeaturePointsGenerator GeneratePoints(Direction direction)
        {
            if (this.direction == direction && this.dungeonPoints.Any())
            {
                return this;
            }

            this.dungeonPoints.Clear();
            this.direction = direction;

            return this.GeneratePoints();
        }

        public abstract bool IsWall(Point point);

        protected abstract FeaturePointsGenerator GeneratePoints();
    }
}
