using Code.Gameplay.Features.Ability.Systems;
using Code.Gameplay.Features.Movement;

namespace Code.Gameplay.Features.Ability
{
    public sealed class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systems)
        {
            Add(systems.Create<VegetableBoltAbilitySystem>());
        }
    }
}