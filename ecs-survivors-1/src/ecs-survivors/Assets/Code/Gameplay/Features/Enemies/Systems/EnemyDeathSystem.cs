using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;

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
            foreach (GameEntity enemy in _enemies)
            {
                enemy.RemoveTargetCollectionComponents();
                enemy.isTurnAlongDirection = false;
                enemy.isMovingAvailable = false;
                
                enemy.EnemyAnimator.PlayDied();

                if (enemy.hasDeathAnimationDuration)
                    enemy.ReplaceSelfDestructTimer(enemy.DeathAnimationDuration);
            }
        }
    }
}