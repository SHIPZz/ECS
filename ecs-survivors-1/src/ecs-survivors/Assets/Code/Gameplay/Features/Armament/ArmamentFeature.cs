using Code.Gameplay.Features.Armament.Systems;
using Code.Gameplay.Features.Movement.Factory;
using Code.Gameplay.Features.Skin;

namespace Code.Gameplay.Features.Armament
{
    public sealed class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetTargetSkinSetupOnArmamentHitSystem>());
            Add(systems.Create<MarkArmamentProcessedOnTargetLimitReachedSystem>());
            Add(systems.Create<ProcessMagnificentBoltOnHitSystem>());
            Add(systems.Create<ScatterOnHitSystem>());
            Add(systems.Create<FollowProducerSystem>());
            Add(systems.Create<FinalizeProcessedArmamentSystem>());
        }
    }
}