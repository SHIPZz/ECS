using Code.Gameplay.Features.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
    public sealed class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<VegetableBoltAbilitySystem>());
            Add(systemses.Create<DestroyAbilityEntitiesOnUpgradeSystem>());
            Add(systemses.Create<MagnificentBoltAbilitySystem>());
            Add(systemses.Create<RadialBoltAbilitySystem>());
            Add(systemses.Create<BouncingAbilitySystem>());
            Add(systemses.Create<SpecialBombAbilitySystem>());
            Add(systemses.Create<FireAuraAbilitySystem>());
            Add(systemses.Create<ScatteringAbilitySystem>());
            Add(systemses.Create<GarlicAuraAbilitySystem>());
            Add(systemses.Create<OrbitalMushroomAbilitySystem>());
            Add(systemses.Create<CreateStatusOnTargetsSystem>());
        }
    }
}