using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Armament.Systems
{
    public class ReplaceArmamentChaseTargetOnCollectSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public ReplaceArmamentChaseTargetOnCollectSystem(IContext<GameEntity> context) : base(context)
        {
            _enemies = context.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition));
            _heroes = context.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Collected.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isBouncingArmament && entity.isCollected;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity armament in entities)
            {
                GameEntity target = GetFirstAvailableTarget(armament);

                if (target == null)
                {
                    armament.ReplaceChaseTargetId(hero.Id);
                    continue;
                }

                armament.ReplaceChaseTargetId(target.Id);
                armament.ReplaceBouncingCount(armament.BouncingCount + 1);

                armament.isCollected = false;
            }
        }

        private GameEntity GetFirstAvailableTarget(GameEntity armament)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;

            foreach (GameEntity enemy in _enemies)
            {
                if (enemy.isDead)
                    continue;

                var distanceToTarget = Vector3.Distance(enemy.WorldPosition, armament.WorldPosition);

                if (distanceToTarget <= maxDistance)
                {
                    maxDistance = distanceToTarget;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}