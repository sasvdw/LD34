using System;
using DungeonGenerator.Generator.Interfaces;

namespace Tests.Helpers
{
    public class RandomGenerator : IRandom
    {
        private readonly Random random;

        public RandomGenerator()
        {
            this.Seed = DateTime.Now.Millisecond;
            this.random = new Random(this.Seed);
        }

        public int Seed { get; private set; }

        public int Next(int maxValue)
        {
            return this.random.Next(maxValue);
        }

        public int Next(int minValue, int maxValue)
        {
            return this.random.Next(minValue, maxValue);
        }
    }
}
