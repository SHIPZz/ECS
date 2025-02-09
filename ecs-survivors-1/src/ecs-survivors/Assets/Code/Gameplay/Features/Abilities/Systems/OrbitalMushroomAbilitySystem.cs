using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class OrbitalMushroomAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly IStaticDataService _staticDataService;
        private readonly List<GameEntity> _buffer = new(64);
        private IAbilityUpgradeService _abilityUpgradeService;

        public OrbitalMushroomAbilitySystem(GameContext game, IArmamentFactory armamentFactory,
            IStaticDataService staticDataService,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;
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

                    int level = _abilityUpgradeService.GetAbilityLevel(AbilityTypeId.OrbitalMushroom);

                    _armamentFactory.CreateOrbitalMushroom(level, hero.WorldPosition, phase)
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