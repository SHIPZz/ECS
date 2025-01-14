using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armament;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class BouncingAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(128);
        private readonly IGroup<GameEntity> _enemies;

        public BouncingAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy, 
                GameMatcher.WorldPosition,
                GameMatcher.Alive));
            
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero, 
                GameMatcher.WorldPosition));
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BouncingAbility,
                    GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                GameEntity target =GetClosestTarget(hero);

                _armamentFactory.CreateBouncingBolt(1, hero.WorldPosition)
                    .With(x => x.AddFollowTargetId(target.Id))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true);

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