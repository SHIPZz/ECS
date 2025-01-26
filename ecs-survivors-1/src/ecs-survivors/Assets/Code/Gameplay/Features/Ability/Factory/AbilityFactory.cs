using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Ability.Config;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Ability.Factory
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IIdentifierService _identifierService;

        public AbilityFactory(IStaticDataService staticDataService, IIdentifierService identifierService)
        {
            _identifierService = identifierService;
            _staticDataService = staticDataService;
        }

        public void CreateAbility(AbilityTypeId abilityTypeId, int level)
        {
            switch (abilityTypeId)
            {
                case AbilityTypeId.None:
                    break;
                case AbilityTypeId.VegetableBolt:
                    CreateVegetableAbility(level);
                    break;
                case AbilityTypeId.Radial:
                    CreateRadialBoltAbility(level);
                    break;
                case AbilityTypeId.Scattering:
                    CreateScatteringBoltAbility(level);
                    break;
                case AbilityTypeId.Bounce:
                    CreateBounceBoltAbility(level);
                    break;
                case AbilityTypeId.Poison:
                    CreatePoisonBoltAbility(level);
                    break;
                case AbilityTypeId.Vampirism:
                    CreateVampirismBoltAbility(level);
                    break;
                
                case AbilityTypeId.SpeedUp:
                    CreateSpeedUpAbility(level);
                    break;
                
                case AbilityTypeId.OrbitalMushroom:
                    CreateOrbitingMushroomAbility(1);
                    break;
                
                case AbilityTypeId.GarlicAura:
                    CreateGarlicAuraAbility(1);
                    break;
                
                case AbilityTypeId.Magnificent:
                    CreateMagnificentBolt(1);
                    break;

                
                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityTypeId), abilityTypeId, "there is no ability");
            }
        }
        
        public GameEntity CreateMagnificentBolt(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Magnificent, level);
            
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .AddAbilityTypeId(AbilityTypeId.Magnificent)
                    .With(x => x.isMagnificentBoltAbility = true)
                ;
        }
        
        public GameEntity CreateGarlicAuraAbility(int level)
        {
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddAbilityTypeId(AbilityTypeId.GarlicAura)
                    .With(x => x.isGarlicAuraAbility = true)
                ;
        }
        
        public GameEntity CreateOrbitingMushroomAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.OrbitalMushroom, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isOrbitingMushroomAbility = true)
                ;
        }


        public GameEntity CreateVampirismBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Vampirism, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isVampirismAbility = true)
                ;
        }

        public GameEntity CreatePoisonBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Poison, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isPoisonAbility = true)
                ;
        }
        
        public GameEntity CreateScatteringBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Scattering, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isScatteringAbility = true)
                ;
        }
        
        public GameEntity CreateBounceBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Bounce, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isBouncingAbility = true)
                ;
        }

        
        public GameEntity CreateRadialBoltAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.Radial, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isRadialAbility = true)
                ;
        }
        
        public GameEntity CreateMaxHpIncreaseAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.SpeedUp, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.ReplaceCooldownLeft(0))
                    .With(x => x.isIncreaseMaxHpAbility = true)
                ;
        }
        
        public GameEntity CreateSpeedUpAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.SpeedUp, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.ReplaceCooldownLeft(0))
                    .With(x => x.isSpeedUpAbility = true)
                ;
        }

        public GameEntity CreateVegetableAbility(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.VegetableBolt, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .With(x => x.isVegetableBoltAbility = true)
                ;
        }
    }
}