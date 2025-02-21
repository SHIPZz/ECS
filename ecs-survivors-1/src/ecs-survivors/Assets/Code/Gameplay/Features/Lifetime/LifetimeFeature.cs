using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
    public sealed class LifetimeFeature : Feature
    {
        public LifetimeFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<MarkIsAliveSystem>());
            Add(systemses.Create<RestoreHpSystem>());
            Add(systemses.Create<CleanUpHpRestoredSystem>());
        }
    }
    
}