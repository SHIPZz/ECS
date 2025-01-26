using Code.Gameplay.Features.Armament.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Pull.Systems;
using Code.Gameplay.Features.Statuses.Systems;
using Code.Gameplay.Features.TargetCollection.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
    public sealed class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systems)
        {
            Add(systems.Create<DestructOnTargetBufferLimitReachedSystem>());
            
            Add(systems.Create<CollectTargetsIntervalSystem>());
            
            Add(systems.Create<CastForTargetsNoLimitSystem>());
            Add(systems.Create<CastForTargetsWithLimitSystem>());
            Add(systems.Create<MarkReachedSystem>());
            
            Add(systems.Create<CleanupTargetBuffersSystem>());
        }
    }
}