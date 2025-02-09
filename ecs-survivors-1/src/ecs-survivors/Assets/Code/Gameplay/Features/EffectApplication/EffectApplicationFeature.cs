using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EffectApplication
{
    public sealed class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<ApplyEffectsOnTargetsSystem>());
        }
    }
}