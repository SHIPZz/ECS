using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class StopMovementOnHeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new();

        public StopMovementOnHeroDeathSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero, GameMatcher.Dead));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Moving,GameMatcher.MovingAvailable));
        }

        public void Execute()
        {
            foreach(GameEntity hero in _heroes)
            foreach (GameEntity entity in _enemies.GetEntities(_buffer))
            {
                entity.isMoving = false;
                entity.isMovingAvailable = false;
                entity.ReplaceDirection(Vector3.zero);
            }
        }
    }
}