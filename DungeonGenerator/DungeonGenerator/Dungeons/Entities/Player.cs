﻿using DungeonGenerator.Dungeons.Entities.Enums;
using DungeonGenerator.Dungeons.Entities.GameComponents;
using DungeonGenerator.Dungeons.Terrain;

namespace DungeonGenerator.Dungeons.Entities
{
    public class Player : GameEntity
    {
        public override bool IsPassable
        {
            get
            {
                return false;
            }
        }

        public override char Type
        {
            get
            {
                return (char)GameEntityType.Player;
            }
        }

        public Player()
        {
            new MoveComponent(this);
        }

        public override void SetCurrentTile(Tile tile)
        {
            this.MoveToNewDungeon(tile.Dungeon);

            base.SetCurrentTile(tile);
        }

        private void MoveToNewDungeon(Dungeon dungeon)
        {
            if(this.dungeon == dungeon)
            {
                return;
            }

            if(this.dungeon != null)
            {
                this.dungeon.RemovePlayer();
            }

            this.dungeon = dungeon;
            dungeon.SetPlayer(this);
        }
    }
}
