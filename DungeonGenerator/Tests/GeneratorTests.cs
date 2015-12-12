using System;
using System.Diagnostics;
using DungeonGenerator.Dungeons.Entities;
using DungeonGenerator.Generator;
using DungeonGenerator.Generator.Interfaces;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests
{
    [TestFixture]
    public class GeneratorTests
    {
        private IRandom random;
        private Player player;

        [SetUp]
        public void SetUp()
        {
            this.random = new RandomGenerator();
            this.player = new Player();
        }

        [Test]
        public void GenerateMap()
        {
            Action<string> logger = (msg) => Debug.WriteLine(msg);
            var dungeon = new Generator(40, 30, logger, this.random)
                .PlacePlayer(this.player)
                .ConstructedDungeon;

            var map = dungeon.Map;

            foreach(var monster in dungeon.MonsterDictionary)
            {
                map[monster.Key] = monster.Value;
            }

            foreach(var item in dungeon.ItemDictionary)
            {
                map[item.Key] = item.Value;
            }

            foreach(var dungeonObject in dungeon.DungeonObjectDictionary)
            {
                map[dungeonObject.Key] = dungeonObject.Value;
            }

            map[dungeon.PlayerValuePair.Key] = dungeon.PlayerValuePair.Value;

            for(var i = 0; i < map.Length; i++)
            {
                if(i % dungeon.Width == 0 && i != 0)
                {
                    Debug.WriteLine(string.Empty);
                }

                Debug.Write(map[i]);
            }
        }
    }
}
