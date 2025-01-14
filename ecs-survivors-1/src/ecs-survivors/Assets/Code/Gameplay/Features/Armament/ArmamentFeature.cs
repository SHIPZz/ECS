using Code.Gameplay.Features.Armament.Systems;
using Code.Gameplay.Features.Armament.Systems.Poison;
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
            Add(systems.Create<CalculatePoisonLeftTimeSystem>());
            Add(systems.Create<PutPoisonOnTargetOnHitSystem>());
            Add(systems.Create<ApplyPoisoningUntilPoisonTimeUp>());
            Add(systems.Create<VampirismOnHitSystem>());
            Add(systems.Create<FinalizeProcessedArmamentSystem>());
            Add(systems.Create<CleanTargetPoisonedOnPoisonTimeUp>());
        }
    }
}