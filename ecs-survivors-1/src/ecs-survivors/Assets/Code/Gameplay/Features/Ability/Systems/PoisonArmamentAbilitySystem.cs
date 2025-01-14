using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Enemies.Services;
using Entitas;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class PoisonArmamentAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGetClosestEnemyService _getClosestEnemyService;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _targets;
        private readonly List<GameEntity> _buffer = new(128);

        public PoisonArmamentAbilitySystem(GameContext game, IArmamentFactory armamentFactory, IGetClosestEnemyService getClosestEnemyService)
        {
            _getClosestEnemyService = getClosestEnemyService;
            _armamentFactory = armamentFactory;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.PoisonAbility, GameMatcher.CooldownUp));

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition, GameMatcher.Alive));

            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.Id, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                GameEntity closestEnemy = _getClosestEnemyService.GetClosestEnemy(hero, _enemies);
                
                if(!_targets.ContainsEntity(closestEnemy))
                    continue;

                _armamentFactory.CreatePoisonBolt(1, hero.WorldPosition)
                    .AddFollowTargetId(closestEnemy.Id)
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true)
                    ;

                ability.PutOnCooldown();
            }
        }
    }
}