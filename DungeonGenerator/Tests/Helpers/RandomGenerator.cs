using System;
using Generator.Interfaces;

namespace Tests.Helpers
{
    public class RandomGenerator : IRandom
    {
        private readonly Random random;

        public int Seed { get; private set; }

        public RandomGenerator()
            : this(DateTime.Now.Millisecond) {}

        public RandomGenerator(int seed)
        {
            this.Seed = seed;
            this.random = new Random(this.Seed);
        }

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
