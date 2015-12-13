using System.Linq;
using Dungeons;
using Dungeons.Terrain;
using Generator.Features.Tiles;
using Generator.Interfaces;

namespace Generator.Features
{
    public class FeatureStartGenerator
    {
        private readonly IRandom random;

        public FeatureStartGenerator(IRandom random)
        {
            this.random = random;
        }

        public NextFeatureStartResult FindNextFeatureStart(Dungeon dungeon)
        {
            for(var testing = 0; testing < 1000; testing++)
            {
                var x = this.random.Next(1, dungeon.Width - 1);
                var y = this.random.Next(1, dungeon.Height - 1);

                var tile = dungeon.GetTile(x, y);

                var surroundings = tile.Surroundings;

                if(!surroundings.Any(s => (s.Value is CorridorTile || s.Value is FloorTile) && !(s.Value is WallTile)))
                {
                    continue;
                }

                if(surroundings.Any(s => s.Value is DoorTile))
                {
                    continue;
                }

                var reachableTile = surroundings.First(s => (s.Value is CorridorTile || s.Value is FloorTile) && !(s.Value is WallTile));
                
                return new NextFeatureStartResult(tile, reachableTile.Key);
            }

            return new NextFeatureStartResult();
        }
    }
}
