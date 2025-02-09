using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.Features.Enemies.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class ScatteringAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(32);
        private readonly IGroup<GameEntity> _targets;
        private IGetClosestEntityService _getClosestEntityService;

        public ScatteringAbilitySystem(GameContext game, IArmamentFactory armamentFactory, IGetClosestEntityService getClosestEntityService)
        {
            _getClosestEntityService = getClosestEntityService;
            _armamentFactory = armamentFactory;
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.WorldPosition, GameMatcher.Alive));
            _abilities = game.GetGroup(GameMatcher.AllOf(GameMatcher.ScatteringAbility, GameMatcher.CooldownUp));

            _targets = game.GetGroup(GameMatcher.AllOf(GameMatcher.WorldPosition, GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                if (_enemies.count <= 0)
                    continue;

                GameEntity target = _getClosestEntityService.GetClosestEntity(hero, _enemies);

                if(!_targets.ContainsEntity(target))
                    continue;

                _armamentFactory.CreateScatteringBolt(1, hero.WorldPosition)
                    .With(x => x.AddFollowTargetId(target.Id))
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovingAvailable = true)
                    ;

                ability.PutOnCooldown();
            }
        }
    }
}