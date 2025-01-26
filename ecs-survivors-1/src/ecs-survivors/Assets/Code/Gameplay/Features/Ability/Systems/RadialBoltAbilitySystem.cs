using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class RadialBoltAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IStaticDataService _staticDataService;
        private readonly IArmamentFactory _armamentFactory;
        private readonly List<GameEntity> _buffer = new(32);

        public RadialBoltAbilitySystem(GameContext game, IArmamentFactory armamentFactory, IStaticDataService staticDataService)
        {
            _armamentFactory = armamentFactory;
            _staticDataService = staticDataService;
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));

            _abilities = game.GetGroup(GameMatcher.AllOf(GameMatcher.RadialAbility, GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                Vector3 heroPosition = hero.worldPosition.Value;
                ProjectileSetup projectileSetup = _staticDataService.GetAbilityLevel(AbilityTypeId.Radial, 1).ProjectileSetup;

                for (int i = 0; i < projectileSetup.RadialCount; i++)
                {
                    float angle = i * Mathf.PI * projectileSetup.RadialRadius / projectileSetup.RadialCount;
                    Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

                    _armamentFactory.CreateRadialBolt(1, heroPosition)
                        .ReplaceDirection(direction)
                        .With(x => x.isMoving = true)
                        .With(x => x.isMovingAvailable = true)
                        ;
                }

                ability.PutOnCooldown();
            }
        }
    }
}

