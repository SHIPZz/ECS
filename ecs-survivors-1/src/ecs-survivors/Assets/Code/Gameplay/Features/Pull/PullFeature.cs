using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Pull.Systems;

namespace Code.Gameplay.Features.Pull
{
    public sealed class PullFeature : Feature
    {
        public PullFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastInPullRadiusSystem>());
            Add(systems.Create<SetPullableHolderOnMagnificentBoltHitSystem>());
            
            Add(systems.Create<MarkHolderDestructedWhenTargetsDestroyedSystem>());   
            Add(systems.Create<MarkTargetPullableOnHitSystem>());   
            
            Add(systems.Create<AddPullableToPullableHolderWithLimitSystem>());
            Add(systems.Create<AddPullableToPullableHolderWithNoLimitSystem>());
            
            Add(systems.Create<MoveToPullableHolderSystem>());   
            Add(systems.Create<MarkPullableDestructedOnPullingFinishedSystem>());   
        }
    }
}