using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Config;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Statuses;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public InitializeHeroSystem(IAbilityUpgradeService abilityUpgradeService)
        {
            _abilityUpgradeService = abilityUpgradeService;
        }

        public void Initialize()
        {
            _abilityUpgradeService.InitializeAbility(AbilityTypeId.VegetableBolt);
            _abilityUpgradeService.InitializeAbility(AbilityTypeId.SpecialBomb);
        }
    }
}