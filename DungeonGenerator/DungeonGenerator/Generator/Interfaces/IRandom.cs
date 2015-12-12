namespace DungeonGenerator.Generator.Interfaces
{
    public interface IRandom
    {
        int Seed { get; }

        int Next(int maxValue);

        int Next(int minValue, int maxValue);
    }
}
