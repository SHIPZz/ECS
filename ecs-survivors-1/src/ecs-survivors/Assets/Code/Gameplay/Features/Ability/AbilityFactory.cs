using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Ability
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
            AbilityConfig config = _staticDataService.GetAbilityConfig(abilityTypeId);
            
            return CreateEntity
                    .Empty()
                    .AddId(_identifierService.Next())
                    .AddCooldown(config.Cooldown)
                    .AddCooldownLeft(config.Cooldown)
                    .With(x => x.isVegetableBoltAbility = true)
                ;
        }
    }
}