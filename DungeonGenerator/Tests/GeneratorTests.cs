using System.Diagnostics;
using DungeonGenerator.Dungeons.Entities;
using DungeonGenerator.Generator;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void GenerateMap()
        {
            var player = new Player();
            var dungeon = new Generator(10, 10)
                .PlacePlayer(player)
                .ConstructedDungeon;

            var map = dungeon.Map;

            foreach (var monster in dungeon.MonsterDictionary)
            {
                map[monster.Key] = monster.Value;
            }

            foreach (var item in dungeon.ItemDictionary)
            {
                map[item.Key] = item.Value;
            }

            foreach (var dungeonObject in dungeon.DungeonObjectDictionary)
            {
                map[dungeonObject.Key] = dungeonObject.Value;
            }

            map[dungeon.PlayerValuePair.Key] = dungeon.PlayerValuePair.Value;

            for (var i = 0; i < map.Length; i++)
            {
                if (i % dungeon.Width == 0)
                {
                    Debug.WriteLine(string.Empty);
                }

                Debug.Write(map[i]);
            }
        }
    }
}
