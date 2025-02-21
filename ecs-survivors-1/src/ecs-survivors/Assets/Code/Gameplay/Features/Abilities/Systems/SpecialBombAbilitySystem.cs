using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Common.Position;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.Features.Cooldown;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class SpecialBombAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _heroes;
        private readonly List<GameEntity> _buffer = new(128);
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGetRandomPositionService _getRandomPositionService;

        public SpecialBombAbilitySystem(GameContext game,
            IArmamentFactory armamentFactory,
            IGetRandomPositionService getRandomPositionService,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _getRandomPositionService = getRandomPositionService;
            _abilityUpgradeService = abilityUpgradeService;
            _armamentFactory = armamentFactory;

            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.WorldPosition));

            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SpecialBombAbility,
                    GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                foreach (GameEntity ability in _abilities.GetEntities(_buffer))
                {
                    Vector3 randomPosition = _getRandomPositionService.RandomPosition(hero.WorldPosition);
                    
                    int abilityLevel = _abilityUpgradeService.GetAbilityLevel(AbilityTypeId.SpecialBomb);

                    _armamentFactory.CreateSpecialBomb(abilityLevel, hero.WorldPosition)
                        .With(x => x.isMoving = true)
                        .With(x => x.ReplaceDirection((randomPosition - x.WorldPosition).normalized))
                        .With(x => x.AddEndPoint(randomPosition))
                        .With(x => x.isMovingAvailable = true);

                    ability.PutOnCooldown();
                }
            }
        }
    }
}