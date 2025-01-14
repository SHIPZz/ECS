using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class ScatteringAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(32);

        public ScatteringAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition, GameMatcher.Alive));
            _abilities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ScatteringAbility, GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                if (_enemies.count <= 0)
                    continue;

                GameEntity target = GetClosestTarget(hero);

                if(target == null)
                    continue;

                _armamentFactory.CreateScatteringBolt(1, hero.WorldPosition)
                    .With(x => x.AddFollowTargetId(target.Id))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true)
                    ;

                ability.PutOnCooldown();
            }
        }

        private GameEntity GetClosestTarget(GameEntity entity)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;

            foreach (GameEntity enemy in _enemies)
            {
                float distanceToTarget = Vector3.Distance(enemy.WorldPosition, entity.WorldPosition);

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