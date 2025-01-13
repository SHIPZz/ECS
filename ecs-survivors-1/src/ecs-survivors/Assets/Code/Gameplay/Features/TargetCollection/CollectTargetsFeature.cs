﻿using Code.Gameplay.Features.Movement;
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
            
            Add(systems.Create<CleanupTargetBuffersSystem>());
        }
    }
}