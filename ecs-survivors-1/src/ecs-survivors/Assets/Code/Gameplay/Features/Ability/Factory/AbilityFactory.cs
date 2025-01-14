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