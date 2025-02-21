using Code.Gameplay.Common;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class ChaseEnemySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemiesChaseEnemies;
        private readonly IGroup<GameEntity> _enemiesChaseHero;
        private readonly IGetClosestEntityService _getClosestEntityService;

        public ChaseEnemySystem(GameContext game, IGetClosestEntityService getClosestEntityService)
        {
            _getClosestEntityService = getClosestEntityService;
            _enemiesChaseEnemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.WorldPosition
                ).NoneOf(GameMatcher.ChaseHero));

            _enemiesChaseHero = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Alive,
                    GameMatcher.ChaseHero,
                    GameMatcher.WorldPosition
                ));
        }

        public void Execute()
        {
            foreach (GameEntity enemyChaseEnemy in _enemiesChaseEnemies)
            {
                GameEntity closestEnemy = _getClosestEntityService.GetClosestEntity(enemyChaseEnemy, _enemiesChaseHero);

                if (closestEnemy != null)
                    enemyChaseEnemy?.ReplaceDirection((closestEnemy.WorldPosition - enemyChaseEnemy.WorldPosition)
                        .normalized);
            }
        }
    }
}