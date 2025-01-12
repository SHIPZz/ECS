using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Death
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(128);

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Dead,
                    GameMatcher.DeathProcessing
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            {
                enemy.RemoveTargetCollectionComponents();
                enemy.isTurnAlongDirection = false;
                enemy.isMovingAvailable = false;
                
                enemy.EnemyAnimator.PlayDied();

                if (enemy.hasSelfDestructTimer)
                    enemy.ReplaceSelfDestructTimer(enemy.DeathAnimationTime);
            }
        }
    }
}