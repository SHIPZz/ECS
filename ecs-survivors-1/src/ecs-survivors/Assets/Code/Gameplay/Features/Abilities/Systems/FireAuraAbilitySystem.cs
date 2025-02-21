using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armament.Factory;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class FireAuraAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IArmamentFactory _armamentFactory;
        private readonly List<GameEntity> _buffer = new(64);
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _heroes;

        public FireAuraAbilitySystem(GameContext game, IArmamentFactory armamentFactory, 
            IAbilityUpgradeService abilityUpgradeService,
            IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _armamentFactory = armamentFactory;
            _abilityUpgradeService = abilityUpgradeService;

            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.FireAuraAbility)
                .NoneOf(GameMatcher.Active));
            
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                int level = _abilityUpgradeService.GetAbilityLevel(AbilityTypeId.FireAura);

               AuraSetup auraSetup = _staticDataService.GetAbilityLevel(AbilityTypeId.FireAura, level)
                   .AuraSetup;

               int targetProducer = ability.hasProducerId ? ability.ProducerId : hero.Id;
               
                _armamentFactory.CreateAura(AbilityTypeId.FireAura,auraSetup, targetProducer)
                    ;
                
                ability.isActive = true;
            }
        }
    }
}