﻿using System;
using DungeonGenerator.Dungeons.Entities.Enums;
using DungeonGenerator.Dungeons.Entities.Interfaces;

namespace DungeonGenerator.Dungeons.Entities.GameComponents
{
    public class MoveComponent : GameComponent
    {
        public MoveComponent(IMovableGameEntity parentGameEntity) 
            : base(parentGameEntity)
        { }

        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.North :
                    return;
                case Direction.South :
                    return;
                case Direction.East :
                    return;
                case Direction.West :
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
