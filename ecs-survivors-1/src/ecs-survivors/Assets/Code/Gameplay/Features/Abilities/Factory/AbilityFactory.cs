using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Cooldown;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
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

        public GameEntity CreateAbility(AbilityTypeId abilityTypeId, int level)
        {
            switch (abilityTypeId)
            {
                case AbilityTypeId.None:
                    break;

                case AbilityTypeId.VegetableBolt:
                    return CreateVegetableAbility(level);

                case AbilityTypeId.Radial:
                    return CreateRadialBoltAbility(level);

                case AbilityTypeId.Scattering:
                    return CreateScatteringBoltAbility(level);

                case AbilityTypeId.Bounce:
                    return CreateBounceBoltAbility(level);

                case AbilityTypeId.SpeedUp:
                    return CreateSpeedUpAbility(level);

                case AbilityTypeId.OrbitalMushroom:
                    return CreateOrbitingMushroomAbility(level);

                case AbilityTypeId.GarlicAura:
                    return CreateGarlicAuraAbility(level);

                case AbilityTypeId.Magnificent:
                    return CreateMagnificentBolt(level);

                case AbilityTypeId.SpecialBomb:
                    return CreateSpecialBomb(level);
                
                case AbilityTypeId.FireAura:
                    return CreateFireAura(level);

                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityTypeId), abilityTypeId, "there is no ability");
            }

            throw new ArgumentOutOfRangeException(nameof(abilityTypeId), abilityTypeId, "there is no ability");
        }
        
        public GameEntity CreateFireAura(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.FireAura, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .AddAbilityTypeId(AbilityTypeId.FireAura)
                    .With(x => x.isFireAuraAbility = true)
                    .With(x => x.isRecreatedOnUpdate = true)
                ;
        }

        public GameEntity CreateSpecialBomb(int level)
        {
            AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityTypeId.SpecialBomb, level);

            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(abilityLevel.Cooldown)
                    .PutOnCooldown()
                    .AddAbilityTypeId(AbilityTypeId.SpecialBomb)
                    .With(x => x.isSpecialBombAbility = true)
                ;
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
                    .With(x => x.isRecreatedOnUpdate = true)
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
                    .With(x => x.isRecreatedOnUpdate = true)
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