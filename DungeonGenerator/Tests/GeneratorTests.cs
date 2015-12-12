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
        private int width;
        private int height;
        private int objects;
        private int roomchance;

        [SetUp]
        public void SetUp()
        {
            this.random = new RandomGenerator();
            this.player = new Player();

            this.width = 40;
            this.height = 30;
            this.objects = 10;
            this.roomchance = 75;
        }

        [Test]
        public void GenerateMap()
        {
            Action<string> logger = (msg) => Debug.WriteLine(msg);
            var dungeon = new Generator.Generator(this.width, this.height, this.objects, this.roomchance, logger, this.random)
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
