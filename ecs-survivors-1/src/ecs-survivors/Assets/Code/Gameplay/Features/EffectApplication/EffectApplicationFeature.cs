using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.EffectApplication
{
    public sealed class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyEffectsOnTargetsSystem>());
        }
    }
}