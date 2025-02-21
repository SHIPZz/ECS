using Code.Gameplay.Features.Pull.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Pull
{
    public sealed class PullFeature : Feature
    {
        public PullFeature(ISystemFactory system)
        {
            Add(system.Create<CastInPullRadiusSystem>());
            Add(system.Create<SetPullableHolderOnMagnificentBoltHitSystem>());
            
            Add(system.Create<MarkHolderDestructedWhenTargetsDestroyedSystem>());   
            Add(system.Create<MarkTargetPullableOnHitSystem>());   
            
            Add(system.Create<AddPullableToPullableHolderWithLimitSystem>());
            Add(system.Create<AddPullableToPullableHolderWithNoLimitSystem>());
            
            Add(system.Create<MoveToPullableHolderSystem>());   
            Add(system.Create<SequentialMoveToPullableHolderSystem>());   
            Add(system.Create<ApplySpeedUpStatusOnPullingSystem>());   
            
            Add(system.Create<MarkPullableDeadOnPullingFinishedSystem>());   
            Add(system.Create<MarkPullableDestructedOnPullingFinishedSystem>());   
        }
    }
}