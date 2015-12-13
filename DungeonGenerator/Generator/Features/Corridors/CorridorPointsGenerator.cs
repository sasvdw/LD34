using System;
using Common.Wrappers;
using Generator.Features.Interfaces;

namespace Generator.Features.Corridors
{
    public class CorridorPointsGenerator : FeaturePointsGenerator
    {
        private readonly int startX;
        private readonly int startY;
        private readonly int length;

        public CorridorPointsGenerator(int startX, int startY, int length)
        {
            this.startX = startX;
            this.startY = startY;
            this.length = length;
        }

        public override bool IsWall(Point point)
        {
            throw new NotImplementedException();
        }

        protected override FeaturePointsGenerator GeneratePoints()
        {
            throw new NotImplementedException();
        }
    }
}
