using Code.Gameplay.Features.Effects.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Effects
{
    public sealed class EffectFeature : Feature
    {
        public EffectFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<RemoveDamageEffectOnInvurnableTarget>());
            Add(systemses.Create<RemoveEffectsWithoutTargetsSystem>());
            
            Add(systemses.Create<ProcessHealEffectSystem>());
            Add(systemses.Create<ProcessVampirismOnDamageEffectSystem>());
            Add(systemses.Create<ProcessDamageEffectSystem>());
            Add(systemses.Create<CleanupProcessedEffectsSystem>());
            Add(systemses.Create<CleanupAppliedEffectTypeIdOnTarget>());
        }
    }
}