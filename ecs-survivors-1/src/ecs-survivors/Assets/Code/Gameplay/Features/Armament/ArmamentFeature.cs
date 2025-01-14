using Code.Gameplay.Features.Armament.Systems;
using Code.Gameplay.Features.Movement.Factory;

namespace Code.Gameplay.Features.Armament
{
    public sealed class ArmamentFeature : Feature
    {
        public ArmamentFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateBouncingArmamentCountOnFollowingUpSystem>());
            Add(systems.Create<MarkArmamentProcessedOnTargetLimitReachedSystem>());
            Add(systems.Create<ScatterOnHitSystem>());
            Add(systems.Create<FinalizeProcessedArmamentSystem>());
        }
    }
}