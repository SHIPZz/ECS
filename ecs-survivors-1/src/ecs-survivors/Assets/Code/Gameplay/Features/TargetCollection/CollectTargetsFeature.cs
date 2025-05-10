using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public sealed class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<DestructOnTargetBufferLimitReachedSystem>());
            
            Add(systemses.Create<CollectTargetsIntervalSystem>());
            
            Add(systemses.Create<CastForTargetsNoLimitSystem>());
            Add(systemses.Create<CastForTargetsWithLimitSystem>());
            Add(systemses.Create<MarkReachedSystem>());
            Add(systemses.Create<MarkTargetGotHitSystem>());
            
            Add(systemses.Create<CleanupGotHitEntities>());
            Add(systemses.Create<CleanupTargetBuffersSystem>());
        }
    }
    
    
}