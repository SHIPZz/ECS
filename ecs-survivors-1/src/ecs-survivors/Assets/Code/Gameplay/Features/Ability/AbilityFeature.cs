using Code.Gameplay.Features.Ability.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Ability
{
    public sealed class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systems)
        {
            Add(systems.Create<VegetableBoltAbilitySystem>());
            Add(systems.Create<RadialBoltAbilitySystem>());
            Add(systems.Create<BouncingAbilitySystem>());
            Add(systems.Create<ScatteringAbilitySystem>());
        }
    }
}