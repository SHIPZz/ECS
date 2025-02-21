using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class CountEnemyDeadSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enemyDeadCounter;

        public CountEnemyDeadSystem(IContext<GameEntity> game) : base(game)
        {
            _enemyDeadCounter = game.GetGroup(GameMatcher.EnemyDeadCount);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.Enemy,GameMatcher.Dead));

        protected override bool Filter(GameEntity entity) => entity.isDead;

        protected override void Execute(List<GameEntity> deadEnemies)
        {
            foreach (GameEntity deadEnemy in deadEnemies)
            foreach (GameEntity enemyDeadCounter in _enemyDeadCounter)
            {
                enemyDeadCounter.ReplaceEnemyDeadCount(enemyDeadCounter.EnemyDeadCount + 1);
            }
        }
    }

}