using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Ability.Systems
{
    public class OrbitalMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _buffer = new(64);

        public OrbitalMushroomAbilitySystem(GameContext game, IArmamentFactory armamentFactory,
            IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));

            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.OrbitingMushroomAbility,
                    GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.OrbitalMushroom, 1);

                ProjectileSetup projectileSetup = abilityLevel.ProjectileSetup;

                for (int i = 0; i < projectileSetup.ProjectileCount; i++)
                {
                    var phase = (2 * Mathf.PI * i) / projectileSetup.ProjectileCount;

                    _armamentFactory.CreateOrbitalMushroom(1, hero.WorldPosition, phase)
                        .AddProducerId(hero.Id)
                        .AddOrbitCenterFollowTarget(hero.Id)
                        .AddOrbitCenterPosition(hero.WorldPosition)
                        .With(x => x.isMoving = true)
                        .With(x => x.isMovingAvailable = true)
                        ;
                }


                ability.PutOnCooldown(abilityLevel.Cooldown);
            }
        }
    }
}