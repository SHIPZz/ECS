using Code.Gameplay.Features.Armament.Systems;
using Code.Gameplay.Features.Skin;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armament
{
    public sealed class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<SetTargetSkinSetupOnArmamentHitSystem>());
            Add(systemses.Create<MarkArmamentProcessedOnTargetLimitReachedSystem>());
            Add(systemses.Create<ProcessMagnificentBoltOnHitSystem>());
            Add(systemses.Create<ScatterOnHitSystem>());
            Add(systemses.Create<FollowProducerSystem>());
            Add(systemses.Create<FinalizeProcessedArmamentSystem>());
        }
    }
}