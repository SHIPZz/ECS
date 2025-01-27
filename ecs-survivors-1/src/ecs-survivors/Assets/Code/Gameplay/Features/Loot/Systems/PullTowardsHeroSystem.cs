﻿using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class PullTowardsHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullables;
        private readonly IGroup<GameEntity> _heroes;

        public PullTowardsHeroSystem(GameContext game)
        {
            _pullables = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Pulling,
                    GameMatcher.WorldPosition
                ));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity pullable in _pullables)
            {
                // pullable.ReplaceDirection((hero.WorldPosition - pullable.WorldPosition).normalized);
                // pullable.ReplaceSpeed(4f);
                // pullable.isMoving = true;
                // pullable.isMovingAvailable = true;
            }
        }
    }
}