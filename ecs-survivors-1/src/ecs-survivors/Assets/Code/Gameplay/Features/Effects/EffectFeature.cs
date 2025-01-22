using Code.Gameplay.Features.Effects.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Effects
{
    public sealed class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systems)
        {
            Add(systems.Create<RemoveDamageEffectOnInvurnableTarget>());
            Add(systems.Create<RemoveEffectsWithoutTargetsSystem>());
            
            Add(systems.Create<ProcessDamageEffectSystem>());
            Add(systems.Create<CleanupProcessedEffectsSystem>());
        }
    }
}