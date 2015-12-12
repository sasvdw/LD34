using System;
using System.Diagnostics;
using System.Linq;
using Dungeons.Entities.Players;
using Generator.Interfaces;
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
            var dungeon = new Generator.Generator(40, 30, 10, logger, this.random)
                .CreateDungeon()
                .PlacePlayer(this.player)
                .ConstructedDungeon;

            var map = dungeon.Map.Select(x => (char)x).ToArray();

            foreach(var monster in dungeon.MonsterDictionary)
            {
                map[monster.Key] = (char)monster.Value;
            }

            foreach(var item in dungeon.ItemDictionary)
            {
                map[item.Key] = (char)item.Value;
            }

            foreach(var dungeonObject in dungeon.DungeonObjectDictionary)
            {
                map[dungeonObject.Key] = (char)dungeonObject.Value;
            }

            map[dungeon.PlayerValuePair.Key] = (char)dungeon.PlayerValuePair.Value;

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
